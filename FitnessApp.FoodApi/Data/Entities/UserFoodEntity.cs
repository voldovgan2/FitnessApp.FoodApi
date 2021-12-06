using FitnessApp.Abstractions.Db.Entities.Collection;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace FitnessApp.FoodApi.Data.Entities
{
    public class UserFoodEntity : ICollectionEntity
    {
        [BsonId]
        public string UserId { get; set; }
        public Dictionary<string, List<ICollectionItemEntity>> Collection { get; set; }
    }
}