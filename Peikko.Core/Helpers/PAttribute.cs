using System;
using System.Collections.Generic;
using System.Linq;

namespace Peikko.Core.Helpers
{
    public static class PAttribute
    {
        public static IEnumerable<Type> GetTypesWithAttribute<TAttribute>()
            where TAttribute : Attribute
        {
            var types = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => x.GetCustomAttributes(typeof(TAttribute), true).Any())
                ;

            return types;
        }
    }
}
