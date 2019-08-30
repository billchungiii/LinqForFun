using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary
{
    /// <summary>
    /// immutable
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    public  class ConditionExpression<T1, T2>
    {
        public Func<T1, bool> Source { get; }

        public Func<T2, bool> Target { get; }

        public ConditionExpression (Func<T1, bool> source, Func<T2, bool> target)
        {
            Source = source;
            Target = target;
        }
       
    }
}
