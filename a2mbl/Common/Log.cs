using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a2mbl.Common
{
    public static class LogWrapper
    {       
            public static ILog GetLogger()
            {
                if (LogManager.GetCurrentLoggers().Length == 0)
                {
                    LoadConfig();
                }
                return LogManager.GetCurrentLoggers()[0];
            }

            private static void LoadConfig()
            {
                log4net.Config.XmlConfigurator.Configure();
            }
       
        
    }
}
