/*  SA:MP MySQL Functions  */

#if defined _sampmysql_included
	#endinput
#endif
#define _sampmysql_included
#pragma library lgw
native samp_mysql_connect(server[], user[], password[]);
native samp_mysql_select_db(db[]);
native samp_mysql_query(query[]);
native samp_mysql_store_result();
native samp_mysql_fetch_row(line[]);
native samp_mysql_get_field(field[], value[]);
native samp_mysql_num_rows();
native samp_mysql_num_fields();
native samp_mysql_ping();
native samp_mysql_real_escape_string(src[], dest[]);
native samp_mysql_free_result();
native samp_mysql_strtok(dest[], separator[], src[]);
native samp_mysql_close();