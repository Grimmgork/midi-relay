@echo off
mode %1 BAUD=31250 PARITY=n DATA=8 > NUL
echo "0x32 0x00" | xxd -r -p > com3