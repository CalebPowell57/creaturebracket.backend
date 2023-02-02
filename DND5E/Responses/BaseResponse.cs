namespace DND5E.Service.Responses
{
    public class BaseResponse<T>
    {
        public long Count { get; set; }
        public IEnumerable<T> Results { get; set; }
    }
}
