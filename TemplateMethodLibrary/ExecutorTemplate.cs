using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// <summary>
/// 範本方法模式
/// </summary>
namespace TemplateMethodLibrary
{
    public abstract class ExecutorTemplate<TSource, TCondition>
    {

        public IEnumerable<TSource> Execute(IEnumerable<TSource> source, TCondition condition)
        {
            if (!ExecutePrecondition(condition))
            { return source; }
            else
            {
                return source.Where((x) => ExecutePostcondition(x, condition));
            }
        }

        protected abstract bool ExecutePrecondition(TCondition condition);

        protected abstract bool ExecutePostcondition(TSource value, TCondition condition);
    }
}
