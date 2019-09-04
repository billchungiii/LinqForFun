using BaseLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursiveLibrary
{
    /// <summary>
    /// 遞迴結合法
    /// </summary>
    public static class Recursive
    {
        public static IEnumerable<T2> Execute<T1, T2>(this IEnumerable<T2> source, List<ConditionExpression<T1, T2>> expressions, T1 condition)
        {
            //if (expressions.Count > 0)
            //{
            //    if (expressions[0].Precondition(condition))
            //    {
            //        source = source.Where(expressions[0].Postcondition);
            //    }

            //    expressions.RemoveAt(0);
            //    return source.Execute(expressions, condition);
            //}
            //return source;

            if (expressions.Count > 0)
            {
                source = !expressions[0].Precondition(condition) ? source : source.Where(expressions[0].Postcondition);
                expressions.RemoveAt(0);
                return source.Execute(expressions, condition);
            }
            return source;
        }
    }
}
