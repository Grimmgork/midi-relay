#include <stdio.h>
#include "errors.h"
#include "serial.c"

#define SERIAL_TIMEOUT 2000
#define SERIAL_BAUD 31250

struct device_message {
	char type;
	char length;
	char buffer[256];
};

int dev_request(void *serial, struct device_message *req, struct device_message *res)
{
	int result;
	result = serial_write(serial, &req->type, 1);
	if (result) {
		return 1;
	}
	result = serial_write(serial, &req->length, 1);
	if (result) {
		return 1;
	}
	result = serial_write(serial, req->buffer, req->length);
	if (result) {
		return 1;
	}

	result = serial_read(serial, &res->type, 1);
	if (result != 1) {
		return 1;
	}
	result = serial_read(serial, &res->length, 1);
	if (result != 1) {
		return 1;
	}
	result = serial_read(serial, res->buffer, res->length);
	if (result != res->length) {
		return 1;
	}
	
	return 0;
}

int dev_reset(char *port)
{
	void *serial = serial_open(port, SERIAL_BAUD, SERIAL_TIMEOUT);
	if (serial == NULL) {
		errno = ERR_CANT_OPEN_SERIAL;
		return -1;
	}
	serial_clear(serial);

	struct device_message req;
	struct device_message res;

	req.type = 0x32;
	req.length = 0;

	int result = dev_request(serial, &req, &res);
	if (result != 0) {
		errno = ERR_SERIAL;
		serial_close(serial);
		return -1;
	}

	if (res.type != 0x06) {
		errno = ERR_DEVICE_INTERNAL;
		serial_close(serial);
		return -1;
	}

	serial_close(serial);
	return 0;
}

int dev_program(char *port, int button, char *sequence, int length)
{
	void *serial = serial_open(port, SERIAL_BAUD, SERIAL_TIMEOUT);
	if (serial == NULL) {
		errno = ERR_CANT_OPEN_SERIAL;
		return -1;
	}
	serial_clear(serial);

	struct device_message req;
	struct device_message res;

	if (length > 254) {
		errno = ERR_SERIAL;
		serial_close(serial);
		return -1;
	}

	req.type = 0x30;
	req.buffer[0] = (char) button;
	memcpy(&req.buffer[1], sequence, length);
	req.length = length + 1;

	int result = dev_request(serial, &req, &res);
	if (result != 0) {
		errno = ERR_SERIAL;
		serial_close(serial);
		return -1;
	}

	if (res.type != 0x06) {
		serial_close(serial);
		return ERR_DEVICE_INTERNAL;
	}

	serial_close(serial);
	return 0;
}

int dev_info(char *port, char button, char *out_sequence, char *out_len)
{
	void *serial = serial_open(port, SERIAL_BAUD, SERIAL_TIMEOUT);
	if (serial == NULL) {
		errno = ERR_CANT_OPEN_SERIAL;
		return -1;
	}
	serial_clear(serial);

	struct device_message req;
	struct device_message res;

	req.type = 0x31;
	req.length = 1;
	req.buffer[0] = button;

	int result = dev_request(serial, &req, &res);
	if (result < 0) {
		errno = ERR_SERIAL;
		serial_close(serial);
		return -1;
	}

	if (res.type != 0x06) {
		serial_close(serial);
		return ERR_DEVICE_INTERNAL;
	}

	*out_len = res.length;
	memcpy(out_sequence, res.buffer, res.length);

	serial_close(serial);
	return 0;
}