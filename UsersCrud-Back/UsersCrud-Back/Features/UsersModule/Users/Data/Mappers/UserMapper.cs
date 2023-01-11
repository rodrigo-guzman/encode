namespace UsersCrud_Back.Features.UsersModule.Users.Data.Mappers
{
    using UsersCrud_Back.Features.UsersModule.Users.Data.DTOs;
    using UsersCrud_Back.Features.UsersModule.Users.Entities;

    public static class UserMapper
    {
        public static UserEntity ToEntity(this User userDTO)
        {
            if (userDTO == null)
            {
                return null;
            }

            return new UserEntity
            {
                Id = userDTO.Id,
                Name = userDTO.Name,
                LastName = userDTO.LastName,
                Email = userDTO.Email,
                BirthDate = userDTO.BirthDate,
                Phone = userDTO.Phone,
                IdCountry = userDTO.IdCountry,
                ReceiveInformation = userDTO.ReceiveInformation,
            };
        }
    }
}
