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

        public static bool NeedExecute<T1, T2>(this IEnumerable<ConditionExpression<T1, T2>> expressions, T1 condition, T2 data)
        {         

            return expressions.All((y) => !y.Source(condition) ||  y.Target(data));
        }
    
    }
}
