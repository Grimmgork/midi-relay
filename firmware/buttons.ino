
void process_buttons(struct button buttons[], int length, int debounce) {
	for(int i = 0; i < length; i++){
		struct button *button = &buttons[i];
		int reading = digitalRead(button->pin);
		unsigned long now = millis();

		if(button->high_pulse) {
			button->high_pulse = 0;
		}

		if(button->low_pulse) {
			button->low_pulse = 0;
		}

		if (button->debounce == 1 && button->debounce_start + debounce > now) {
			continue;
		}

		button->debounce = 0;
		if (reading != button->reading) {
			button->debounce_start = now;
			button->debounce = 1;
			
			button->reading = reading;
			if (reading == 1) {
				button->high_pulse = 1;
			}
			if (reading == 0) {
				button->low_pulse = 1;
			}
		}
	}
}