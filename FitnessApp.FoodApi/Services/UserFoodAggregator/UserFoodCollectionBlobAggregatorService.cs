using System.Threading.Tasks;
using AutoMapper;
using FitnessApp.Common.Abstractions.Models.Collection;
using FitnessApp.Common.Abstractions.Services.CollectionBlobAggregator;
using FitnessApp.Common.Abstractions.Services.Configuration;
using FitnessApp.Common.Blob;
using FitnessApp.Common.Paged.Models.Output;
using FitnessApp.FoodApi.Models.Input;
using FitnessApp.FoodApi.Models.Output;
using FitnessApp.FoodApi.Services.UserFoodCollection;
using Microsoft.Extensions.Options;

namespace FitnessApp.FoodApi.Services.UserFoodAggregator
{
    public class UserFoodCollectionBlobAggregatorService
        : CollectionBlobAggregatorService<UserFoodCollectionBlobAggregatorModel, UserFoodCollectionBlobAggregatorItemModel, UserFoodCollectionModel, UserFoodCollectionItemModel, CreateUserFoodCollectionBlobAggregatorModel, CreateUserFoodCollectionModel, UpdateUserFoodCollectionBlobAggregatorModel, UpdateUserFoodCollectionModel>,
        IUserFoodCollectionBlobAggregatorService
    {
        public UserFoodCollectionBlobAggregatorService(
            IUserFoodCollectionService collectionService,
            IBlobService blobService,
            IMapper mapper,
            IOptions<CollectionBlobAggregatorSettings> blobAggregatorSettings)
           : base(collectionService, blobService, mapper, blobAggregatorSettings.Value)
        {
        }

        public Task<PagedDataModel<UserFoodCollectionBlobAggregatorItemModel>> GetFilteredUserFoods(GetFilteredCollectionItemsModel<UserFoodCollectionItemModel> model)
        {
            return GetFilteredCollectionItems(model);
        }

        public Task<string> CreateUserFoods(CreateUserFoodCollectionBlobAggregatorModel model)
        {
            return CreateItem(model);
        }

        public Task<UserFoodCollectionBlobAggregatorItemModel> UpdateUserFoods(UpdateUserFoodCollectionBlobAggregatorModel model)
        {
            return UpdateItem(model);
        }

        public Task<string> DeleteUserFoods(string userId)
        {
            return DeleteItem(userId);
        }
    }
}