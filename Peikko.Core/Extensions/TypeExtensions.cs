using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Peikko.Core.Extensions
{
    public static class TypeExtensions
    {
        public static IEnumerable<Type> GetAssignableTypes(this Type t)
        {
            var domain = AppDomain.CurrentDomain;
            var assemblies = domain.GetAssemblies();
            var types = assemblies.SelectMany(x => x.GetTypes());
            types = types.Where(x => t.IsAssignableFrom(x));
            types = types.Where(x => x.IsClass);
            types = types.Where(x => !x.IsAbstract);

            return types;
        }
    }
}
