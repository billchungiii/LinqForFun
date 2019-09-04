using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnionDelegateLibrary
{
    /// <summary>
    /// 聯合條件運算法
    /// </summary>
    public static class UnionDelegateExtension
    {
        public static Func<T, bool> CombineExpression<T>(this Func<T, bool> precondition, Func<T, bool> postcondition)
        {
            if (precondition == null && postcondition == null )
            {
                throw new ArgumentNullException();
            }

            if (precondition == null && postcondition != null)
            {
                return postcondition;
            }

            if (precondition != null && postcondition == null)
            {
                return precondition;
            }

            return (x) => precondition(x) && postcondition(x);
        }
    }
}
