using a2mbl.IManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a2mbl.Factory
{
    public interface IFactory
    {
        IBussinessManager GetBussinessManager();
    }
}
