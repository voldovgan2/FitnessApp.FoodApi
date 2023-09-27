using System.Collections.Generic;
using FitnessApp.Common.Abstractions.Models.BlobImage;
using FitnessApp.Common.Abstractions.Models.Collection;
using FitnessApp.Common.Abstractions.Models.CollectionBlobAggregator;

namespace FitnessApp.FoodApi.Models.Output
{
    public class UserFoodCollectionBlobAggregatorItemModel : ICollectionBlobAggregatorItemModel<ICollectionItemModel>
    {
        public ICollectionItemModel Model { get; set; }
        public List<BlobImageModel> Images { get; set; }
    }
}
