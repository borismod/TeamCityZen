using System;
using System.Collections.Generic;

namespace TeamCityZen
{
    public static class StringExtensions
    {
        private const string Space = " ";

        public static string Join(this IEnumerable<string> strings, string separator = Space)
        {
            return String.Join(separator, strings);
        } 

        public static string Join(this string[] strings, string separator = Space)
        {
            return String.Join(separator, strings);
        } 
    }
}