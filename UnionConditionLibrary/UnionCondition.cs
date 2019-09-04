using BaseLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnionConditionLibrary
{

    /// <summary>
    /// 直覺法
    /// </summary>
    public static class UnionCondition
    {

        public static bool NeedExecute<TCondition, TSource>(this IEnumerable<ConditionExpression<TCondition, TSource>> expressions, TCondition condition, TSource source)
        {         

            return expressions.All((y) => !y.Precondition(condition) ||  y.Postcondition(source));
        }
    
    }
}
