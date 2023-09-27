using System.Collections.Generic;
using FitnessApp.Common.Abstractions.Models.Collection;

namespace FitnessApp.FoodApi.Models.Input
{
    public class CreateUserFoodCollectionModel : ICreateCollectionModel
    {
        public string UserId { get; set; }
        public Dictionary<string, IEnumerable<ICollectionItemModel>> Collection { get; set; }
    }
}
