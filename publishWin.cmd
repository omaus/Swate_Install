@echo off
echo Publishing for Windows
echo.
dotnet publish ./src/Install(Windows)/Install(Windows).fsproj -o ./Installer/Win/ -r win-x64

echo.
echo Publishing finished.
pause