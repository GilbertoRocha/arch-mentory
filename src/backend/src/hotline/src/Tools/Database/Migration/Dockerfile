FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["Hotline.slnx", "./"]
COPY ["src/Tools/Database/Migration/Hotline.Tool.Migrations.csproj", "src/Tools/Database/Migration/"]
COPY ["src/Infrastructure/Hotline.Infrastructure.csproj", "src/Infrastructure/"]
COPY ["src/Domain/Hotline.Domain.csproj", "src/Domain/"]


RUN dotnet restore "src/Tools/Database/Migration/Hotline.Tool.Migrations.csproj"

COPY . .
WORKDIR "/src/src/Tools/Database/Migration"
RUN dotnet build "Hotline.Tool.Migrations.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Hotline.Tool.Migrations.csproj" -c Release -o /app/publish /p:UseAppHost=false


FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
RUN apk add --no-cache icu-libs
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
COPY --from=build /app/publish .



ENTRYPOINT ["dotnet", "Hotline.Tool.Migrations.dll"]