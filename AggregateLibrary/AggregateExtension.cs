using BaseLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AggregateLibrary
{
    /// <summary>
    /// Arragate 法
    /// </summary>
    public static  class AggregateExtension
    {

        public static Func<T2, bool> AggregateExpression<T1, T2>(this IEnumerable<ConditionExpression<T1, T2>> expressions, T1 condition)
        {
            return expressions.Where((x) => x.Source(condition)).Select((y) => y.Target).Aggregate((x, y) => (z => x(z) && y(z)));
        }
    }
}
