#include <errno.h>

#ifndef ERRORS_H
#define ERRORS_H

#define ERR_UNDEF 0;

#define ERR_INVALID_ARG -1
#define ERR_TOOLONG_ARG -7

// api.c
#define ERR_CANT_OPEN_SERIAL -2
#define ERR_SERIAL -8
#define ERR_INVALID_RESPONSE -5
#define ERR_DEVICE_INTERNAL -6

#endif