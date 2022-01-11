
namespace Core.Utilities.Results
{
    public class Result:IResult
    {
        public Result(bool success,string message):this(success)
        {
            Message = message;
        }

        public Result(bool success)
        {
            Success = success;
        }

        //get'ler read-only'dir. Constructor'da set edilebilir.
        public bool Success { get; }
        public string Message { get; }
    }
}
