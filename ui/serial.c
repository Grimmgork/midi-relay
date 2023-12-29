#include <windows.h>
#include <tchar.h>
#include <stdio.h>

void *serial_open(char *portid, int baudrate, int timeout)
{
	// open file handle
	HANDLE connection;
	connection = CreateFile(portid,
		GENERIC_READ | GENERIC_WRITE,
		0,
		0,
		OPEN_EXISTING,
		FILE_ATTRIBUTE_NORMAL,
		0);
	
	if (connection==INVALID_HANDLE_VALUE) {
		CloseHandle(connection);
		return NULL;
	}

	// setting parameters
	DCB dcbSerialParams = {0};
	dcbSerialParams.DCBlength=sizeof(dcbSerialParams);
	if (!GetCommState(connection, &dcbSerialParams)) {
		CloseHandle(connection);
		return NULL;
	}
	dcbSerialParams.BaudRate = baudrate;
	dcbSerialParams.ByteSize = 8;
	dcbSerialParams.StopBits = ONESTOPBIT;
	dcbSerialParams.Parity = NOPARITY;
	if (!SetCommState(connection, &dcbSerialParams)) {
		CloseHandle(connection);
		return NULL;
	}

	COMMTIMEOUTS timeouts={0};
	timeouts.ReadIntervalTimeout=50;

	timeouts.ReadTotalTimeoutConstant=timeout;
	timeouts.ReadTotalTimeoutMultiplier=10;

	timeouts.WriteTotalTimeoutConstant=timeout;
	timeouts.WriteTotalTimeoutMultiplier=10;

	if(!SetCommTimeouts(connection, &timeouts)){
		CloseHandle(connection);
		return NULL;
	}
	
	return connection;
}

int serial_clear(void *connection)
{
	if (!PurgeComm(connection, PURGE_RXCLEAR | PURGE_TXABORT | PURGE_TXCLEAR | PURGE_RXABORT)) {
		return -1;
	}
	return 0;
}

int serial_close(void *connection)
{
	CloseHandle(connection);
	return 0;
}

int serial_read(void *connection, char *buffer, int length)
{
	DWORD read = 0;
	ReadFile(connection, buffer, length, &read, NULL);
	return read;
}

int serial_write(void *connection, char *buffer, int length)
{
	if (!WriteFile(connection, buffer, length, NULL, NULL)) {
	 	return -1;
	}
	return 0;
}