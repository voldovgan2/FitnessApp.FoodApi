using FitnessApp.Common.Paged.Contracts.Input;

namespace FitnessApp.FoodApi.Contracts.Input
{
    public class GetUserFoodsContract : GetPagedDataContract
    {
        public string UserId { get; set; }
    }
}