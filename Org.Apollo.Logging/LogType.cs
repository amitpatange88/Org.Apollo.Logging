using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Org.Apollo.Logging
{
    public enum LogType
    {
        Info,
        Warning,
        Exception
    }

    public static class Constants
    {
        public static string Info = "Informational";

        public static string Warning = "Warning";

        public static string Exception = "Exception";
    }
}
