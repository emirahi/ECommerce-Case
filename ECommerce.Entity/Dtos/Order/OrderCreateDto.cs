namespace ECommerce.Entity;

public class OrderCreateDto
{
    public int UserId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}