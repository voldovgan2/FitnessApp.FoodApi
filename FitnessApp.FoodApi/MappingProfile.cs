using System;
using System.Collections.Generic;
using FitnessApp.Common.Abstractions.Db.Enums.Collection;
using FitnessApp.Common.Abstractions.Models.Collection;
using FitnessApp.Common.Abstractions.Models.FileImage;
using FitnessApp.Common.Mapping;
using FitnessApp.FoodApi.Contracts.Input;
using FitnessApp.FoodApi.Contracts.Output;
using FitnessApp.FoodApi.Data.Entities;
using FitnessApp.FoodApi.Models.Input;
using FitnessApp.FoodApi.Models.Output;

namespace FitnessApp.FoodApi;

public class MappingProfile<TContract, TModel> : PagedMappingProfile<TContract, TModel>
    where TContract : class
    where TModel : class
{
    public MappingProfile()
    {
        #region Contract 2 GenericFileAggregatorModel
        CreateMap<GetUserFoodsContract, GetUserFoodsFilteredCollectionItemsModel>()
            .ForMember(m => m.CollectionName, c => c.MapFrom(c => _defaultCollectionName))
            .AfterMap((c, m) =>
            {
                m.Predicate = new Func<UserFoodCollectionItemModel, bool>(item =>
                {
                    return string.IsNullOrWhiteSpace(c.Search)
                        || item.Name.Contains(c.Search)
                        || item.Description.Contains(c.Search);
                });
            });
        CreateMap<CreateUserFoodContract, CreateUserFoodCollectionFileAggregatorModel>()
            .ForMember(m => m.Collection, c => c.MapFrom(c => new Dictionary<string, IEnumerable<CreateUserFoodCollectionFileAggregatorModel>>
            {
                { _defaultCollectionName, new List<CreateUserFoodCollectionFileAggregatorModel>() }
            }));
        CreateMap<AddUserFoodContract, UpdateUserFoodCollectionFileAggregatorModel>()
            .ForMember(m => m.Action, c => c.MapFrom(c => UpdateCollectionAction.Add))
            .ForMember(m => m.CollectionName, c => c.MapFrom(c => _defaultCollectionName))
            .ForMember(m => m.Model, c => c.MapFrom(c => ConstructUserFoodCollectionFileAggregatorItemModel(Guid.Empty.ToString(), c.Name, c.Calories, c.Description, c.Photo)));
        CreateMap<UpdateUserFoodContract, UpdateUserFoodCollectionFileAggregatorModel>()
            .ForMember(m => m.Action, c => c.MapFrom(c => UpdateCollectionAction.Update))
            .ForMember(m => m.CollectionName, c => c.MapFrom(c => _defaultCollectionName))
            .ForMember(m => m.Model, c => c.MapFrom(c => ConstructUserFoodCollectionFileAggregatorItemModel(c.Id, c.Name, c.Calories, c.Description, c.Photo)));
        CreateMap<Tuple<string, string>, UpdateUserFoodCollectionFileAggregatorModel>()
            .ForMember(m => m.Action, c => c.MapFrom(c => UpdateCollectionAction.Remove))
            .ForMember(m => m.CollectionName, c => c.MapFrom(c => _defaultCollectionName))
            .ForMember(m => m.UserId, c => c.MapFrom(c => c.Item1))
            .ForMember(m => m.Model, c => c.MapFrom(c => ConstructUserFoodCollectionFileAggregatorItemModel(c.Item2, default, default, default, default)));
        #endregion

        #region CollectionFileAggregatorModel 2 CollectionModel

        CreateMap<CreateUserFoodCollectionFileAggregatorModel, CreateUserFoodCollectionModel>();
        CreateMap<UpdateUserFoodCollectionFileAggregatorModel, UpdateUserFoodCollectionModel>()
            .ForMember(m1 => m1.Model, m2 => m2.MapFrom(m2 => m2.Model.Model));

        #endregion

        #region CollectionModel 2 CollectionEntity
        CreateMap<CreateUserFoodCollectionModel, UserFoodCollectionEntity>();
        #endregion

        #region CollectionItemModel 2 CollectionItemEntity
        CreateMap<UserFoodCollectionItemModel, FoodICollectiontemEntity>();
        #endregion

        #region CollectionItemEntity 2 CollectionItemModel
        CreateMap<FoodICollectiontemEntity, UserFoodCollectionItemModel>();
        #endregion

        #region CollectionEntity 2 CollectionModel
        CreateMap<UserFoodCollectionEntity, UserFoodCollectionModel>()
            .ForMember(m => m.Collection, c => c.Ignore())
            .AfterMap((e, m) =>
            {
                m.Collection = new Dictionary<string, List<ICollectionItemModel>>();
                foreach (var kvp in e.Collection)
                {
                    var list = new List<ICollectionItemModel>();
                    foreach (var entity in kvp.Value)
                    {
                        var foodEntity = entity as FoodICollectiontemEntity;
                        list.Add(new UserFoodCollectionItemModel
                        {
                            Id = foodEntity.Id,
                            Name = foodEntity.Name,
                            Description = foodEntity.Description,
                            Calories = foodEntity.Calories,
                            AddedDate = foodEntity.AddedDate
                        });
                    }

                    m.Collection.Add(kvp.Key, list);
                }
            });
        #endregion

        #region CollectionFileAggregatorModel 2 Contract
        CreateMap<UserFoodCollectionFileAggregatorItemModel, FoodItemContract>()
            .ForMember(c => c.Id, m => m.MapFrom(m => m.Model.Id))
            .AfterMap((m, c) =>
            {
                var userFoodCollectionItemModel = m.Model as UserFoodCollectionItemModel;
                c.Name = userFoodCollectionItemModel.Name;
                c.Description = userFoodCollectionItemModel.Description;
                c.Calories = userFoodCollectionItemModel.Calories;
                c.AddedDate = userFoodCollectionItemModel.AddedDate;
                c.Photo = m.Images.Find(i => i.FieldName == "Photo")?.Value;
            });
        #endregion
    }

    private readonly string _defaultCollectionName = "Food";

    private DateTime GetDateTimeForMapping()
    {
        return DateTime.UtcNow;
    }

    private UserFoodCollectionFileAggregatorItemModel ConstructUserFoodCollectionFileAggregatorItemModel(string id, string name, double calories, string description, string photo)
    {
        return new UserFoodCollectionFileAggregatorItemModel
        {
            Model = new UserFoodCollectionItemModel
            {
                Id = id,
                Name = name,
                AddedDate = GetDateTimeForMapping(),
                Calories = calories,
                Description = description
            },
            Images =
            [
                new FileImageModel
                {
                    FieldName = "Photo",
                    Value = photo
                },
            ]
        };
    }
}
