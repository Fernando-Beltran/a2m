using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a2mbl.Common
{
    public enum LinqFilterType { 
        Equals = 0,
        Greater,
        Lower,
        NotEquals,
        Contains,
    }
    public class LinqFilter
    {
        public string PropertyName { get; set; }
        public string PropertyValue { get; set; }
        public LinqFilterType FilterType { get; set; }
    }

    public static class LinqFilteruntUtils
    {
        public static string GetDynamicWhere(List<LinqFilter> filters)
        {
            StringBuilder query = new StringBuilder();
            foreach (LinqFilter iFilter in filters) {

                switch (iFilter.FilterType) { 
                    case LinqFilterType.Equals:
                        query.Append(iFilter.PropertyName + " == " + iFilter.PropertyValue + " ");
                        break;
                    case LinqFilterType.Greater:
                        query.Append(iFilter.PropertyName + " > " + iFilter.PropertyValue + " ");
                        break;
                    case LinqFilterType.Lower:
                        query.Append(iFilter.PropertyName + " < " + iFilter.PropertyValue + " ");
                        break;
                    case LinqFilterType.NotEquals:
                        query.Append(iFilter.PropertyName + " != " + iFilter.PropertyValue + " ");
                        break;
                        break;

                }
            }

            return query.ToString();

        }
    }
}
