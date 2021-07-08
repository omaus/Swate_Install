@echo off

echo Deleting Swate
.\config\Set-WebAddin.exe -uninstall -installedManifestFullname ".\config\sideloaderData\manifest.xml"

echo Deleting manifest.xml, deleting WebAddin-sideloader
del ".\config\manifest.xml" ".\config\Set-WebAddin.exe"
del ".\config\sideloaderData\manifest.xml"
rmdir ".\config\sideloaderData"

echo Deleting config folder
rmdir ".\config"

echo Uninstalling done. Press any key to exit.
pause >nul