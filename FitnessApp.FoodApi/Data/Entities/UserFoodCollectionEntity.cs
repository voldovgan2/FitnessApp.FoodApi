using System.Collections.Generic;
using FitnessApp.Common.Abstractions.Db.Entities.Collection;
using MongoDB.Bson.Serialization.Attributes;

namespace FitnessApp.FoodApi.Data.Entities
{
    public class UserFoodCollectionEntity : ICollectionEntity
    {
        [BsonId]
        public string UserId { get; set; }
        public Dictionary<string, List<ICollectionItemEntity>> Collection { get; set; }
        public string Partition { get; set; }
    }
}