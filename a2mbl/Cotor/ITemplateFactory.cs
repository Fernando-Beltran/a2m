using JSC.Template.BussinessLayer.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSC.Template.BussinessLayer
{
    public interface ITemplateFactory
    {
        IDinamicTreeItemManager GetDinamicTreeItemManager();
        IRecursiveTreeManager GetRecursiveTreeManager();
    }
}
