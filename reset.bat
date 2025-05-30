@echo off
set /p port="port?: "
.\tui\tui.exe reset %port%
echo.
IF %ERRORLEVEL% EQU 0 (Echo Reset sucessful!)
pause
