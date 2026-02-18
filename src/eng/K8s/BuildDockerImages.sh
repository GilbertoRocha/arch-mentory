SCRIPT_DIR=$(cd "$(dirname "$0")" && pwd)

echo -e "\e[32m Building Hotline Backend \e[0m"
docker build -t hotline-webapi:latest -f "$SCRIPT_DIR/../../backend/src/hotline/src/WebApi/Dockerfile" "$SCRIPT_DIR/../../backend/src/hotline/"

echo -e "\e[32m Building Hotline Frontend \e[0m"
docker build -t hotline-frontend:latest -f "$SCRIPT_DIR/../../frontend/src/hotline/Dockerfile" "$SCRIPT_DIR/../../frontend/src/hotline/"


