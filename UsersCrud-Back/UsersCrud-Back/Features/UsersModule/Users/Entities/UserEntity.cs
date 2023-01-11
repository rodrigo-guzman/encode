namespace UsersCrud_Back.Features.UsersModule.Users.Entities
{
    using System;

    public class UserEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public DateTime BirthDate { get; set; }

        public int? Phone { get; set; }

        public string IdCountry { get; set; }

        public bool ReceiveInformation { get; set; }
    }
}
