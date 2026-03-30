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
echo -e "\e[34m Creating OpenLens Alias '${ALIAS}' ... \e[0m"

SHELL_CONFIGS=("$HOME/.bashrc" "$HOME/.zshrc")

for CONFIG_FILE in "${SHELL_CONFIGS[@]}"; do
    # if exists
    if [ -f "$CONFIG_FILE" ]; then
        # if the alias exists
        if ! grep -qF "${ALIAS_LINE}" "$CONFIG_FILE"; then
            echo "${ALIAS_LINE}" >> "$CONFIG_FILE"
            echo -e "\e[32m Alias added on $CONFIG_FILE \e[0m"
        else
            echo -e "\e[33m Alias already configured on $CONFIG_FILE... \e[0m"
        fi
    fi
done
echo -e "\e[32m OpenLens installed and alias ${ALIAS} configured \e[0m"