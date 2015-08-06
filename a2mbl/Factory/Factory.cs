using a2mbl.IManagers;
using a2mbl.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a2mbl.Factory
{
    public class Factory: IFactory
    {
        IBussinessManager _bussinessManager;


        public IBussinessManager GetBussinessManager()
        {
            if (_bussinessManager == null)
                _bussinessManager = new BussinessManager();

            return _bussinessManager;

        }

      
    }
}
