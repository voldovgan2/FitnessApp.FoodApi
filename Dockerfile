FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG NUGET_PAT
WORKDIR /src
RUN mkdir FitnessApp.FoodApi
COPY FitnessApp.FoodApi ./FitnessApp.FoodApi
WORKDIR /src/FitnessApp.FoodApi

RUN dotnet nuget add source https://nuget.pkg.github.com/voldovgan2/index.json --name FitnessApp.Github --username voldovgan2 --password ${NUGET_PAT} --store-password-in-clear-text
RUN dotnet restore "FitnessApp.FoodApi.csproj"
RUN dotnet build "FitnessApp.FoodApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "FitnessApp.FoodApi.csproj" -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=publish /app .
EXPOSE 80 443
ENTRYPOINT ["dotnet", "FitnessApp.FoodApi.dll"]