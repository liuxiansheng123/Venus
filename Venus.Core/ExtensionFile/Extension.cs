using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Venus.Core.ExtensionFile
{
    public static class Extension
    {
        public static IEnumerable<T> WhereIf<T>(this IEnumerable<T> Source, bool isTrue, Func<T, bool> func)
        {
            return isTrue ? Source.Where(func) : Source;
        }

    }
}
