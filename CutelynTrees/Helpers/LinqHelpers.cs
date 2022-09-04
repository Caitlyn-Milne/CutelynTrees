using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CutelynTrees
{
    internal static class LinqHelpers
    {
        internal static IEnumerable<T> NotNull<T>(this IEnumerable<T?> self)
        {
            #pragma warning disable CS8619 
            return self.Where(value => value is not null);
            #pragma warning restore CS8619 
        }
    }
}
