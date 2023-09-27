using System.Threading.Tasks;
using FitnessApp.Common.Abstractions.Models.Collection;
using FitnessApp.Common.Paged.Models.Output;
using FitnessApp.FoodApi.Models.Input;
using FitnessApp.FoodApi.Models.Output;

namespace FitnessApp.FoodApi.Services.UserFoodAggregator
{
    public interface IUserFoodCollectionBlobAggregatorService
    {
        Task<PagedDataModel<UserFoodCollectionBlobAggregatorItemModel>> GetFilteredUserFoods(GetFilteredCollectionItemsModel<UserFoodCollectionItemModel> model);
        Task<string> CreateUserFoods(CreateUserFoodCollectionBlobAggregatorModel model);
        Task<UserFoodCollectionBlobAggregatorItemModel> UpdateUserFoods(UpdateUserFoodCollectionBlobAggregatorModel model);
        Task<string> DeleteUserFoods(string userId);
    }
}