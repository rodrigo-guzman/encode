namespace UsersCrud_Back.Core
{
    using System.Threading.Tasks;

    public interface IUseCase<TInput, TOutput>
    {
        Task<TOutput> ExecuteAsync(TInput input);
    }
}