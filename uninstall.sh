echo Deleting Swate
./config/Set-WebAddin.exe -cleanup -manifestPath "./config/manifest.xml"

echo Deleting manifest.xml, deleting WebAddin-sideloader, deleting config folder
rm -r ./config/

read -n1 -r -p "Uninstalling done. Press any key to exit." key