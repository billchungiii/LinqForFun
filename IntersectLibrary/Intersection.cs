using BaseLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntersectLibrary
{
    /// <summary>
    /// 取得每個條件的 IEnumerable，然後交集
    /// </summary>
    public static class Intersection
    {
        public static IEnumerable<T2> Execute<T1, T2>(this IEnumerable<T2> source, IEnumerable<ConditionExpression<T1, T2>> expressions, T1 condition)
        {
            return source.InnerExecute(expressions, condition).Aggregate((x, y) => x.Intersect(y));
        }

        private static IEnumerable<IEnumerable<T2>> InnerExecute<T1, T2>(this IEnumerable<T2> source, IEnumerable<ConditionExpression<T1, T2>> expressions, T1 condition)
        {

          return   expressions.Where((x) => x.Precondition(condition)).Select((y) => source.Where (y.Postcondition));
            
        }
    }
}
