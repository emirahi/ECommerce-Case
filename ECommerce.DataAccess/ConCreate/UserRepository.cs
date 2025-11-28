using ECommerce.DataAccess.Abstract;
using ECommerce.DataAccess.Context;
using ECommerce.Entity;

namespace ECommerce.DataAccess.ConCreate;

public class UserRepository: BaseRepository<User>, IUserRepository
{
    public UserRepository(ECommerceDBContext context):base(context)
    {
    }

}