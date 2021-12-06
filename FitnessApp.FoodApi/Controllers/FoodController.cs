using FitnessApp.Abstractions.Db.Enums.Collection;
using FitnessApp.FoodApi.Contracts.Input;
using FitnessApp.FoodApi.Contracts.Output;
using FitnessApp.FoodApi.Data.Entities;
using FitnessApp.FoodApi.Models.Input;
using FitnessApp.FoodApi.Models.Output;
using FitnessApp.FoodApi.Services.UserFood;
using FitnessApp.Paged.Contracts.Output;
using FitnessApp.Serializer.JsonMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace FitnessApp.FoodApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Authorize]
    public class FoodController : Controller
    {
        private readonly IFoodService<UserFoodEntity, FoodItemEntity, UserFoodsModel, FoodItemModel, CreateUserFoodModel, UpdateUserFoodModel> _foodService;
        private readonly IJsonMapper _mapper;

        public FoodController
        (
            IFoodService<UserFoodEntity, FoodItemEntity, UserFoodsModel, FoodItemModel, CreateUserFoodModel, UpdateUserFoodModel> foodService, 
            IJsonMapper mapper
        )
        {
            _foodService = foodService;
            _mapper = mapper;
        }

        [HttpGet("GetFood")]
        public async Task<IActionResult> GetFoodAsync([FromQuery] GetUserFoodsContract contract)
        {
            var model = _mapper.Convert<GetUserFoodsModel>(contract);
            model.CollectionName = _foodService.DefaultCollectionName;
            var data = await _foodService.GetFilteredCollectionItemsAsync(model);
            if (data != null)
            {
                var result = new UserFoodsContract 
                {
                    UserId = contract.UserId,
                    Foods = _mapper.Convert<PagedDataContract<FoodItemContract>>(data)
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
            var model = _mapper.Convert<CreateUserFoodModel>(contract);            
            var created = await _foodService.CreateItemAsync(model);
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
            var model = _mapper.Convert<UpdateUserFoodModel>(contract);
            model.CollectionName = _foodService.DefaultCollectionName;
            model.Action = UpdateCollectionAction.Add;
            var updateFoodItemModel = _mapper.Convert<UpdateFoodItemModel>(contract);
            updateFoodItemModel.AddedDate = DateTime.UtcNow;
            model.Model = updateFoodItemModel;
            var updated = await _foodService.UpdateItemAsync(model);
            if (updated != null)
            {
                var result = _mapper.Convert<FoodItemContract>(updated);
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
            var model = _mapper.Convert<UpdateUserFoodModel>(contract);
            model.CollectionName = _foodService.DefaultCollectionName;
            model.Action = UpdateCollectionAction.Update;
            model.Model = _mapper.Convert<UpdateFoodItemModel>(contract);
            var updated = await _foodService.UpdateItemAsync(model);
            if (updated != null)
            {
                var result = _mapper.Convert<FoodItemContract>(updated);
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
            var model = new UpdateUserFoodModel
            {
                UserId = userId,
                Action = UpdateCollectionAction.Remove,
                CollectionName = _foodService.DefaultCollectionName,
                Model = new UpdateFoodItemModel 
                {
                    Id = foodId
                }
            };
            var updated = await _foodService.UpdateItemAsync(model);
            if (updated != null)
            {
                var result = updated.Id;
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
            var deleted = await _foodService.DeleteItemAsync(userId);
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