using System;
using System.Collections.Generic;
using System.Reflection;

namespace Log4Error.Utils
{
    class ErrorMessageParser
    {
        public static IDictionary<string, string> Parse(string dllName)
        {
            var dictionary = new Dictionary<string, string>();
            
            Assembly assembly;
            try
            {
                assembly = Assembly.Load(dllName);
            }
            catch (Exception)
            {
                return dictionary;
            }

            foreach (var type in assembly.GetTypes())
            {
                foreach (var methodInfo in type.GetMethods())
                {
                    var customAttributes = methodInfo.GetCustomAttributes(typeof(ErrorMessage), false);
                    if (customAttributes.Length > 0)
                    {
                        var fullyQualifiedName = Misc.GetFullyQualifiedName(type.FullName, methodInfo.Name);
                        dictionary[ fullyQualifiedName] = ((ErrorMessage)customAttributes[0]).Message;
                    }
                }
            }
            return dictionary;
        }
    }
}
