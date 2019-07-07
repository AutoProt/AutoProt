using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Serilog;

namespace AutoProt
{
    public class FileMonitor : IDisposable
    {
        private bool disposed = false;
        private const int noWatchers = 5;
        private const string fileFilter = "*.raw";
        private NetFileSystemWatcher[] watcherArray;
        private bool[] isWatching;
        private BlockingCollection<string> queue;
        private ConcurrentDictionary<string, int> fileList;
        //private IProgress<string> progress; //temporary solution, just want to check when handleconnectchanged event fires.

        public FileMonitor()
        {
            this.isWatching = new bool[noWatchers];
            this.watcherArray = new NetFileSystemWatcher[noWatchers];
            this.fileList = new ConcurrentDictionary<string, int>();
        }
        public IEnumerable<string> GetFile()
        {
            return queue.GetConsumingEnumerable();
        }
        public bool IsWatching(int watcherIndex)
        { 
            if (watcherIndex >= isWatching.Length)
            {
                return false;
            }
            else 
            {
                return isWatching[watcherIndex];
            }
        }
        public bool AnyWatching()
        {
            bool anywatch = false;
            for (int i = 0; i < isWatching.Length; i++) 
            {
                if (isWatching[i])
                {
                    anywatch = true;
                }
            }
            return anywatch;
        }

        public void Start(int watchIndex, string dirToMonitor)
        {
            ReadExistingFiles(dirToMonitor);
            this.watcherArray[watchIndex] = new NetFileSystemWatcher
            {
                IncludeSubdirectories = false,
                //InternalBufferSize = 65536, //going with default for now
                Path = dirToMonitor,
                NotifyFilter = NotifyFilters.LastWrite,
                //this.watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName | NotifyFilters.Size | NotifyFilters.Security | NotifyFilters.CreationTime;
                Filter = fileFilter
            };
            //this.watcher.Filter = "*.*";
            this.watcherArray[watchIndex].Changed += QueueFile;
            this.watcherArray[watchIndex].Created += QueueFile;
            this.watcherArray[watchIndex].Renamed += OnRenamed;

            this.watcherArray[watchIndex].ConnectionStateChanged += HandleConnectStateChanged;

            //this.progress = progress;
            //this.watcher.Created += new FileSystemEventHandler(MyReport);
            //this.watcher.Changed += new FileSystemEventHandler(MyReport);
            this.watcherArray[watchIndex].EnableRaisingEvents = true;
            this.isWatching[watchIndex] = true;
            Log.Information("[" + dirToMonitor + "] Started monitoring folder");
        }

        public void Stop(int watchIndex)
        {
            if (IsWatching(watchIndex))
            {
                string folder = this.watcherArray[watchIndex].Path;
                this.watcherArray[watchIndex].EnableRaisingEvents = false;
                this.watcherArray[watchIndex].Dispose();
                this.isWatching[watchIndex] = false;
                Log.Information("[" + folder + "] Stopped monitoring folder");
            }
            if (!AnyWatching())
            {
                CloseFilelist();
                Log.Information("Ended background processing thread");
            }
        }

        public bool TryIncreaseCounterAndRequeue(string fileName)
        {
            bool returnvar = false;
            int i = 0;
            if (fileList.TryGetValue(fileName, out i))
            {
                returnvar = fileList.TryUpdate(fileName, i + 1, i);
                if (returnvar && !queue.Contains(fileName))
                {
                    queue.Add(fileName);
                }
            }
            return returnvar;
        }

        public int GetCounter(string fileName)
        {
            int i;
            if (!fileList.TryGetValue(fileName, out i))
            {
                i = 0;
            }
            return i;
        }
        
        private void ReadExistingFiles(string path)
        {
            foreach (string file in Directory.EnumerateFiles(path, fileFilter))
            {
                fileList.TryAdd(file, int.MaxValue);
                //progress.Report("[" + file + "]: Initial scanning discovered this file");//TEMP
            }
        }
        private void PollDirectory(string path)
        {
            foreach (string file in Directory.EnumerateFiles(path, fileFilter))
            {
                if (fileList.TryAdd(file, 0))
                {
                    queue.Add(file);
                    Log.Information("[" + file + "]: File polling discovered a missed file, added it to the queue");
                }
            }
        }
        private void HandleConnectStateChanged(object sender, ConnectionStateChangedEventArgs e)
        {
            switch (e.ConnectionState)
            {
                case ConnectionState.Connected:
                    Log.Information("Connect state changed: " + e.ConnectionState + " for directory: " + e.Path);
                    PollDirectory(e.Path);
                    break;
                case ConnectionState.Disconnected:
                    Log.Information("Connect state changed: " + e.ConnectionState + " for directory: " + e.Path);
                    break;
                case ConnectionState.Reconnected:
                    PollDirectory(e.Path);
                    break;
            }
        }

        private void CloseFilelist()
        {
            if (this.queue != null)
            {
                this.queue.CompleteAdding();
            }
        }
        public void NewFilelist()
        {
            CloseFilelist();
            this.queue = new BlockingCollection<string>();
        }

        private void QueueFile(object source, FileSystemEventArgs e)
        {
            if (fileList.TryAdd(e.FullPath, 0))
            {
                queue.Add(e.FullPath);
                Log.Information("[" + e.FullPath + "]: File queued");
            }            
        }
        private void OnRenamed(object source, RenamedEventArgs e)
        {
            if (fileList.TryAdd(e.FullPath, 0))
            {
                queue.Add(e.FullPath);
                Log.Information("[" + e.FullPath + "]: File queued (after being renamed)");
            }
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    CloseFilelist();
                    foreach (NetFileSystemWatcher curWatcer in watcherArray)
                    {
                        if (curWatcer != null)
                        {
                            curWatcer.Dispose();
                        }
                    }
                }
                disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
