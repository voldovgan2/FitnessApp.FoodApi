using FitnessApp.Abstractions.Models.Collection;
using System;

namespace FitnessApp.FoodApi.Models.Output
{
    public class FoodItemModel : ISearchableCollectionItemModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public double Calories { get; set; }
        public DateTime AddedDate { get; set; }

        public bool Matches(string search)
        {
            bool result = true;
            if (!string.IsNullOrWhiteSpace(search))
            {
                result = Name.IndexOf(search) != -1
                    || Description.IndexOf(search) != -1;
            }
            return result;
        }
    }
}