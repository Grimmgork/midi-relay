#include <stdio.h>
#include <errno.h>
#include <string.h>
#include <stdlib.h>
#include "errors.h"
#include "api.c"

int cmd_help(int argc, char *argv[]);
int cmd_program(int argc, char *argv[]);
int cmd_info(int argc, char *argv[]);
int cmd_reset(int argc, char *argv[]);

char *shift(int *argc, char **argv[])
{
	if(*argc <= 0) {
		return NULL;
	}
	char *p = *argv[0];
	(*argv)++;
	(*argc)--;
	return p;
}

int main( int argc, char *argv[] )
{
	shift(&argc, &argv);

	int res = -1;
	if (argc <= 0) {
		res = cmd_help(argc, argv);
	}
	else {
		char *arg = shift(&argc, &argv);
		if(!strcmp(arg, "info")) {
			res = cmd_info(argc, argv);
		} else if(!strcmp(arg, "program")) {
			res = cmd_program(argc, argv);
		} else if(!strcmp(arg, "reset")) {
			res = cmd_reset(argc, argv);
		} else {
			errno = ERR_INVALID_ARG;
		}
	}
	
	// handle error
	if (res != 0) {
		fprintf(stderr, "ERROR: %i\n", errno);
		return errno;
	}
}

int cmd_help(int argc, char *argv[])
{
	printf("# usage:\n");
	printf("midirelay info     [com]\n");
	printf("midirelay program  [com] [button no] [hex] [hex] [hex] ...\n");
	printf("midirelay reset    [com]\n");
	return 0;
}

int cmd_program(int argc, char *argv[])
{
	// com
	char* com = shift(&argc, &argv);
	if(com == NULL) {
		errno = ERR_INVALID_ARG;
		return -1;
	}

	// button
	char* arg = shift(&argc, &argv);
	if(arg == NULL) {
		errno = ERR_INVALID_ARG;
		return -1;
	}

	errno = 0;
	long button = strtol(arg, NULL, 10);
	if (errno != 0) {
		errno = ERR_INVALID_ARG;
		return -1;
	}

	if (button<=0 || button>=255) {
		errno = ERR_INVALID_ARG;
		return -1;
	}

	char sequence[254];
	char length = 0;
	for(int i = 0; i < 254; i++) {
		arg = shift(&argc, &argv);
		if (arg == NULL) {
			break;
		}

		errno = 0;
		long byte = strtol(arg, NULL, 16);
		if (errno != 0 || byte <= 0 || byte >= 255) {
			errno = ERR_INVALID_ARG;
			return -1;
		}

		sequence[i] = (char)byte;
		length++;
	}

	if(argc != 0) {
		errno = ERR_TOOLONG_ARG;
		return -1;
	}

	int res = dev_program("com3", (char)button-1, sequence, length);
	return res;
}

int cmd_reset(int argc, char *argv[])
{
	char* com = shift(&argc, &argv);
	if(com == NULL) {
		errno = ERR_INVALID_ARG;
		return -1;
	}

	return 0;
}

int cmd_info(int argc, char *argv[])
{
	char* com = shift(&argc, &argv);
	if(com == NULL) {
		errno = ERR_INVALID_ARG;
		return -1;
	}

	char sequence[255];
	char length = 0;
	char button = 0;
	for(; button < 255; button++) {
		if(dev_info(com, button, sequence, &length) != 0) {
			break;
		}
		printf("[%02d] ", (int)button+1);
		for(char i = 0; i < length; i++) {
			printf("%02x ", sequence[i]);
		}
		printf("\n");
	}
	return 0;
}