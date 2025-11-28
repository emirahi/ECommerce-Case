namespace ECommerce.Business.Response;

public class ResponseObject<T> where T : class, new()
{
    public T? Entity { get; set; }
    public bool Status { get; set; } = false;
    public string? Message { get; set; }
    public List<string> Errors { get; set; } = new List<string>();
}