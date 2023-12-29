struct cmd_data {
	char buffer[255];
	char length;
};

void process_command(
	int (*dc1)(struct cmd_data*, struct cmd_data*), 
	int (*dc2)(struct cmd_data*, struct cmd_data*), 
	int (*dc3)(struct cmd_data*, struct cmd_data*), 
	int (*dc4)(struct cmd_data*, struct cmd_data*));