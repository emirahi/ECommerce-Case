
namespace ECommerce.Entity;

public class Order:IBaseEntity
{
    public int Id { get; set; }
    public DateTime Createdate { get; set; }
    public DateTime Updatedate { get; set; }

    public int UserId { get; set; }
    public int ProductId { get; set; }
    public decimal TotalPrice { get; set; }
    public int Quantity { get; set; }
}