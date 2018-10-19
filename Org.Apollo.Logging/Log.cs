using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Org.Apollo.Logging
{
    public class Log : ILog
    {
        //Assigning objects here only immplies lazy loading in Singleton design pattern.
        private static readonly Lazy<Log> instance = new Lazy<Log>(() => new Log());

        public static Log Instance
        {
            get
            {
                return instance.Value;
            }
        }

        public Log()
        {
            
        }

        public Guid Info(ErrorDetails e = null)
        {
            e.LogUniqueId = Guid.NewGuid();
            e.PreciseTimeStamp = DateTime.Now;
            e.UTCTimeStamp = DateTime.UtcNow;
            e.Type = LogType.Info;
            e.TypeName = Constants.Info;
            string infoLog = JsonConvert.SerializeObject(e);
            FileUtility.Instance.WriteLog(infoLog);
            
            return e.LogUniqueId;
        }

        public Guid Warning(ErrorDetails e = null)
        {
            e.LogUniqueId = Guid.NewGuid();
            e.PreciseTimeStamp = DateTime.Now;
            e.UTCTimeStamp = DateTime.UtcNow;
            e.Type = LogType.Warning;
            e.TypeName = Constants.Warning;
            string warningLog = JsonConvert.SerializeObject(e);
            FileUtility.Instance.WriteLog(warningLog);

            return e.LogUniqueId;
        }

        public Guid Error(ErrorDetails e)
        {
            e.LogUniqueId = Guid.NewGuid();
            e.PreciseTimeStamp = DateTime.Now;
            e.UTCTimeStamp = DateTime.UtcNow;
            e.Type = LogType.Exception;
            e.TypeName = Constants.Exception;
            string exceptionLog = JsonConvert.SerializeObject(e);
            FileUtility.Instance.WriteLog(exceptionLog);

            return e.LogUniqueId;
        }
    }
}
