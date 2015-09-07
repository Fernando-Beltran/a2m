using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JSC.FX.BL;

namespace JSC.Template.BussinessLayer
{
    internal class ContextWrapper : BaseContextWrapper<TemplateConnection>
    {
        
        public ContextWrapper() : base() { this.Current.CommandTimeout = Properties.Settings.Default.DBTimeOutSeconds; }

        public ContextWrapper(bool shared) : base(shared) { this.Current.CommandTimeout = Properties.Settings.Default.DBTimeOutSeconds; }

    }
}
