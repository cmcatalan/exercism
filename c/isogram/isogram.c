#include "isogram.h"

#include <stdio.h>
#include <ctype.h>

#define INIT_CHAR 'a'
#define END_CHAR 'z'
#define ARR_LEN (END_CHAR - INIT_CHAR + 1)

bool is_isogram(const char phrase[])
{
    if (!phrase)
        return false;

    bool dict[ARR_LEN] = {false};

    int i = 0;

    while (phrase[i] != '\0')
    {
        int letter_code = tolower(phrase[i]);

        if (letter_code >= INIT_CHAR && letter_code <= END_CHAR)
        {
            int dict_position = letter_code - INIT_CHAR;

            if (dict[dict_position])
                return false;

            dict[dict_position] = true;
        }

        i++;
    }

    return true;
}
