struct button {
	int pin;
	unsigned long debounce_start;
	int debounce;
	int reading;
	int high_pulse;
	int low_pulse;
};

void process_buttons(struct button buttons[], int length, int debounce);