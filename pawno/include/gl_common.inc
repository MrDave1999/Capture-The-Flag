//----------------------------------------------------------
//
// GRAND LARCENY common functions include.
//
//----------------------------------------------------------

stock LoadStaticVehiclesFromFile(const filename[])
{
	new File:file_ptr;
	new line[256];
	new var_from_line[64];
	new vehicletype;
	new Float:SpawnX;
	new Float:SpawnY;
	new Float:SpawnZ;
	new Float:SpawnRot;
    new Color1, Color2;
	new index;
	new vehicles_loaded;

	file_ptr = fopen(filename,filemode:io_read);
	if(!file_ptr) return 0;

	vehicles_loaded = 0;

	while(fread(file_ptr,line,256) > 0)
	{
	    index = 0;

	    // Read type
  		index = token_by_delim(line,var_from_line,',',index);
  		if(index == (-1)) continue;
  		vehicletype = strval(var_from_line);
   		if(vehicletype < 400 || vehicletype > 611) continue;

  		// Read X, Y, Z, Rotation
  		index = token_by_delim(line,var_from_line,',',index+1);
  		if(index == (-1)) continue;
  		SpawnX = floatstr(var_from_line);

  		index = token_by_delim(line,var_from_line,',',index+1);
  		if(index == (-1)) continue;
  		SpawnY = floatstr(var_from_line);

  		index = token_by_delim(line,var_from_line,',',index+1);
  		if(index == (-1)) continue;
  		SpawnZ = floatstr(var_from_line);

  		index = token_by_delim(line,var_from_line,',',index+1);
  		if(index == (-1)) continue;
  		SpawnRot = floatstr(var_from_line);

  		// Read Color1, Color2
  		index = token_by_delim(line,var_from_line,',',index+1);
  		if(index == (-1)) continue;
  		Color1 = strval(var_from_line);

  		index = token_by_delim(line,var_from_line,';',index+1);
  		Color2 = strval(var_from_line);

  		//printf("%d,%d,%f,%f,%f,%f,%d,%d",total_vehicles_from_files+vehicles_loaded+1,vehicletype,SpawnX,SpawnY,SpawnZ,SpawnRot,Color1,Color2);

		AddStaticVehicleEx(vehicletype,SpawnX,SpawnY,SpawnZ,SpawnRot,Color1,Color2, (60 * 2)); // respawn 120 seconds (2 minutes).
		vehicles_loaded++;
	}

	fclose(file_ptr);
	printf("Loaded %d vehicles from: %s",vehicles_loaded,filename);
	return vehicles_loaded;
}

//----------------------------------------------------------

/*stock strtok(const str[], &index)
{
	new length = strlen(str);
	while ((index < length) && (str[index] <= ' '))
	{
		index++;
	}

	new offset = index;
	new result[20];
	while ((index < length) && (str[index] > ' ') && ((index - offset) < (sizeof(result) - 1)))
	{
		result[index - offset] = str[index];
		index++;
	}
	result[index - offset] = EOS;
	return result;
}*/

//------------------------------------------------

stock strrest(const str[], &index)
{
	new length = strlen(str);
	while ((index < length) && (str[index] <= ' '))
	{
		index++;
	}
	new offset = index;
	new result[128];
	while ((index < length) && ((index - offset) < (sizeof(result) - 1)))
	{
		result[index - offset] = str[index];
		index++;
	}
	result[index - offset] = EOS;
	return result;
}

//----------------------------------------------------------
// Tokenise by a delimiter
// Return str and index of the end determined by the
// provided delimiter in delim

stock token_by_delim(const str[], return_str[], delim, start_index)
{
	new x=0;
	while(str[start_index] != EOS && str[start_index] != delim) {
	    return_str[x] = str[start_index];
	    x++;
	    start_index++;
	}
	return_str[x] = EOS;
	if(str[start_index] == EOS) start_index = (-1);
	return start_index;
}

//----------------------------------------------------------

/*stock isNumeric(const str[])
{
  new length=strlen(str);
  if (length==0) return false;
  for (new i = 0; i < length; i++)
    {
      if (
            (str[i] > '9' || str[i] < '0' && str[i]!='-' && str[i]!='+') // Not a number,'+' or '-'
             || (str[i]=='-' && i!=0)                                             // A '-' but not at first.
             || (str[i]=='+' && i!=0)                                             // A '+' but not at first.
         ) return false;
    }
  if (length==1 && (str[0]=='-' || str[0]=='+')) return false;
  return true;
}*/

//----------------------------------------------------------

stock IsKeyJustDown(key, newkeys, oldkeys)
{
	if((newkeys & key) && !(oldkeys & key)) return 1;
	return 0;
}

//----------------------------------------------------------
