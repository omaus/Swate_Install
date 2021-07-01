@ECHO OFF
ECHO Publishing for Windows
ECHO.
dotnet publish -o ./Installer/Win/ -r win-x64

ECHO.
ECHO Publishing finished.