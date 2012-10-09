using System;
using Log4Error;
using Log4Error.Utils;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace UnitTests
{
    [TestFixture]
    public class StackTraceWrapperTest
    {
        [Test]
        public void ShouldBeAbleToGetFullNameOfMethodsFromStackTrace()
        {
            try
            {
                new TestClass().ThrowException();
            }
            catch (Exception ex)
            {
                var stackTraceWrapper = new StackTraceWrapper(ex);
                var fullMethodNames = stackTraceWrapper.GetFullMethodNames();
                Assert.That(fullMethodNames, Has.Member("UnitTests.TestErrorDiscription.Method1"));
            }
        }
    }
}