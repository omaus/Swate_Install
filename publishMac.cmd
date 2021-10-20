@echo off
echo Publishing for MacOS
echo.
dotnet publish ./src/Install(macOS)/Install(macOS).fsproj -o ./Installer/OSx/ -r osx-x64

echo.
echo Publishing finished.
pause