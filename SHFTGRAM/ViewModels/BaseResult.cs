namespace SHFTGRAM.ViewModels
{
    public class BaseResult<T> : ResponseResult where T : class
    {
        public BaseResult(string message, T data) : base(message,true)
        {
            Message = message;
            Data = data;
        }

        public T Data { get; set; }
    }
}
