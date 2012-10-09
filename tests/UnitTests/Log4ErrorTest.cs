using System;
using Log4Error.Utils;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace UnitTests
{
    [TestFixture]
    public class Log4ErrorTest
    {
        public Log4ErrorTest()
        {
            new Log4Error.Log4Error();
        }

        [Test]
        public void ShouldReadDllsFromConfiguration()
        {
            var dllList = Log4ErrorConfigSectionReader.GetDllList();

            Assert.That(dllList, Is.Not.Null);
            Assert.That(dllList.Count, Is.EqualTo(2));
            Assert.That(dllList, Has.Member("UnitTests"));
            Assert.That(dllList, Has.Member("Log4Error"));
        }

        [Test]
        public void ShouldBeAbleToCreateReleventErrorMessage()
        {
            try
            {
                new TestClass().ThrowException();
            }
            catch (Exception ex)
            {
                var errorMessage = Log4Error.Log4Error.GetErrorMessage(ex);
                Assert.That(errorMessage, Is.EqualTo("On Payment Page -> Fill CreditCardInfo -> Click Make Payment"));
            }
        }

        [Test]
        public void ShouldNotCreateReleventErrorMessageIfNoAttributeExists()
        {
            try
            {
                new TestClass().ThrowExceptionWithoutErrorMessage();
            }
            catch (Exception ex)
            {
                var errorMessage = Log4Error.Log4Error.GetErrorMessage(ex);
                Assert.That(errorMessage, Is.EqualTo(""));
            }
        }
    }
}
