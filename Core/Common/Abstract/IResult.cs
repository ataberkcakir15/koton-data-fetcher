namespace Core.Common.Abstract
{
    public class IResult<T>
    {
        bool IsSuccess {  get; set; }
        string? Message {  get; set; }
        T Data { get; set; }
    }
}
