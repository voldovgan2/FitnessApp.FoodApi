using System.Collections.Generic;
using FitnessApp.Common.Abstractions.Models.Collection;

namespace FitnessApp.FoodApi.Models.Output;

public class UserFoodCollectionModel : ICollectionModel
{
    public string UserId { get; set; }
    public Dictionary<string, List<ICollectionItemModel>> Collection { get; set; }
}
