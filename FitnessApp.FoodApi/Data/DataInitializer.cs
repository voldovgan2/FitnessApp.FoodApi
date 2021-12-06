using FitnessApp.FoodApi.Data.Entities;
using FitnessApp.FoodApi.Models.Input;
using FitnessApp.FoodApi.Models.Output;
using FitnessApp.FoodApi.Services.UserFood;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace FitnessApp.FoodApi.Data
{
    public class DataInitializer
    {
        public static async Task EnsureFoodsCreatedAsync(IServiceProvider serviceProvider, bool create = false, bool delete = false)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var services = scope.ServiceProvider;
                var service = services.GetRequiredService<IFoodService<UserFoodEntity, FoodItemEntity, UserFoodsModel, FoodItemModel, CreateUserFoodModel, UpdateUserFoodModel>>();
                for (int k = 0; k < 200; k++)
                {
                    var userEmail = $"user{k}@hotmail.com";
                    var userId = $"ApplicationUser_{userEmail}";
                    if(delete)
                    {
                        await service.DeleteItemAsync(userId);
                    }
                    if (create)
                    {
                        await service.CreateItemAsync(new CreateUserFoodModel { UserId = userId });
                    }
                }
                var adminEmail = "admin@hotmail.com";
                var adminId = $"ApplicationUser_{adminEmail}";
                if (delete)
                {
                    await service.DeleteItemAsync(adminId);
                }
                if (create)
                {
                    await service.CreateItemAsync(new CreateUserFoodModel { UserId = adminId });
                }
            }
        }
    }
}
