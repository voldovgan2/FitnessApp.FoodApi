using System.Collections.Generic;
using FitnessApp.Common.Abstractions.Models.Collection;
using FitnessApp.Common.Abstractions.Models.CollectionBlobAggregator;

namespace FitnessApp.FoodApi.Models.Input
{
    public class CreateUserFoodCollectionBlobAggregatorModel : ICreateCollectionBlobAggregatorModel
    {
        public string UserId { get; set; }
        public Dictionary<string, IEnumerable<ICollectionItemModel>> Collection { get; set; }
    }
}