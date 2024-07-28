using FitnessApp.Common.Paged.Contracts.Input;

namespace FitnessApp.FoodApi.Contracts.Input;

public class GetUserFoodsContract : GetPagedSearchDataContract
{
    public string UserId { get; set; }
}