using a2mbl.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a2mbl.Linq
{
    public abstract class BusinessManagerBase<TInterface, TImplementation> where TImplementation : TInterface, new()
    {
        private const string ExceptionPolicyName = "BussinesPolicy";
        private TInterface _factory = default(TInterface);

        /// <summary>
        /// esta propiedad sirve para cuando un manager desea llamar a un metodo de otro manager
        /// y asi no instanciarlo directamente manteniendo la estructura de abstract factory.
        /// Lo ponemos virtual para facilitar mocking si fuera necesario
        /// </summary>
        protected virtual TInterface CurrentFactory
        {
            get
            {
                if (_factory == null)
                    _factory = new TImplementation();
                return _factory;
            }
        }
        protected DynamicWhere GenerateDynamicWhere(List<BusinessFilterCriteria> filters)
        {
            DynamicWhere returnValue = new DynamicWhere();
            ArrayList parameters = new ArrayList();


            if (filters != null)
            {
                int counter = 0;
                foreach (BusinessFilterCriteria current in filters)
                {
                    if (counter > 0)
                        returnValue.WhereClause += " && ";

                    switch (current.Operator)
                    {
                        case FilterOperator.Contains:
                            returnValue.WhereClause += string.Format("{0}.Contains(@{1})", current.PropertyName, counter);
                            break;
                        case FilterOperator.Exact:
                            returnValue.WhereClause += string.Format("{0} == @{1}", current.PropertyName, counter);
                            break;
                        case FilterOperator.StartsWith:
                            returnValue.WhereClause += string.Format("{0}.StartsWith(@{1})", current.PropertyName, counter);
                            break;
                        case FilterOperator.GreaterThan:
                            returnValue.WhereClause += string.Format("{0} > @{1}", current.PropertyName, counter);
                            break;
                        case FilterOperator.LessThan:
                            returnValue.WhereClause += string.Format("{0} < @{1}", current.PropertyName, counter);
                            break;

                    }

                    parameters.Add(current.PropertyValue);

                    counter++;
                }
            }
            returnValue.Params = parameters.ToArray();
            return returnValue;
        }
    }

    public class DynamicWhere
    {
        public string WhereClause { get; set; }
        public object[] Params { get; set; }
    }
}
