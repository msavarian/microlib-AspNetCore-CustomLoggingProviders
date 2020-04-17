using System.Collections.Generic;

namespace CustomLogProviders
{
    public class LogScopeInfo
    {
        public LogScopeInfo()
        {
        }

        public string Text { get; set; }
        public Dictionary<string, object> Properties { get; set; }
    }
}