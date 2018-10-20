using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Org.Apollo.Logging
{
    public class ErrorDetails
    {
        /// <summary>
        /// This field you can not set.Once you passed ErrorDetails object to library you will recieve a Log Unique Id to search in 
        /// database.
        /// </summary>
        internal Guid LogUniqueId { get; set; }

        internal DateTime PreciseTimeStamp { get; set; }

        internal DateTime UTCTimeStamp { get; set; }

        /// <summary>
        /// Set the log type from code.
        /// </summary>
        internal LogType Type { get; set; }

        /// <summary>
        /// Set the log type in string.
        /// </summary>
        internal string TypeName { get; set; }

        internal string ExecutionMode  { get; set; }

        internal string Environment { get; set; }

        /// <summary>
        /// Defined by User :
        /// </summary>
        public string ErrorSignature { get; set; }

        /// <summary>
        /// Defined by User : Store StackTrace from exception.
        /// </summary>
        public string StackTrace { get; set; }

        /// <summary>
        /// Defined by User : c# or Customer ErrorCode by the using application.
        /// </summary>
        public int? ErrorCode { get; set; }

        /// <summary>
        /// Defined by User : Get Namespace + classname. typeof(T).FullName
        /// </summary>
        public string FullNameSpace { get; set; }
    }
}
