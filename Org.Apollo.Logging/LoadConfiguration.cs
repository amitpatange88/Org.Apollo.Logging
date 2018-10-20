using System;
using System.Configuration;

namespace Org.Apollo.Logging
{
    public class LoadConfiguration
    {
        internal string ProjectName = string.Empty;
        internal string ExecutionMode = string.Empty;
        internal string Environment = string.Empty;
        internal bool IsLogOn = false;

        //Assigning objects here only immplies lazy loading in Singleton design pattern.
        private static readonly Lazy<LoadConfiguration> instance = new Lazy<LoadConfiguration>(() => new LoadConfiguration());

        public static LoadConfiguration Instance
        {
            get
            {
                return instance.Value;
            }
        }


        /// <summary>
        /// Loads all appconfig details through constructor call
        /// </summary>
        public LoadConfiguration()
        {
            ProjectName = ConfigurationManager.AppSettings["ProjectName"];
            ExecutionMode = ConfigurationManager.AppSettings["Mode"];
            Environment = ConfigurationManager.AppSettings["Env"];
            IsLogOn = Convert.ToBoolean(ConfigurationManager.AppSettings["IsLogOn"]);
        }
    }
}
