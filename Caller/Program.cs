using Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caller
{
    class Program
    {
        static void Main(string[] args)
        {
            Log4NetLogger logger = new Log4NetLogger("LoggerName");
            logger.ReferenceID = Guid.NewGuid();
            var inputs = new Dictionary<string, object>();
            inputs.Add("Input1", "Value1");
            logger.inputParameters = inputs;
            logger.Info("Message", ViewLevel.All, null);
        }
    }
}
