using System.Reflection;
using FitnessApp.Common.Configuration;
using FitnessApp.Common.Serializer.JsonSerializer;
using FitnessApp.FoodApi;
using FitnessApp.FoodApi.Contracts.Output;
using FitnessApp.FoodApi.DependencyInjection;
using FitnessApp.FoodApi.Models.Output;
using FitnessApp.FoodApi.Services.MessageBus;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureMapper(new MappingProfile<FoodItemContract, UserFoodCollectionFileAggregatorItemModel>());
builder.Services.AddTransient<IJsonSerializer, JsonSerializer>();
builder.Services.ConfigureMongo(builder.Configuration);
builder.Services.ConfigureVault(builder.Configuration);
builder.Services.ConfigureFoodRepository();
builder.Services.ConfigureFilesService(builder.Configuration);
builder.Services.ConfigureNats(builder.Configuration);
builder.Services.AddFoodMessageTopicSubscribersService();
builder.Services.ConfigureAuthentication(builder.Configuration);
builder.Services.ConfigureSwagger(Assembly.GetExecutingAssembly().GetName().Name);
builder.Services.ConfigureCollectionServices(builder.Configuration);
if ("false".Contains("true"))
    builder.Services.AddHostedService<UserFoodMessageTopicSubscribersService>();

builder.Host.ConfigureAppConfiguration();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerAndUi();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
public partial class Program { }