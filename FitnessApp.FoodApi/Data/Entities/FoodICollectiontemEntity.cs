using System;
using FitnessApp.Common.Abstractions.Db.Entities.Collection;

namespace FitnessApp.FoodApi.Data.Entities;

public class FoodICollectiontemEntity : ICollectionItemEntity
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Calories { get; set; }
    public DateTime AddedDate { get; set; } = DateTime.UtcNow;
}