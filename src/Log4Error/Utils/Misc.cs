using System;

namespace Log4Error.Utils
{
    class Misc
    {
        public static string GetFullyQualifiedName(string fullClassName, string methodName)
        {
            return String.Format("{0}.{1}", fullClassName, methodName);
        }
    }
}
