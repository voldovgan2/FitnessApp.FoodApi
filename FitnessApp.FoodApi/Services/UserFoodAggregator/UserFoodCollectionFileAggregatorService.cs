using System.Threading.Tasks;
using AutoMapper;
using FitnessApp.Common.Abstractions.Models.Collection;
using FitnessApp.Common.Abstractions.Services.CollectionFileAggregator;
using FitnessApp.Common.Abstractions.Services.Configuration;
using FitnessApp.Common.Files;
using FitnessApp.Common.Paged.Models.Output;
using FitnessApp.FoodApi.Models.Input;
using FitnessApp.FoodApi.Models.Output;
using FitnessApp.FoodApi.Services.UserFoodCollection;
using Microsoft.Extensions.Options;

namespace FitnessApp.FoodApi.Services.UserFoodAggregator
{
    public class UserFoodCollectionFileAggregatorService(
        IUserFoodCollectionService collectionService,
        IFilesService filesService,
        IMapper mapper,
        IOptions<CollectionFileAggregatorSettings> filesAggregatorSettings) : CollectionFileAggregatorService<
            UserFoodCollectionFileAggregatorModel,
            UserFoodCollectionFileAggregatorItemModel,
            UserFoodCollectionModel,
            UserFoodCollectionItemModel,
            CreateUserFoodCollectionFileAggregatorModel,
            CreateUserFoodCollectionModel,
            UpdateUserFoodCollectionFileAggregatorModel,
            UpdateUserFoodCollectionModel>(collectionService, filesService, mapper, filesAggregatorSettings.Value),
        IUserFoodCollectionFileAggregatorService
    {
        public Task<PagedDataModel<UserFoodCollectionFileAggregatorItemModel>> GetFilteredUserFoods(GetFilteredCollectionItemsModel<UserFoodCollectionItemModel> model)
        {
            return GetFilteredCollectionItems(model);
        }

        public Task<string> CreateUserFoods(CreateUserFoodCollectionFileAggregatorModel model)
        {
            return CreateItem(model);
        }

        public Task<UserFoodCollectionFileAggregatorItemModel> UpdateUserFoods(UpdateUserFoodCollectionFileAggregatorModel model)
        {
            return UpdateItem(model);
        }

        public Task<string> DeleteUserFoods(string userId)
        {
            return DeleteItem(userId);
        }
    }
}