using UsersCrud_Back.Features.UsersModule.Users.Entities;
using UsersCrud_Back.Models;
using Microsoft.EntityFrameworkCore;
using UsersCrud_Back.Features.UsersModule.Users.Repositories;
using UsersCrud_Back.Features.UsersModule.Users.Data.Mappers;
using UsersCrud_Back.Features.UsersModule.Users.Data.DTOs;
    
namespace UsersCrud_Back.Features.UsersModule.Users.Data
{
    public class UsersEFRepository : IUserRepository
    {
        UsersEncodeContext dbContext;
        public UsersEFRepository(UsersEncodeContext context)
        {
            dbContext = context;
        }

        public Task<UserEntity> GetUserAsync(string userName)
        {
            using var dbContext = new UsersEncodeContext();
            var user = dbContext.Usuarios.FirstOrDefault(u => u.Nombre == userName);
            return Task.FromResult(user.ToEntity());
        }
    }
}
