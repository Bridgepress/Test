namespace Test.Domain.Exceptions
{
    public class TestSystemHttpException(string message) : TestSystemException(message)
    {
        public TestSystemHttpException(int code, string message) : this(message)
        {
            Code = code;
        }

        public int Code { get; init; }
    }
}
