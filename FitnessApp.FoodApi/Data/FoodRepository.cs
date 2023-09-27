﻿using AutoMapper;
using FitnessApp.Common.Abstractions.Db.DbContext;
using FitnessApp.Common.Abstractions.Db.Repository.Collection;
using FitnessApp.FoodApi.Data.Entities;
using FitnessApp.FoodApi.Models.Input;
using FitnessApp.FoodApi.Models.Output;

namespace FitnessApp.FoodApi.Data
{
    public class FoodRepository
        : CollectionRepository<UserFoodCollectionEntity, FoodICollectiontemEntity, UserFoodCollectionModel, UserFoodCollectionItemModel, CreateUserFoodCollectionModel, UpdateUserFoodCollectionModel>,
        IFoodRepository
    {
        public FoodRepository(
            IDbContext<UserFoodCollectionEntity> context,
            IMapper mapper)
            : base(context, mapper)
        { }
    }
}