
namespace MatchApi.Domain.DTOs
{
    public class ResponseResult<T>
    {
        public T Data {  get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public Error Error { get; set; }
    }

    public class Error
    {
        public string Message { get; set; }
        public string StatusCode { get; set; }
    }
}
