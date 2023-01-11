using UsersCrud_Back.Features.UsersModule.Users.Entities;

namespace UsersCrud_Back.Features.UsersModule.Users.Repositories
{
    public interface IUserRepository
    {
        Task<UserEntity> GetUserAsync(string userName);
    }
}
