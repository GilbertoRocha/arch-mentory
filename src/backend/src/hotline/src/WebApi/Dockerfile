FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["Hotline.slnx", "./"]
COPY ["src/WebApi/Hotline.WebApi.csproj", "src/WebApi/"]


RUN dotnet restore "src/WebApi/Hotline.WebApi.csproj"

COPY . .

WORKDIR "/src/src/WebApi"
RUN dotnet publish "Hotline.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80

ENTRYPOINT ["dotnet", "Hotline.WebApi.dll"]