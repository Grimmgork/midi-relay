# serial communication:

# cmd:
prog [button] [... bytes]
info [button]
ping

cmd_prog		0x30 0
cmd_info		0x31 1
cmd_rset		0x32 2
cmd_ping		0x33 3
ack 			0x06 ACK
nak 			0x15 NAK

> cmd n_data #data#
< ack n_data #data#



# FORECAST:
when trying to execute a sequence for a button
check if the sequence is a midi sequence (first byte is midi status byte e.g. > 127)
	then run midi sequence 
else
	try to run custom functionality
for example:
0x00 = Assign 1
0x01 = Assign 2