namespace UsersCrud_Back.Core
{
    using System.Collections.Generic;

    public interface IUseCaseOutput
    {
        ICollection<string> Errors { get; }
        bool HasErrors();
        dynamic ToOutput();
        dynamic ToError();
    }

    public interface IUseCaseOutputDomain<T>
    {
        T Data { get; }
    }
}
