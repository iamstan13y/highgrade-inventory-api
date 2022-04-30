#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["HighGrade-Inventory/HighGradeInventory.API.csproj", "HighGrade-Inventory/"]
RUN dotnet restore "HighGrade-Inventory/HighGradeInventory.API.csproj"
COPY . .
WORKDIR "/src/HighGrade-Inventory"
RUN dotnet build "HighGradeInventory.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HighGradeInventory.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HighGradeInventory.API.dll"]