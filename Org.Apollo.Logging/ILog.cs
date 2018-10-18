using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Org.Apollo.Logging
{
    public interface ILog
    {
        Guid Info();

        Guid Warning();

        Guid Error();
    }
}
