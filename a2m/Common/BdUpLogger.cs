using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace a2m.Common
{
    public class BdUpLogger : DbUp.Engine.Output.IUpgradeLog
    {
        public void WriteError(string format, params object[] args)
        {
            A2MApplication.Log.Fatal("BdUpLogger " + format);
            foreach (var arg in args) {
                A2MApplication.Log.Fatal("Args " + arg.ToString());
            }
        }

        public void WriteInformation(string format, params object[] args)
        {
            A2MApplication.Log.Info("BdUpLogger " + format);
            foreach (var arg in args)
            {
                A2MApplication.Log.Fatal("Args " + arg.ToString());
            }
        }

        public void WriteWarning(string format, params object[] args)
        {
            A2MApplication.Log.Warn("BdUpLogger " + format);
            foreach (var arg in args)
            {
                A2MApplication.Log.Fatal("Args " + arg.ToString());
            }
        }
    }
}