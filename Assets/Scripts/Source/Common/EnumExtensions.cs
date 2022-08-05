using System;
using System.Collections.Generic;
using System.Linq;

namespace Source
{
    public static class EnumExtensions
    {
        public static List<T> GetListEnum<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T)).Cast<T>().ToList();
        }
    }
}