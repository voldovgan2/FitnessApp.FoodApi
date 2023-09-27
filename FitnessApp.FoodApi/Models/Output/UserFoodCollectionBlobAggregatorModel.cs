using System.Collections.Generic;
using FitnessApp.Common.Abstractions.Models.Collection;
using FitnessApp.Common.Abstractions.Models.CollectionBlobAggregator;

namespace FitnessApp.FoodApi.Models.Output
{
    public class UserFoodCollectionBlobAggregatorModel : ICollectionBlobAggregatorModel
    {
        public string UserId { get; set; }
        public Dictionary<string, List<ICollectionBlobAggregatorItemModel<ICollectionItemModel>>> Collection { get; set; }
    }
}