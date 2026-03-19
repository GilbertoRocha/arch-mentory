MIGRATION_DIR=$(cd "$(dirname "$0")" && pwd)
MIGRATION_DIR="$MIGRATION_DIR/../../src/backend/src/hotline/src/Tools/Database/Migration/Hotline.Tool.Migrations.csproj"

ASPNETCORE_ENVIRONMENT="Development" AzureKeyVault__Endpoint="https://mentory.vault.localhost:8444" dotnet restore $MIGRATION_DIR
ASPNETCORE_ENVIRONMENT="Development" AzureKeyVault__Endpoint="https://mentory.vault.localhost:8444" dotnet run --project  $MIGRATION_DIR