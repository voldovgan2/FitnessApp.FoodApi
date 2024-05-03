using System.Threading.Tasks;
using FitnessApp.Common.Abstractions.Models.Collection;
using FitnessApp.Common.Paged.Models.Output;
using FitnessApp.FoodApi.Models.Input;
using FitnessApp.FoodApi.Models.Output;

namespace FitnessApp.FoodApi.Services.UserFoodAggregator
{
    public interface IUserFoodCollectionFileAggregatorService
    {
        Task<PagedDataModel<UserFoodCollectionFileAggregatorItemModel>> GetFilteredUserFoods(GetFilteredCollectionItemsModel<UserFoodCollectionItemModel> model);
        Task<string> CreateUserFoods(CreateUserFoodCollectionFileAggregatorModel model);
        Task<UserFoodCollectionFileAggregatorItemModel> UpdateUserFoods(UpdateUserFoodCollectionFileAggregatorModel model);
        Task<string> DeleteUserFoods(string userId);
    }
}