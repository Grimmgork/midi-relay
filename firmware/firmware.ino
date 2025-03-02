#include <EEPROM.h>

#include "commands.h"
#include "buttons.h"

#define NBUTTONS 5
#define MIDI_SEQUENCE_LENGTH 16

struct midi_sequence {
	char length;
	char buffer[MIDI_SEQUENCE_LENGTH];
};

struct midi_sequence sequences[NBUTTONS] = {0};
struct button buttons[NBUTTONS] = {0};

void load_sequences();
int save_sequence(char button, char *buffer, char length);
void run_sequence(char button);

void 
setup()
{
	// setup pins
	pinMode(LED_BUILTIN, OUTPUT);
	for(int i = 0; i < NBUTTONS; i++) {
		pinMode(2+i, INPUT_PULLUP);
		buttons[i].pin = 2+i;
	}

	load_sequences();
	Serial.setTimeout(500);
	Serial.begin(31250);
}

void
loop()
{
	process_command(&cmd_prog, &cmd_info, &cmd_reset, &cmd_ping);
	process_buttons(buttons, NBUTTONS, 100);
	for(int i = 0; i < NBUTTONS; i++) {
		if(buttons[i].low_pulse) {
			run_sequence(i);
		}
	}
}

void
run_sequence(char button)
{
	if (button >= NBUTTONS) {
		return;
	}

	struct midi_sequence seq = sequences[button];
	Serial.write(seq.buffer, seq.length);
}

int
save_sequence(char button, char *buffer, char length)
{
	if (button >= NBUTTONS) {
		return 1;
	}
	if (length > MIDI_SEQUENCE_LENGTH) {
		return 1;
	}

	int start_addr = button * sizeof(struct midi_sequence);
	EEPROM.update(start_addr, length);
	start_addr++;
	char i;
	for (i = 0; i < length; i++) {
		EEPROM.update(start_addr + i, buffer[i]);
	}

	return 0;
}

void
load_sequences()
{
	EEPROM.get(0, sequences);
}

int
cmd_prog(struct cmd_data *req, struct cmd_data *res)
{
	if (req->length == 0) {
		return 1;
	}

	char button = req->buffer[0];
	if (button >= NBUTTONS) {
		return 1;
	}

	int resn = save_sequence(button, &req->buffer[1], req->length-1);
	if (resn != 0) {
		return 1;
	}

	load_sequences();
	return 0;
}

int
cmd_ping(struct cmd_data *req, struct cmd_data *res)
{
	return 0;
}

int
cmd_info(struct cmd_data *req, struct cmd_data *res)
{
	if (req->length == 0) {
		return 1;
	}

	char button = req->buffer[0];
	if (button >= NBUTTONS) {
		return 1;
	}

	memcpy(res->buffer, sequences[button].buffer, sequences[button].length);
	res->length = sequences[button].length;
	return 0;
}

int
cmd_reset(struct cmd_data *req, struct cmd_data *res)
{
	if (req->length != 0) {
		return 1;
	}
	
	char button;
	for (button = 0; button < NBUTTONS; button++)
	{
		int resn = save_sequence(button, NULL, 0);
		if (resn != 0) {
			return 1;
		}
	}

	load_sequences();
	return 0;
}