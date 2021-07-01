@ECHO OFF
ECHO Publishing for Windows
ECHO.
dotnet publish -o ./publish/ -r win-x64

ECHO.
ECHO Publishing finished.
PAUSE