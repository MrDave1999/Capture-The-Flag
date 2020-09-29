#define WHIRLPOOL_LEN (129)

// Whirlpool hash `str` and store result into `buffer` which must be of `WHIRLPOOL_LEN` cells.
native WP_Hash(buffer[], len, const str[]);
