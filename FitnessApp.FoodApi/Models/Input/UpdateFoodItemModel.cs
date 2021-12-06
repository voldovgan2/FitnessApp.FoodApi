using FitnessApp.Abstractions.Models.Collection;
using System;

namespace FitnessApp.FoodApi.Models.Input
{
    public class UpdateFoodItemModel : ICollectionItemModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public double Calories { get; set; }
        public DateTime? AddedDate { get; set; }
    }
}