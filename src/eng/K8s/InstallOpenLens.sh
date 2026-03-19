VERSION="6.5.2-366"
APPIMAGE="OpenLens-${VERSION}.x86_64.AppImage"
URL="https://github.com/MuhammedKalkan/OpenLens/releases/download/v${VERSION}/${APPIMAGE}"
DEST="$HOME/OpenLens.AppImage"
ALIAS="openlens"



echo -e "\e[36m Looking for OpenLens \e[0m"

if [ -f "$DEST" ] && grep -q "alias openlens=" ~/.zshrc; then
    echo -e "\e[32m Openlens Already installed, and alias configured \e[0m"    
    exit 0
fi

echo -e "\e[33m OpenLens not found, instaling... \e[0m"

sudo apt install -y libfuse2 libnss3 libatk1.0-0 libatk-bridge2.0-0 libcups2 libdrm2 libgtk-3-0 libasound2t64

# if the appimage dont exists, download it
if [ ! -f "$DEST" ]; then
    echo -e "\e[33m Dowloading OpenLens Version ${VERSION}... \e[0m"
	curl -LO $URL
    mv $APPIMAGE $DEST
    chmod +x $DEST
fi

# create the alias
if ! grep -q "alias ${ALIAS}=" ~/.zshrc; then
    echo -e "\e[33m Creating the alias ${ALIAS}... \e[0m"
	echo "alias ${ALIAS}='$DEST --no-sandbox > /dev/null 2>&1 &'" >> ~/.zshrc
fi

echo -e "\e[32m OpenLens installed and alias ${ALIAS} configured \e[0m"