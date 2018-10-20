using Newtonsoft.Json;
using System;

namespace Org.Apollo.Logging
{
    public class ErrorDetails
    {
        /// <summary>
        /// This field you can not set.Once you passed ErrorDetails object to library you will recieve a Log Unique Id to search in 
        /// database.
        /// </summary>
        [JsonProperty("LogId")]
        internal Guid LogUniqueId { get; set; }

        /// <summary>
        /// Precise DateTime Stamp
        /// </summary>
        [JsonProperty("PreciseTimeStamp")]
        internal DateTime PreciseTimeStamp { get; set; }

        /// <summary>
        /// UTC Datetime stamp.
        /// </summary>
        [JsonProperty("UTCTimeStamp")]
        internal DateTime UTCTimeStamp { get; set; }

        /// <summary>
        /// Set the log type from code.
        /// </summary>
        [JsonProperty("LogType")]
        internal LogType Type { get; set; }

        /// <summary>
        /// Set the log type in string.
        /// </summary>
        [JsonProperty("LogCategory")]
        internal string TypeName { get; set; }

        /// <summary>
        /// Execution Mode. Eg. Debug/Release etc...
        /// </summary>
        [JsonProperty("ExecutionMode")]
        internal string ExecutionMode  { get; set; }

        /// <summary>
        /// Environment : Dev/Test/TUP/HEN/PROD etc...
        /// </summary>
        [JsonProperty("Environment")]
        internal string Environment { get; set; }

        /// <summary>
        /// Defined by User : String error message.
        /// </summary>
        [JsonProperty("ErrorSignature")]
        public string ErrorSignature { get; set; }

        /// <summary>
        /// Defined by User : Store StackTrace from exception.
        /// </summary>
        [JsonProperty("StackTrace")]
        public string StackTrace { get; set; }

        /// <summary>
        /// Defined by User : c# or Customer ErrorCode by the using application.
        /// </summary>
        [JsonProperty("ErrorCode")]
        public int? ErrorCode { get; set; }

        /// <summary>
        /// Defined by User : Get Namespace + classname. typeof(T).FullName
        /// </summary>
        [JsonProperty("FullNameSpace")]
        public string FullNameSpace { get; set; }
    }
}
