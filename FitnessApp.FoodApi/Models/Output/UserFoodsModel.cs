﻿using FitnessApp.Abstractions.Models.Collection;
using System.Collections.Generic;

namespace FitnessApp.FoodApi.Models.Output
{
    public class UserFoodsModel : ICollectionModel
    {
        public string UserId { get; set; }
        public Dictionary<string, IEnumerable<ICollectionItemModel>> Collection { get; set; }
    }
}