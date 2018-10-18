using System;
using System.Collections.Generic;
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

        static Log()
        {

        }

        public Log()
        {
            
        }

        public Guid Info()
        {
            return Guid.NewGuid();
        }

        public Guid Warning()
        {
            return Guid.NewGuid();
        }

        public Guid Error()
        {
            return Guid.NewGuid();
        }
    }
}
