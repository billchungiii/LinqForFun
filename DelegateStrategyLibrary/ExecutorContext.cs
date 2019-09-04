using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateStrategyLibrary
{
    public static class ExecutorContext
    {
        public static IEnumerable<TSource> Execute<TSource, TCondition>(this IEnumerable<TSource> source, Func<TCondition, bool> precondition, Func<TSource , TCondition ,  bool> postcondition, TCondition condition)
        {

            return !precondition(condition) ? source : source.Where((x) => postcondition(x, condition));
            
        }
    }
}
