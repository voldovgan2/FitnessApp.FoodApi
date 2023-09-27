using System;
using System.Threading.Tasks;
using FitnessApp.FoodApi.Data.Entities;
using FitnessApp.FoodApi.Models.Input;
using FitnessApp.FoodApi.Models.Output;
using Microsoft.Extensions.DependencyInjection;

namespace FitnessApp.FoodApi.Data
{
    public static class DataInitializer
    {
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public static async Task EnsureFoodsCreatedAsync(IServiceProvider serviceProvider, bool create = false, bool delete = false)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            /*
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
            */
        }
    }
}
