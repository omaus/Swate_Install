@ECHO OFF
ECHO Publishing for Linux
ECHO.
dotnet publish -o ./Installer/Linux/ -r linux-x64

ECHO.
ECHO Publishing for MacOS
ECHO.
dotnet publish -o ./Installer/OSx/ -r osx-x64

ECHO.
ECHO Publishing for Windows
ECHO.
dotnet publish -o ./Installer/Win/ -r win-x64

ECHO.
ECHO Publishing finished.
PAUSE