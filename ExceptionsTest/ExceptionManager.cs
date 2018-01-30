using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsTest
{
    public class ExceptionManager
    {
        public static bool HandleException(System.Exception ex)
        {
            try
            {
                if (!EventLog.SourceExists("Exception Test"))
                    EventLog.CreateEventSource("Exception Test", "Application");

                EventLog eventLog = new EventLog();
                eventLog.Source = "Exception Test";
                eventLog.WriteEntry(GetExceptionDetails(ex), EventLogEntryType.Error);
                return true;
            }
            catch
            {
                return false;
            }
        }
        
        private static string GetExceptionDetails(System.Exception ex)
        {

            PropertyInfo[] properties = ex.GetType().GetProperties();
            IEnumerable<string> fields = properties.Select(m => new { Name = m.Name, Value = m.GetValue(ex, null) })
                .Select(m => $"{m.Name} : {(m.Value != null ? m.Value.ToString() : string.Empty)}");
            return string.Join("\n", fields);
        }
    }
}
