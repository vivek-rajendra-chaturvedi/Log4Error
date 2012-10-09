using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Log4Error.Utils
{
    class StackTraceWrapper
    {
        readonly StackTrace stackTrace;

        public StackTraceWrapper(Exception exception)
        {
            stackTrace = new StackTrace(exception);
        }

        public List<string> GetFullMethodNames()
        {
            return stackTrace.GetFrames().Select(frame=>
                                                     {
                                                         var methodBase = frame.GetMethod();
                                                         return Misc.GetFullyQualifiedName(methodBase.ReflectedType.FullName, methodBase.Name);
                                                     }).ToList();
        }
    }
}