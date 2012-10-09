namespace UnitTests
{
    public class TestClass
    {
        public void ThrowException()
        {
            new TestErrorDiscription().Method3();
        }
        
        public void ThrowExceptionWithoutErrorMessage()
        {
            new TestErrorDiscription().Method4();
        }
    }
}