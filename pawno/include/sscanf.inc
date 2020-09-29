stock sscanf(string[], format[], {Float,_}:...)
{
	new
		formatPos = 0,
		stringPos = 0,
		paramPos = 2,
		paramCount = numargs();
	while (paramPos < paramCount && string[stringPos])
	{
		switch (format[formatPos++])
		{
			case '\0':
			{
				return 0;
			}
			case 'i', 'd':
			{
				new
					neg = 1,
					num = 0,
					ch = string[stringPos];
				if (ch == '-')
				{
					neg = -1;
					ch = string[++stringPos];
				}
				do
				{
					stringPos++;
					if (ch >= '0' && ch <= '9')
					{
						num = (num * 10) + (ch - '0');
					}
					else
					{
						return 1;
					}
				}
				while ((ch = string[stringPos]) && ch != ' ');
				setarg(paramPos, 0, num * neg);
			}
			case 'h', 'x':
			{
				new
					ch,
					num = 0;
				while ((ch = string[stringPos++]))
				{
					switch (ch)
					{
						case 'x', 'X':
						{
							num = 0;
							continue;
						}
						case '0' .. '9':
						{
							num = (num << 4) | (ch - '0');
						}
						case 'a' .. 'f':
						{
							num = (num << 4) | (ch - ('a' - 10));
						}
						case 'A' .. 'F':
						{
							num = (num << 4) | (ch - ('A' - 10));
						}
						case ' ':
						{
							break;
						}
						default:
						{
							return 1;
						}
					}
				}
				setarg(paramPos, 0, num);
			}
			case 'c':
			{
				setarg(paramPos, 0, string[stringPos++]);
			}
			case 'f':
			{
                new tmp[25];
                strmid(tmp, string, stringPos, stringPos+sizeof(tmp)-2);
				setarg(paramPos, 0, _:floatstr(tmp));
			}
			case 's', 'z':
			{
				new
					i = 0,
					ch;
				if (format[formatPos])
				{
					while ((ch = string[stringPos++]) && ch != ' ')
					{
						setarg(paramPos, i++, ch);
					}
					if (!i) return 1;
				}
				else
				{
					while ((ch = string[stringPos++]))
					{
						setarg(paramPos, i++, ch);
					}
				}
				stringPos--;
				setarg(paramPos, i, '\0');
			}
			default:
			{
				continue;
			}
		}
		while (string[stringPos] && string[stringPos] != ' ')
		{
			stringPos++;
		}
		while (string[stringPos] == ' ')
		{
			stringPos++;
		}
		paramPos++;
	}
	while (format[formatPos] == 'z') formatPos++;
	return format[formatPos];
}