@echo off
set /p port="port?: "
.\ui\ui.exe reset %port%
echo.
IF %ERRORLEVEL% EQU 0 (Echo Reset sucessful!)
pause
