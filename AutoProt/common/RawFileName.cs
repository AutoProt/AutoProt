using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace AutoProt
{
    public class RawFileName
    {
        public string FullName { get; private set; }
        public string BaseName { get; private set; }
        public string FilePath { get; private set; }

        public string User { get; private set; }
        public string MsInstrument { get; private set; }
        public string MsInstrumentDetails { get; private set; }
        public string LcInstrument { get; private set; }
        public string LcInstrumentDetails { get; private set; }
        public string SampleType { get; private set; }
        public string SampleTypeDetails { get; private set; }
        public bool SomethingWrongWithFileName { get; private set; }

        public double LcTime { get; private set; }
        public double MsTime { get; private set; }
        public double FileSizeMiB { get; private set; }
        public double SpaceLeftGiB { get; private set; }

        public int[] daysToGoBack { get; private set; }
        private List<double> _lcmsUsageHistory;
        private List<double> _msUsageHistory;
        private List<double> _pureMsUsageHistory;

        public string UserEmail { get; private set; }
        public List<string> CcEmails { get; private set; }

        private string[] lcmsTimes;

        public RawFileName(string fullName)
        {
            this.FullName = fullName;
            this.BaseName = Path.GetFileNameWithoutExtension(fullName);
            this.FilePath = Path.GetDirectoryName(fullName);

            this.lcmsTimes = new string[3] { "", "", "" };

            try
            {
                long byteSize = new FileInfo(fullName).Length;
                this.FileSizeMiB = byteSize / 1048576.0;//1024^2
                this.SpaceLeftGiB = 0.0;
            }
            catch
            {
            }
            this._lcmsUsageHistory = new List<double>();
            this._msUsageHistory = new List<double>();
            this._pureMsUsageHistory= new List<double>();
            this.daysToGoBack = new int[] { 1, 7, 30, 90 };
            this.CcEmails = new List<string>();
        }

        public string FullNameWithoutExtension
        {
            get
            {
                return FilePath + "\\" + BaseName;
            }
        }
            


        public void UpdateSpaceLeft(string path)
        {
            FileInfo fileInfo = new FileInfo(path);
            DriveInfo driveInfo = new DriveInfo(fileInfo.Directory.Root.FullName);
            this.SpaceLeftGiB = driveInfo.AvailableFreeSpace / 1073741824.0;//1024^3
        }

        public Dictionary<int,Tuple<double,double,double>> GetUsagePercent()
        {
            Dictionary<int, Tuple<double, double, double>> usage = new Dictionary<int, Tuple<double, double, double>>();
            bool isQC = this.SampleType.Equals("QC");
            for (int i = 0; i<daysToGoBack.Length;i++)
            {
                double _lcmsUsagePercent = 0.0;
                double _msUsagePercent = 0.0;
                double _pureMsUsagePercent = 0.0;

                if (_lcmsUsageHistory.Count > i && _lcmsUsageHistory[i] > 0.0)
                {
                    _lcmsUsagePercent = ((_lcmsUsageHistory[i] + LcTime + MsTime) / (daysToGoBack[i] * 14.4));//14.4 = 24h/day * 60min/h / 100%
                    _msUsagePercent = ((_msUsageHistory[i] + MsTime) / (daysToGoBack[i] * 14.4));
                    if (isQC)
                    {
                        _pureMsUsagePercent = (_pureMsUsageHistory[i] / (daysToGoBack[i] * 14.4));
                    }
                    else
                    {
                        _pureMsUsagePercent = ((_pureMsUsageHistory[i] + MsTime) / (daysToGoBack[i] * 14.4));
                    }
                }
                usage.Add(daysToGoBack[i], new Tuple<double, double, double>(_lcmsUsagePercent, _msUsagePercent, _pureMsUsagePercent));
            }
            return usage;
        }


        public override string ToString()
        {
            return BaseName;
        }
        public void SetDates(DateTime lcmsStart, DateTime msStart, DateTime lcmsEnd)
        {
            string datePatt = @"yyyy-MM-dd HH:mm:ss";
            this.lcmsTimes = new string[3] { lcmsStart.ToString(datePatt), msStart.ToString(datePatt), lcmsEnd.ToString(datePatt) };

            TimeSpan span = lcmsEnd.Subtract(msStart);
            MsTime = span.TotalMinutes;
            if (MsTime < 0 | MsTime > 1440)
            {
                MsTime = 0;
            }
            span = msStart.Subtract(lcmsStart);
            LcTime = span.TotalMinutes;
            if (LcTime < 0 | LcTime > 1440)
            {
                LcTime = 0;
            }
        }
        public string GetDates(int index)
        {
            if (index >= 0 && index <= 2)
                return lcmsTimes[index];
            else
                return "";
        }

        public void SetUsageTimes(List<double> lcmsUsagePercent, List<double> msUsagePercent, List<double> pureMsUsagePercent)
        {
            this._lcmsUsageHistory = lcmsUsagePercent;
            this._msUsageHistory = msUsagePercent;
            this._pureMsUsageHistory = pureMsUsagePercent;
        }

        private void AddToEmails(string emails)
        {
            if (emails != null)
            {
                char[] splitchar = { ';', ',' };
                foreach (string newEntry in emails.Split(splitchar, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (!this.CcEmails.Contains(newEntry))
                    {
                        this.CcEmails.Add(newEntry);
                    }
                }
            }
        }
        public string ReadCategories()
        {
            StringBuilder newstring = new StringBuilder();
            newstring.Append("User: ");
            newstring.Append(this.User);
            newstring.Append("\nUser email: ");
            newstring.Append(this.UserEmail);
            newstring.Append("\nSample: ");
            newstring.Append(this.SampleType);
            newstring.Append(" and ");
            newstring.Append(this.SampleTypeDetails);
            newstring.Append("\nLC: ");
            newstring.Append(this.LcInstrument);
            newstring.Append(this.LcInstrumentDetails);
            newstring.Append("\nMS: ");
            newstring.Append(this.MsInstrument);
            newstring.Append(this.MsInstrumentDetails);
            if (this.CcEmails.Count > 0)
            {
                newstring.Append("\nCC emails: ");
                bool notfirst = false;
                foreach (string email in this.CcEmails)
                {
                    if (notfirst)
                    {
                        newstring.Append(";");
                    }
                    newstring.Append(email);
                    notfirst = true;
                }
            }
            return newstring.ToString();
        }

        public void SetCategories(IList<FileNameCategoryRow> UserCategories, IList<FileNameCategoryRow> LcCategories, IList<FileNameCategoryRow> MsCategories, IList<FileNameCategoryRow> SamplesCategories)
        {
            //set the user
            int userIndex = GetIndexMatch(UserCategories);
            if (userIndex > -1)
            {
                this.User = UserCategories[userIndex].Level1;
                this.UserEmail = UserCategories[userIndex].Level2;
                AddToEmails(UserCategories[userIndex].CCemail);
            }
            else
            {
                this.User = "Unknown";
                this.UserEmail = string.Empty;
                this.SomethingWrongWithFileName = true;
            }
            //set the sample
            int sampleIndex = GetIndexMatch(SamplesCategories);
            if (sampleIndex > -1)
            {
                this.SampleType = SamplesCategories[sampleIndex].Level1;
                this.SampleTypeDetails = SamplesCategories[sampleIndex].Level2;
                AddToEmails(SamplesCategories[sampleIndex].CCemail);
            }
            else
            {
                this.SampleType = "Unknown";
                this.SampleTypeDetails = "Unknown";
                this.SomethingWrongWithFileName = true;
            }
            //set the lc
            int lcIndex = GetIndexMatch(LcCategories);
            if (lcIndex > -1)
            {
                this.LcInstrument = LcCategories[lcIndex].Level1;
                this.LcInstrumentDetails = LcCategories[lcIndex].Level2;
                AddToEmails(LcCategories[lcIndex].CCemail);
            }
            else
            {
                this.LcInstrument = "Unknown";
                this.LcInstrumentDetails = "Unknown";
                this.SomethingWrongWithFileName = true;
            }
            //set the ms
            int msIndex = GetIndexMatch(MsCategories);
            if (msIndex > -1)
            {
                this.MsInstrument = MsCategories[msIndex].Level1;
                this.MsInstrumentDetails = MsCategories[msIndex].Level2;
                AddToEmails(MsCategories[msIndex].CCemail);
            }
            else
            {
                this.MsInstrument = "Unknown";
                this.MsInstrumentDetails = "Unknown";
                this.SomethingWrongWithFileName = true;
            }
        }
        private int GetIndexMatch(IList<FileNameCategoryRow> list)
        {
            int returnvalue = -1;
            for (int i = 0; i < list.Count; i++)
            {
                if (Regex.IsMatch(BaseName, list[i].Pattern))
                {
                    returnvalue = i;
                    i = list.Count;
                }
            }
            return returnvalue;
        }
    }
}
