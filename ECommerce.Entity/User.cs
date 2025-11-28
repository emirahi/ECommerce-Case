
namespace ECommerce.Entity;

public class User:IBaseEntity
{
    public int Id { get; set; }
    public string name { get; set; }
    public string email { get; set; }
    public DateTime Createdate { get; set; }
    public DateTime Updatedate { get; set; }

    
}