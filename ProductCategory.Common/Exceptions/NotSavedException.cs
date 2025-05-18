namespace ProductCategory.Common.Exceptions
{
    public class NotSavedException: Exception
    {
        public NotSavedException(string message):base(message)
        {
        }
    }
}
