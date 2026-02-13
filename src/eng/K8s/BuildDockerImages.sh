SCRIPT_DIR=$(cd "$(dirname "$0")" && pwd)

echo "Building Hotline Backend"
docker build -t hotline-webapi:latest -f "$SCRIPT_DIR/../../backend/src/hotline/src/WebApi/Dockerfile" "$SCRIPT_DIR/../../backend/src/hotline/"

echo "Building Hotline Frontend"
docker build -t hotline-frontend:latest -f "$SCRIPT_DIR/../../frontend/src/hotline/Dockerfile" "$SCRIPT_DIR/../../frontend/src/hotline/"


