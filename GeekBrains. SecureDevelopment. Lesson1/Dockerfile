#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["GeekBrains. SecureDevelopment. Lesson1/GeekBrains.SecureDevelopment.Lesson1.csproj", "GeekBrains. SecureDevelopment. Lesson1/"]
RUN dotnet restore "GeekBrains. SecureDevelopment. Lesson1/GeekBrains.SecureDevelopment.Lesson1.csproj"
COPY . .
WORKDIR "/src/GeekBrains. SecureDevelopment. Lesson1"
RUN dotnet build "GeekBrains.SecureDevelopment.Lesson1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GeekBrains.SecureDevelopment.Lesson1.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GeekBrains.SecureDevelopment.Lesson1.dll"]