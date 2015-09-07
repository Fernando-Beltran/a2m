using JSC.Template.BussinessLayer.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSC.Template.BussinessLayer
{
    public class TemplateFactory: ITemplateFactory
    {        
        private void _dinamictreeitem;
        private void _recursivetreeitem;

        public void GetDinamicTreeItemManager()
        {
           /* if (_dinamictreeitem == null)
                _dinamictreeitem = new DinamicTreeItemManager();

            return _dinamictreeitem;*/
        }

        public IRecursiveTreeManager GetRecursiveTreeManager()
        {
            if (_recursivetreeitem == null)
                _recursivetreeitem = new RecursiveTreeManager();

            return _recursivetreeitem;
        }
    }
}
