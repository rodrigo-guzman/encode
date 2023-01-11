namespace UsersCrud_Back.Features.UsersModule.Users.InputOutput
{
    using UsersCrud_Back.Core;
    using UsersCrud_Back.Features.UsersModule.Users.Entities;

    public class UsersOutput : IUseCaseOutputDomain<List<UserEntity>>
    {
        private UsersOutput()
        {
        }

        public List<UserEntity> Data { get; private set; }

        public string Notification { get; private set; }

        public static UsersOutput CreateWithData(List<UserEntity> users)
        {
            return new UsersOutput
            {
                Data = users,
            };
        }

        public static UsersOutput CreateWithErrors(string notification)
        {
            return new UsersOutput
            {
                Notification = notification,
            };
        }

        public dynamic ToOutput()
        {
            List<object> users = new List<object>();

            foreach (var user in Data)
            {
                var userObj = new
                {
                    id = user.Id,
                    nombre = user.Name,
                    apellido = user.LastName,
                    correoElectronico = user.Email,
                    fechaNacimiento = user.BirthDate,
                    telefono = user.Phone,
                    pais = user.IdCountry,
                    recibirInformacion = user.ReceiveInformation,
                };
                users.Add(userObj);
            }
            return users;
        }
    }
}
