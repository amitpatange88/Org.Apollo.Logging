using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Org.Apollo.Logging
{
    public class ErrorDetails
    {
        public Guid LogUniqueId { get { return Guid.NewGuid(); } private set { } }

        public DateTime PreciseTimeStamp { get { return DateTime.Now; } private set { } }

        public DateTime UTCTimeStamp { get { return DateTime.UtcNow; } private set { } }

        public LogType Type { get; set; }

        public string ErrorSignature { get; set; }

        public string StackTrace { get; set; }

        public string ErrorCode { get; set; }

        public string FullNameSpace { get; set; }
    }
}
