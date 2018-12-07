using System;
using System.Collections.Generic;
using System.Linq;

namespace Peikko.Core.Extensions
{
    public static class TypeExtensions
    {
        public static IEnumerable<Type> GetAssignableTypes(this Type t)
        {
            var types = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => t.IsAssignableFrom(x))
                .Where(x => x.IsClass)
                .Where(x => !x.IsAbstract);

            return types;
        }

        public static bool IsAssignableFromGenericType(this Type genericType, Type givenType)
        {
            var interfaceTypes = givenType.GetInterfaces();

            foreach (var interfaceType in interfaceTypes)
            {
                if (interfaceType.IsGenericType && interfaceType.GetGenericTypeDefinition() == genericType)
                    return true;
            }

            if (givenType.IsGenericType && givenType.GetGenericTypeDefinition() == genericType)
                return true;

            var baseType = givenType.BaseType;
            if (baseType == null) return false;

            return genericType.IsAssignableFromGenericType(baseType);
        }

        public static bool IsInstanceOfGenericType(this Type instanceType, Type baseType)
        {
            var type = instanceType;

            while (type != null)
            {
                if (type.IsGenericType && type.GetGenericTypeDefinition() == baseType) {
                    return true;
                }
                type = type.BaseType;
            }

            return false;
        }
    }
}
