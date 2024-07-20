using FitnessApp.Common.Abstractions.Db.Repository.Collection;
using FitnessApp.FoodApi.Models.Input;
using FitnessApp.FoodApi.Models.Output;

namespace FitnessApp.FoodApi.Data;

public interface IFoodRepository :
    ICollectionRepository<
        UserFoodCollectionModel,
        UserFoodCollectionItemModel,
        CreateUserFoodCollectionModel,
        UpdateUserFoodCollectionModel>;