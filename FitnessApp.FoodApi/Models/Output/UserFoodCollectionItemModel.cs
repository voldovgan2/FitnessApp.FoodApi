using System;
using FitnessApp.Common.Abstractions.Models.Collection;

namespace FitnessApp.FoodApi.Models.Output
{
    public class UserFoodCollectionItemModel : ICollectionItemModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Calories { get; set; }
        public DateTime AddedDate { get; set; }
    }
}