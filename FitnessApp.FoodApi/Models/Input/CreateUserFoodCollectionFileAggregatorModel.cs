using System.Collections.Generic;
using FitnessApp.Common.Abstractions.Models.Collection;
using FitnessApp.Common.Abstractions.Models.CollectionFileAggregator;

namespace FitnessApp.FoodApi.Models.Input;

public class CreateUserFoodCollectionFileAggregatorModel : ICreateCollectionFileAggregatorModel
{
    public string UserId { get; set; }
    public Dictionary<string, IEnumerable<ICollectionItemModel>> Collection { get; set; }
}