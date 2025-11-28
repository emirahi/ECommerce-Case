namespace ECommerce.Entity;

public class OrderDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int ProductId { get; set; }
    
    public decimal TotalPrice { get; set; }
    public int Quantity { get; set; }
    
    public DateTime Createdate { get; set; }
    public DateTime Updatedate { get; set; }
}