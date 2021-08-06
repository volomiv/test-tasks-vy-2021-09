namespace Forbytes.Core
{
    public class ErrorModel
    {
        public string Error { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return $"Error: '{Error}', Message: '{Message}'";
        }
    }
}