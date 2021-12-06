using FitnessApp.Abstractions.Models.Collection;
using System.Collections.Generic;

namespace FitnessApp.FoodApi.Models.Input
{
    public class CreateUserFoodModel : ICreateCollectionModel
    {
        public string UserId { get; set; }
        public Dictionary<string, IEnumerable<ICollectionItemModel>> Collection { get; set; }
    }
}