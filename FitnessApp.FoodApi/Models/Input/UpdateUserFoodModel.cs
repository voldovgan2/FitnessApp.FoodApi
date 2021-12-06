using FitnessApp.Abstractions.Db.Enums.Collection;
using FitnessApp.Abstractions.Models.Collection;

namespace FitnessApp.FoodApi.Models.Input
{
    public class UpdateUserFoodModel : IUpdateCollectionModel
    {
        public string UserId { get; set; }
        public string CollectionName { get; set; }
        public UpdateCollectionAction Action { get; set; }
        public ICollectionItemModel Model { get; set; }
     }
}