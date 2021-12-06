using FitnessApp.Abstractions.Db.Entities.Collection;
using FitnessApp.Abstractions.Models.Collection;
using FitnessApp.Abstractions.Services.Collection;

namespace FitnessApp.FoodApi.Services.UserFood
{
    public interface IFoodService<Entity, CollectionItemEntity, Model, CollectionItemModel, CreateModel, UpdateModel>
        : ICollectionService<Entity, CollectionItemEntity, Model, CollectionItemModel, CreateModel, UpdateModel>
        where Entity : ICollectionEntity
        where CollectionItemEntity : ICollectionItemEntity
        where Model : ICollectionModel
        where CollectionItemModel : ISearchableCollectionItemModel
        where CreateModel : ICreateCollectionModel
        where UpdateModel : IUpdateCollectionModel
    {
        
    }
}