using System;

namespace FitnessApp.FoodApi.Contracts.Output
{
    public class FoodItemContract
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public double Calories { get; set; }
        public DateTime AddedDate { get; set; }
    }
}