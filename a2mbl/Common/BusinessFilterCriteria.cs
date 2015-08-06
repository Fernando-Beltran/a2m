using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a2mbl.Common
{
    public enum FilterOperator
    {
        /// <summary>
        /// se compara de manera exacta
        /// </summary>
        Exact,
        /// <summary>
        /// se compara mirando que empiece por ese valor(deben de ser strings)
        /// </summary>
        StartsWith,
        /// <summary>
        /// se compara mirando que contenga el valor(deben de ser strings)
        /// </summary>
        Contains,
        /// <summary>
        /// mayor que
        /// </summary>
        GreaterThan,
        /// <summary>
        /// menor que
        /// </summary>
        LessThan

    }

    [Serializable]
    public class BusinessFilterCriteria
    {
        /// <summary>
        /// nombre de las propiedad que voy a filtrar 
        /// </summary>
        public string PropertyName { get; set; }
        /// <summary>
        /// valor de la propiedad del filtro
        /// </summary>
        public object PropertyValue { get; set; }
        /// <summary>
        /// operador que se utilizara para el filtro
        /// </summary>
        public FilterOperator Operator { get; set; }
    }

}
