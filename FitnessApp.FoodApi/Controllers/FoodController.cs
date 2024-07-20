using System;
using System.Threading.Tasks;
using AutoMapper;
using FitnessApp.Common.Paged.Contracts.Output;
using FitnessApp.FoodApi.Contracts.Input;
using FitnessApp.FoodApi.Contracts.Output;
using FitnessApp.FoodApi.Models.Input;
using FitnessApp.FoodApi.Services.UserFoodAggregator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.FoodApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]

[Authorize]
public class FoodController(IUserFoodCollectionFileAggregatorService foodService, IMapper mapper) : Controller
{
    [HttpGet("GetFood")]
    public async Task<UserFoodsContract> GetFoodAsync([FromQuery] GetUserFoodsContract contract)
    {
        var model = mapper.Map<GetUserFoodsFilteredCollectionItemsModel>(contract);
        var response = await foodService.GetFilteredUserFoods(model);
        return new UserFoodsContract
        {
            UserId = contract.UserId,
            Foods = mapper.Map<PagedDataContract<FoodItemContract>>(response)
        };
    }

    [HttpPost("CreateFoods")]
    public async Task<string> CreateFoodsAsync([FromBody] CreateUserFoodContract contract)
    {
        var model = mapper.Map<CreateUserFoodCollectionFileAggregatorModel>(contract);
        var response = await foodService.CreateUserFoods(model);
        return response;
    }

    [HttpPut("AddFood")]
    public async Task<FoodItemContract> AddFoodAsync([FromBody] AddUserFoodContract contract)
    {
        var updateCollectionFileAggregatorUserFoodModel = mapper.Map<UpdateUserFoodCollectionFileAggregatorModel>(contract);
        var response = await foodService.UpdateUserFoods(updateCollectionFileAggregatorUserFoodModel);
        return mapper.Map<FoodItemContract>(response);
    }

    [HttpPut("EditFood")]
    public async Task<FoodItemContract> EditFoodAsync([FromBody] UpdateUserFoodContract contract)
    {
        var updateCollectionFileAggregatorUserFoodModel = mapper.Map<UpdateUserFoodCollectionFileAggregatorModel>(contract);
        var response = await foodService.UpdateUserFoods(updateCollectionFileAggregatorUserFoodModel);
        return mapper.Map<FoodItemContract>(response);
    }

    [HttpDelete("RemoveFood/{userId}/{foodId}")]
    public async Task<string> RemoveFoodAsync([FromRoute] string userId, [FromRoute] string foodId)
    {
        var updateCollectionFileAggregatorUserFoodModel = mapper.Map<UpdateUserFoodCollectionFileAggregatorModel>(new Tuple<string, string>(userId, foodId));
        var response = await foodService.UpdateUserFoods(updateCollectionFileAggregatorUserFoodModel);
        return response.Model.Id;
    }

    [HttpDelete("DeleteFoods/{userId}")]
    public async Task<string> DeleteFoods([FromRoute] string userId)
    {
        var response = await foodService.DeleteUserFoods(userId);
        return response;
    }
}