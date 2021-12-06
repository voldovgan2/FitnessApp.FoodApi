using FitnessApp.Abstractions.Services.Collection;
using FitnessApp.Abstractions.Db.Entities.Collection;
using FitnessApp.Abstractions.Models.Collection;
using Microsoft.Extensions.Logging;
using FitnessApp.Serializer.JsonMapper;
using FitnessApp.FoodApi.Data;

namespace FitnessApp.FoodApi.Services.UserFood
{
    public class FoodService<Entity, CollectionItemEntity, Model, CollectionItemModel, CreateModel, UpdateModel> :
        CollectionService<Entity, CollectionItemEntity, Model, CollectionItemModel, CreateModel, UpdateModel>,
        IFoodService<Entity, CollectionItemEntity, Model, CollectionItemModel, CreateModel, UpdateModel>
        where Entity : ICollectionEntity
        where CollectionItemEntity : ICollectionItemEntity
        where Model : ICollectionModel
        where CollectionItemModel : ISearchableCollectionItemModel
        where CreateModel : ICreateCollectionModel
        where UpdateModel : IUpdateCollectionModel
    {
        public FoodService
        (
            IFoodRepository<Entity, CollectionItemEntity, Model, CollectionItemModel, CreateModel, UpdateModel> repository,
            IJsonMapper mapper,
            ILogger<CollectionService<Entity, CollectionItemEntity, Model, CollectionItemModel, CreateModel, UpdateModel>> log
        )
           : base(repository, mapper, log)
        {
            DefaultCollectionName = "Food";
        }
    }
}