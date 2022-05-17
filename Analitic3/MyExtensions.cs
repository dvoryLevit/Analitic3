using System;
using System.Collections.Generic;
using System.Text;
//using ExtensionMethods;
namespace Analitic3
{
    public static class MyExtensions
    {
        public static Boolean IsExists(this string strSource, string str1, string str2)
        {
            if (strSource.Contains(str1) && strSource.Contains(str2))
                return true;
            return false;
        }
        public static Boolean IsExists(this string strSource, string str1, string str2, string str3)
        {
            if (strSource.Contains(str1) && strSource.Contains(str2) && strSource.Contains(str3))
                return true;
            return false;
        }
    }
}
