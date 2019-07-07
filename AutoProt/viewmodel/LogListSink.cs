using Serilog.Core;
using Serilog.Events;
using Serilog.Formatting;
using Serilog.Formatting.Display;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoProt
{
    public class LogListSink : ILogEventSink
    {
        //ensure that the list is only changed on the thread where the logging was initialized
        private readonly SynchronizationContext _context = SynchronizationContext.Current;
        
        //format of the log entries
        private readonly ITextFormatter _textFormatter = new MessageTemplateTextFormatter("{Timestamp} [{Level}] {Message}{Exception}", CultureInfo.InvariantCulture);

        //list open for 1-way binding
        public BindingList<string> LogEvents { get; } = new BindingList<string>();

        //maximum list size
        private readonly int maxListSize = 254;

        //triggered when new logEvent occur, they are added to LogEvents list.
        public void Emit(LogEvent logEvent)
        {
            if (logEvent == null)
            {
                throw new ArgumentNullException(nameof(logEvent));
            }
            var renderSpace = new StringWriter();
            _textFormatter.Format(logEvent, renderSpace);
            if (this.LogEvents.Count >= maxListSize)
            {
                _context.Send(o => this.LogEvents.RemoveAt(0), null);
            }
            _context.Send(o => this.LogEvents.Add(renderSpace.ToString()), null);
        }
    }
}
