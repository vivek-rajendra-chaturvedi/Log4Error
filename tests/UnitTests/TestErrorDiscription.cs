using System;
using Log4Error;

namespace UnitTests
{
    public class TestErrorDiscription
    {
        [ErrorMessage("Click Make Payment")]
        public void Method1()
        {
            throw new Exception();
        }

        [ErrorMessage("Fill CreditCardInfo")]
        public void Method2()
        {
            Method1();
        }

        [ErrorMessage("On Payment Page")]
        public void Method3()
        {
            Method2();
        }

        public void Method4()
        {
            throw new Exception();
        }
    }
}