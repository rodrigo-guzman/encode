namespace UsersCrud_Back.Features.UsersModule.Users.Interactor
{
    using UsersCrud_Back.Core;
    using UsersCrud_Back.Features.UsersModule.Users.InputOutput;

    public interface IUsersUseCase : IUseCase<UsersInput, UsersOutput>
    {
    }
}
