
namespace ECommerce.Entity;

public interface IBaseEntity
{
    public int Id { get; set; }
    public DateTime Createdate { get; set; }
    public DateTime Updatedate { get; set; }
}