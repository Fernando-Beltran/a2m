using JSC.FX.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSC.Template.BussinessLayer
{
           //dejo esta clase para no tener que poner en todos los laos T y Tinterface
        internal abstract class TemplateManagerBase : BusinessManagerBase<ITemplateFactory, TemplateFactory>
        {
            protected int? GetParentWorkSpace(int childWorkSpaceId)
            {
                using (ContextWrapper context = new ContextWrapper())
                {
                    //TODO: incluir gestión de workspaces
                    return null;
                    //return context.Current.Workspaces.Where(work => work.Id == childWorkSpaceId).Select(work => work.ParentId).FirstOrDefault();
                }
            }

            protected bool IsBssRefValid(string bssRef)
            {
                bool returnValue = true;

             

                return returnValue;
            }
       
    }
}
