VERSION="6.5.2-366"
APPIMAGE="OpenLens-${VERSION}.x86_64.AppImage"
URL="https://github.com/MuhammedKalkan/OpenLens/releases/download/v${VERSION}/${APPIMAGE}"
DEST="$HOME/bin/OpenLens.AppImage"
ALIAS="openlens"
ALIAS_LINE="alias ${ALIAS}='${DEST}'"


echo -e "\e[36m Looking for OpenLens \e[0m"

if [[ -f "$DEST" ]] && (grep -q "alias openlens=" ~/.zshrc 2>/dev/null || grep -q "alias openlens=" ~/.bashrc 2>/dev/null); then
    echo -e "\e[32m OpenLens already installed and alias found in one of the shell configs. \e[0m"    
    exit 0
fi

echo -e "\e[33m OpenLens not found, instaling... \e[0m"

sudo apt install -y libfuse2 libnss3 libatk1.0-0 libatk-bridge2.0-0 libcups2 libdrm2 libgtk-3-0 libasound2t64

# if the appimage dont exists, download it
if [ ! -f "$DEST" ]; then
	
    echo -e "\e[33m Dowloading OpenLens Version ${VERSION}... \e[0m"
	
	mkdir -p "$(dirname "$DEST")"
	
	curl -LO $URL
    mv $APPIMAGE $DEST
    chmod +x $DEST
fi

# create the alias
echo -e "\e[34m Creating OpenLens Alias '${ALIAS}' ... \e[0m"

SHELL_CONFIGS=("$HOME/.bashrc" "$HOME/.zshrc")

for CONFIG_FILE in "${SHELL_CONFIGS[@]}"; do
    
	# if config exists
    if [ -f "$CONFIG_FILE" ]; then
        
		# test if the alias already exists, to not duplicate it
        if ! grep -q "alias ${ALIAS}=" "$CONFIG_FILE"; then
            # add new empty line and the alias
            echo "" >> "$CONFIG_FILE"
            echo "${ALIAS_LINE}" >> "$CONFIG_FILE"
            echo -e "\e[32m Alias added to $CONFIG_FILE \e[0m"
        else
            echo -e "\e[33m Alias '${ALIAS}' already exists in $CONFIG_FILE \e[0m"
        fi
    fi
done

alias ${ALIAS}="${DEST}"

echo -e "\e[32m OpenLens installed and alias ${ALIAS} configured \e[0m"