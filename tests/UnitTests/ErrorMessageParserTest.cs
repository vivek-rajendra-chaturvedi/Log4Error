using Log4Error;
using Log4Error.Utils;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace UnitTests
{
    [TestFixture]
    public class ErrorMessageParserTest
    {
        [Test]
        public void TestIfErrorsAreParsedCorrectly()
        {
            var errorMessagesMap = ErrorMessageParser.Parse("UnitTests");

            Assert.That(errorMessagesMap, Is.Not.Null);
            Assert.That(errorMessagesMap.Count, Is.EqualTo(3));
            Assert.That(errorMessagesMap["UnitTests.TestErrorDiscription.Method1"], Is.EqualTo("Click Make Payment"));
            Assert.That(errorMessagesMap["UnitTests.TestErrorDiscription.Method2"], Is.EqualTo("Fill CreditCardInfo"));
            Assert.That(errorMessagesMap["UnitTests.TestErrorDiscription.Method3"], Is.EqualTo("On Payment Page"));
        }
    }
}
