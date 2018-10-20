using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Org.Apollo.Logging
{
    public class Log : ILog
    {
        //Assigning objects here only immplies lazy loading in Singleton design pattern.
        private static readonly Lazy<Log> instance = new Lazy<Log>(() => new Log());
        private bool IsLoggingOn = LoadConfiguration.Instance.IsLogOn;

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

        /// <summary>
        /// Store informational error messages. Category.
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public Guid Info(ErrorDetails e = null)
        {
            if (!IsLoggingOn) return Guid.Empty;

            LoadCommonErrorDetailsFields(e, "Info");
            string infoLog = SerializeJSONData(e);
            FileUtility.Instance.WriteLog(infoLog);

            return e.LogUniqueId;
        }

        /// <summary>
        /// Category - Warning : This is warning related messages.
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public Guid Warning(ErrorDetails e = null)
        {
            if (!IsLoggingOn) return Guid.Empty;

            LoadCommonErrorDetailsFields(e, "Warning");
            string warningLog = SerializeJSONData(e);
            FileUtility.Instance.WriteLog(warningLog);

            return e.LogUniqueId;
        }

        /// <summary>
        /// Category Error : This is Exception message category.
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public Guid Error(ErrorDetails e)
        {
            if (!IsLoggingOn) return Guid.Empty;

            LoadCommonErrorDetailsFields(e, "Error");
            string exceptionLog = SerializeJSONData(e);
            FileUtility.Instance.WriteLog(exceptionLog);

            return e.LogUniqueId;
        }

        /// <summary>
        /// Serialize the JSON data. Using with Default contract resolver for non public fields.
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private string SerializeJSONData(ErrorDetails e)
        {
            //This (below line) won't be covering a non public fields. so code is below to cover this scenario.
            //var response = JsonConvert.SerializeObject(e);

            Newtonsoft.Json.JsonSerializerSettings jss = new Newtonsoft.Json.JsonSerializerSettings();

            Newtonsoft.Json.Serialization.DefaultContractResolver dcr = new Newtonsoft.Json.Serialization.DefaultContractResolver();
            dcr.DefaultMembersSearchFlags |= System.Reflection.BindingFlags.NonPublic;
            jss.ContractResolver = dcr;

            var response = Newtonsoft.Json.JsonConvert.SerializeObject(e, jss);

            return response;
        }

        /// <summary>
        /// Load common fields of ErrorDetails from common methods.
        /// </summary>
        /// <param name="e"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private static ErrorDetails LoadCommonErrorDetailsFields(ErrorDetails e, string type)
        {
            if (type == "Info")
            {
                e.Type = LogType.Info;
                e.TypeName = Constants.Info;
                e.ErrorCode = 0;
            }
            else if(type == "Warning")
            {
                e.Type = LogType.Warning;
                e.TypeName = Constants.Warning;
                e.ErrorCode = 1;
            }
            else if (type == "Error")
            {
                e.Type = LogType.Exception;
                e.TypeName = Constants.Exception;
            }

            e.LogUniqueId = Guid.NewGuid();
            e.PreciseTimeStamp = DateTime.Now;
            e.UTCTimeStamp = DateTime.UtcNow;
            e.Environment = LoadConfiguration.Instance.Environment;
            e.ExecutionMode = LoadConfiguration.Instance.ExecutionMode;

            return e;
        }
    }
}
