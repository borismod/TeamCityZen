using System.Collections.Generic;

namespace TeamCityZen.Tests
{
    public static class ObjectExtensions
    {
        public static List<T> AsList<T>(this T @object)
        {
            return new List<T> {@object};
        }

        public static T[] AsArray<T>(this T @object)
        {
            return new[] {@object};
        }
    }
}