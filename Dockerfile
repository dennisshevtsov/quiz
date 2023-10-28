#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/SurveyApp.Web/SurveyApp.Web.csproj", "src/SurveyApp.Web/"]
COPY ["src/SurveyApp.App/SurveyApp.App.csproj", "src/SurveyApp.App/"]
COPY ["src/SurveyApp/SurveyApp.csproj", "src/SurveyApp/"]
COPY ["src/SurveyApp.Data/SurveyApp.Data.csproj", "src/SurveyApp.Data/"]
RUN dotnet restore "src/SurveyApp.Web/SurveyApp.Web.csproj"
COPY . .
WORKDIR "/src/src/SurveyApp.Web"
RUN dotnet build "SurveyApp.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SurveyApp.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SurveyApp.Web.dll"]
