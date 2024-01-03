# serial communication:

# cmd:
prog [button] [... bytes]
info [button]
ping

cmd_prog		0x30 0
cmd_info		0x31 1
cmd_?		0x32 2
cmd_ping		0x33 3
ack 			0x06 ACK
nak 			0x15 NAK

> cmd n_data ###data###
< ack n_data ###data###

cc kanal 5
wert 55

11000101 0x197
00110111 0x

test


cmd l data l data l data 0

# config
char $control_channel_overwrite 255
char *button_a_up
char *button_a_down
char *button_b_up
char *button_b_down
char *button_c_up
char *button_c_down
char *button_c_up
char *button_d_down
char *button_d_up

sequence:
char length
char *buffer

buffer_buffer_buffer_buffer

if(status > b1000nnnn )
	apply $control_channel