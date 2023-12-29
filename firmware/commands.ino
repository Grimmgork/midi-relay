void
process_command(int (*cmd0)(struct cmd_data*, struct cmd_data*), int (*cmd1)(struct cmd_data*, struct cmd_data*), int (*cmd2)(struct cmd_data*, struct cmd_data*), int (*cmd3)(struct cmd_data*, struct cmd_data*))
{
	struct cmd_data req;
	struct cmd_data res;
	res.length = 0;
	req.length = 0;

	if (Serial.available() == 0) {
		return;
	}

	int cmd = Serial.read();
	if (cmd > 0x33 || cmd < 0x30) {
		return;
	}

	Serial.readBytes(&req.length, 1);
	if (Serial.readBytes(req.buffer, req.length) < req.length) {
		goto error;
	}

	int errorcode = -1;
	if (cmd == 0x30) {
		if (cmd0 == NULL) { goto error; }
		errorcode = (*cmd0)(&req, &res);
	} else if (cmd == 0x31) {
		if (cmd1 == NULL) { goto error; }
		errorcode = (*cmd1)(&req, &res);
	} else if (cmd == 0x32) {
		if (cmd2 == NULL) { goto error; }
		errorcode = (*cmd2)(&req, &res);
	} else if (cmd == 0x33) {
		if (cmd3 == NULL) { goto error; }
		errorcode = (*cmd3)(&req, &res);
	}
	
	if (errorcode != 0) {
		goto error;
	}

	// send ACK response
	Serial.write(0x06);
	Serial.write(res.length);
	for (int i = 0; i < res.length; i++) {
		Serial.write(res.buffer[i]);
	}
	return;

error: // send NAK response
	Serial.write(0x15);
	Serial.write(0);
}