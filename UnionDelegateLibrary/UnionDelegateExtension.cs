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
        public static Func<T, bool> CombineExpression<T>(this Func<T, bool> source, Func<T, bool> target)
        {
            if (source == null && target == null )
            {
                throw new ArgumentNullException();
            }

            if (source == null && target != null)
            {
                return target;
            }

            if (source != null && target == null)
            {
                return source;
            }

            return (x) => source(x) && target(x);
        }
    }
}
