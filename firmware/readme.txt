# serial communication:

# cmd:
prog [button] [... bytes]
info [button]
ping

cmd_prog		0x30 0
cmd_info		0x31 1
cmd_?			0x32 2
cmd_ping		0x33 3
ack 			0x06 ACK
nak 			0x15 NAK

[Channel] [n] [n] [Button1] [n] [Button2] [n] [Button3] ... 

> cmd n_data #data#
< ack n_data #data#
