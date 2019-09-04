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
        public Func<T1, bool> Precondition { get; }

        public Func<T2, bool> Postcondition { get; }

        public ConditionExpression (Func<T1, bool> precondition, Func<T2, bool> postcondition)
        {
            Precondition = precondition;
            Postcondition = postcondition;
        }
       
    }
}
