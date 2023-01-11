using UsersCrud_Back.Features.UsersModule.Users.Entities;
using UsersCrud_Back.Features.UsersModule.Users.InputOutput;

namespace UsersCrud_Back.Features.UsersModule.Users.Interactor
{
    public class UsersUseCase : IUsersUseCase
    {
        private string errorsNotification;
        public async Task<UsersOutput> ExecuteAsync(UsersInput input)
        {
            IsInputValid(input.User);
            if (string.IsNullOrEmpty(errorsNotification))
            {
                return UsersOutput.CreateWithErrors(errorsNotification);
            }


                var productEntity = await GetProduct(product.Code);

                if (productEntity != null)
                {
                    SetProductAditionalDataFromExternalService(product, productEntity);
                    productsList.Add(productEntity);
                }
                else
                {
                    var createdProduct = await CreateRecommendedProduct(product);
                    SetProductAditionalDataFromExternalService(product, createdProduct);
                    productsList.Add(createdProduct);
                }

            return UsersOutput.CreateWithData(productsList);
        }

        private bool IsInputValid(string store)
        {
            if (string.IsNullOrWhiteSpace(store))
            {
                errorsNotification = "Bad parameters. The store name cannot be null or empty.";
                return false;
            }

            return true;
        }

        private async Task<UserEntity> GetUser(string token, UsersInput input)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                return default;
            }
            var user = await this.repository.GetUserAsync(input.UserName);

            return user;
        }
    }
}
