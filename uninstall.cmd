@echo off

echo Deleting Swate
.\config\Set-WebAddin.exe -cleanup -manifestPath ".\config\manifest.xml"

echo Deleting manifest.xml, deleting WebAddin-sideloader
del ".\config\manifest.xml" ".\config\Set-WebAddin.exe"

echo Deleting config folder
rmdir ".\config"

echo Uninstalling done. Press any key to exit.
pause >nul