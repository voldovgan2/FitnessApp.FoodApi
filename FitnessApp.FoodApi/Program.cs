using System.Reflection;
using AutoMapper;
using FitnessApp.AzureServiceBus;
using FitnessApp.Common.Abstractions.Db.Configuration;
using FitnessApp.Common.Abstractions.Db.DbContext;
using FitnessApp.Common.Abstractions.Services.Configuration;
using FitnessApp.Common.Configuration.AppConfiguration;
using FitnessApp.Common.Configuration.Blob;
using FitnessApp.Common.Configuration.Identity;
using FitnessApp.Common.Configuration.Mongo;
using FitnessApp.Common.Configuration.Search;
using FitnessApp.Common.Configuration.Swagger;
using FitnessApp.Common.Serializer.JsonSerializer;
using FitnessApp.FoodApi;
using FitnessApp.FoodApi.Contracts.Output;
using FitnessApp.FoodApi.Data.Entities;
using FitnessApp.FoodApi.DependencyInjection;
using FitnessApp.FoodApi.Models.Output;
using FitnessApp.FoodApi.Services.UserFoodAggregator;
using FitnessApp.FoodApi.Services.UserFoodCollection;
using FitnessApp.ServiceBus.AzureServiceBus.Configuration;
using FitnessApp.ServiceBus.AzureServiceBus.Consumer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile<FoodItemContract, UserFoodCollectionBlobAggregatorItemModel>());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddTransient<IJsonSerializer, JsonSerializer>();

builder.Services.Configure<CollectionBlobAggregatorSettings>(builder.Configuration.GetSection("CollectionBlobAggregatorSettings"));

builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoConnection"));

builder.Services.Configure<AzureServiceBusSettings>(builder.Configuration.GetSection("AzureServiceBusSettings"));

builder.Services.ConfigureMongoClient(builder.Configuration);

builder.Services.AddTransient<IDbContext<UserFoodCollectionEntity>, DbContext<UserFoodCollectionEntity>>();

builder.Services.AddBlobService(builder.Configuration);

builder.Services.AddFoodRepository();

builder.Services.AddTransient<IUserFoodCollectionService, UserFoodCollectionService>();

builder.Services.AddTransient<IUserFoodCollectionBlobAggregatorService, UserFoodCollectionBlobAggregatorService>();

builder.Services.ConfigureSearchService(builder.Configuration);

builder.Services.AddFoodMessageTopicSubscribersService();

builder.Services.AddSingleton<IMessageConsumer, MessageConsumer>();

builder.Services.AddHostedService<MessageListenerService>();

builder.Services.ConfigureAzureAdAuthentication(builder.Configuration);

builder.Services.ConfigureSwaggerConfiguration(Assembly.GetExecutingAssembly().GetName().Name);

builder.Host.ConfigureAzureAppConfiguration();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger XML Api Demo v1");
});

app.Run();

#pragma warning disable S1118 // Utility classes should not have public constructor
public partial class Program { }
#pragma warning restore S1118 // Utility classes should not have public constructor