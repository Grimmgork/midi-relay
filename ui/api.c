#include <stdio.h>
#include "errors.h"
#include "serial.c"

#define SERIAL_TIMEOUT 2000
#define SERIAL_BAUD 19200

struct cmd_data {
	char length;
	char buffer[255];
};

int dev_request(void *conn, char cmd, struct cmd_data *req, struct cmd_data *res)
{
	if(serial_write(conn, &cmd, 1) != 0) {
		return -1;
	}
	if(serial_write(conn, &req->length, 1) != 0) {
		return -1;
	}
	if(serial_write(conn, req->buffer, req->length) != 0) {
		return -1;
	}

	char error;
	int read = serial_read(conn, &error, 1);
	if (read != 1) {
		return -1;
	}
	char length;
	if (serial_read(conn, &length, 1) != 1) {
		return -1;
	}
	if (serial_read(conn, res->buffer, (int)length) != (int)length) {
		return -1;
	}
	res->length = length;
	if (error == 6) {
		return 0;
	}
	return 1;
}

int dev_program(char *serial, int button, char *sequence, int length)
{
	void *conn = serial_open(serial, SERIAL_BAUD, SERIAL_TIMEOUT);
	if (conn == NULL) {
		errno = ERR_CANT_OPEN_SERIAL;
		return -1;
	}
	serial_clear(conn);

	struct cmd_data req;
	struct cmd_data res;
	req.length = 0;
	res.length = 0;

	if (length > 254) {
		errno = ERR_SERIAL;
		serial_close(conn);
		return -1;
	}

	req.buffer[0] = (char) button;
	memcpy(&req.buffer[1], sequence, length);
	req.length = length + 1;

	int result = dev_request(conn, 0x30, &req, &res);
	if (result != 0) {
		errno = ERR_SERIAL;
		serial_close(conn);
		return -1;
	}

	serial_close(conn);
	return 0;
}

int dev_info(char *serial, char button, char *out_sequence, char *out_len)
{
	void *conn = serial_open(serial, SERIAL_BAUD, SERIAL_TIMEOUT);
	if (conn == NULL) {
		errno = ERR_CANT_OPEN_SERIAL;
		return -1;
	}
	serial_clear(conn);

	struct cmd_data req;
	struct cmd_data res;
	req.length = 0;
	res.length = 0;

	req.buffer[0] = button;
	req.length = 1;

	int result = dev_request(conn, 0x31, &req, &res);
	if (result < 0) {
		errno = ERR_SERIAL;
		serial_close(conn);
		return -1;
	}

	if (result > 0) {
		errno = ERR_DEVICE_INTERNAL;
		serial_close(conn);
		return -1;
	}

	*out_len = res.length;
	memcpy(out_sequence, res.buffer, res.length);

	serial_close(conn);
	return 0;
}