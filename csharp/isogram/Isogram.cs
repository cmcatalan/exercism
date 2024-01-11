public static class Isogram
{
    private const char INIT_CHAR = 'a', END_CHAR = 'z';
    private const int ARR_LEN = END_CHAR - INIT_CHAR + 1;
    public static bool IsIsogram(string word)
    {
        var dict = new bool[ARR_LEN];

        for (int i = 0; i < word.Length; i++)
        {
            int letter_code = char.ToLower(word[i]);

            if (letter_code >= INIT_CHAR && letter_code <= END_CHAR)
            {
                int dict_position = letter_code - INIT_CHAR;

                if (dict[dict_position]) return false;

                dict[dict_position] = true;
            }
        }

        return true;
    }
}
