using System;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using FitnessApp.Common.Paged.Contracts.Output;
using FitnessApp.FoodApi.Contracts.Input;
using FitnessApp.FoodApi.Contracts.Output;
using FitnessApp.FoodApi.Models.Input;
using FitnessApp.FoodApi.Services.UserFoodAggregator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.FoodApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]

    // [Authorize]
    public class FoodController : Controller
    {
        private readonly IUserFoodCollectionBlobAggregatorService _foodService;
        private readonly IMapper _mapper;

        public FoodController(
            IUserFoodCollectionBlobAggregatorService foodService,
            IMapper mapper)
        {
            _foodService = foodService;
            _mapper = mapper;
        }

        [HttpGet("GetFood")]
        public async Task<IActionResult> GetFoodAsync([FromQuery] GetUserFoodsContract contract)
        {
            var model = _mapper.Map<GetUserFoodsFilteredCollectionItemsModel>(contract);
            var data = await _foodService.GetFilteredUserFoods(model);
            if (data != null)
            {
                var result = new UserFoodsContract
                {
                    UserId = contract.UserId,
                    Foods = _mapper.Map<PagedDataContract<FoodItemContract>>(data)
                };
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("CreateFoods")]
        public async Task<IActionResult> CreateFoodsAsync([FromBody] CreateUserFoodContract contract)
        {
            var model = _mapper.Map<CreateUserFoodCollectionBlobAggregatorModel>(contract);
            var created = await _foodService.CreateUserFoods(model);
            if (created != null)
            {
                var result = created;
                return Ok(result);
            }
            else
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut("AddFood")]
        public async Task<IActionResult> AddFoodAsync([FromBody] AddUserFoodContract contract)
        {
            var updateCollectionBlobAggregatorUserFoodModel = _mapper.Map<UpdateUserFoodCollectionBlobAggregatorModel>(contract);
            var updated = await _foodService.UpdateUserFoods(updateCollectionBlobAggregatorUserFoodModel);
            if (updated != null)
            {
                var result = _mapper.Map<FoodItemContract>(updated);
                return Ok(result);
            }
            else
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut("EditFood")]
        public async Task<IActionResult> EditFoodAsync([FromBody] UpdateUserFoodContract contract)
        {
            var updateCollectionBlobAggregatorUserFoodModel = _mapper.Map<UpdateUserFoodCollectionBlobAggregatorModel>(contract);
            var updated = await _foodService.UpdateUserFoods(updateCollectionBlobAggregatorUserFoodModel);
            if (updated != null)
            {
                var result = _mapper.Map<FoodItemContract>(updated);
                return Ok(result);
            }
            else
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete("RemoveFood/{userId}/{foodId}")]
        public async Task<IActionResult> RemoveFoodAsync([FromRoute] string userId, [FromRoute] string foodId)
        {
            var updateCollectionBlobAggregatorUserFoodModel = _mapper.Map<UpdateUserFoodCollectionBlobAggregatorModel>(new Tuple<string, string>(userId, foodId));
            var updated = await _foodService.UpdateUserFoods(updateCollectionBlobAggregatorUserFoodModel);
            if (updated != null)
            {
                var result = updated.Model.Id;
                return Ok(result);
            }
            else
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete("DeleteFoods/{userId}")]
        public async Task<IActionResult> DeleteFoods([FromRoute] string userId)
        {
            var deleted = await _foodService.DeleteUserFoods(userId);
            if (deleted != null)
            {
                return Ok(deleted);
            }
            else
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}