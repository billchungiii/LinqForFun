using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyLibrary
{
    public static class ExecutorContext
    {
        public static IEnumerable<TSource> Execute<TSource, TCondition>(this IEnumerable<TSource> source, TCondition condition, IExecutor<TSource, TCondition> executor)
        {
            //if (!executor.ExeutePrecondition(condition))
            //{
            //    return source;
            //}
            //return source.Where((x) => executor.ExecutePostcondition(x, condition));

           return !executor.ExeutePrecondition(condition) ? source : source.Where((x) => executor.ExecutePostcondition(x, condition));
        }
    }

    public interface IExecutor<TSouce, TCondition>
    {
        bool ExeutePrecondition(TCondition condition);

        bool ExecutePostcondition(TSouce source, TCondition condition);
    }
}
