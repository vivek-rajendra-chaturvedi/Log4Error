using System;
using System.Collections.Generic;
using System.Linq;
using Log4Error.Utils;

namespace Log4Error
{
    public class Log4Error
    {
        private static IDictionary<string, string> ErrorMap = new Dictionary<string, string>();

        public Log4Error()
        {
            var dllList = Log4ErrorConfigSectionReader.GetDllList();
            foreach (var dll in dllList)
            {
                var tempDictionary = ErrorMessageParser.Parse(dll);
                ErrorMap = ErrorMap.Concat(tempDictionary).ToDictionary(x => x.Key, x=> x.Value);
            }
        }

        public static string GetErrorMessage(Exception exception)
        {
            var fullMethodNames = new StackTraceWrapper(exception).GetFullMethodNames();

            var messages = fullMethodNames.FindAll(name => ErrorMap.ContainsKey(name)).Select(name => ErrorMap[name]).ToList();
            
            messages.Reverse();

            return String.Join(" -> ", messages);
        }
    }
}