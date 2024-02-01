namespace SHFTGRAM.ViewModels
{
    public class ResponseResult
    {
        public ResponseResult(string message, bool success)
        {
            Success = success;
            Message = message;
        }
        public bool Success { set; get; }
        public string Message { set; get; }
    }
}
