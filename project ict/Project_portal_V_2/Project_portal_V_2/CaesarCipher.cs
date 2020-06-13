using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_portal_V_2
{
    class CaesarCipher
    {
        int s = 123;
        private bool IsNumber(char ch)
        {
            int no = (int)ch - '0';
            return no >= 0 && no <= 10;
        }
        public String encrypt(String text)
        {
            String result = "";

            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsUpper(text[i]))
                {
                    char ch = (char)(((int)text[i] + s - 65) % 26 + 65);
                    result += ch;
                }
                else if (char.IsLower(text[i]))
                {
                    char ch = (char)(((int)text[i] + s - 97) % 26 + 97);
                    result += ch;
                }
                else if (IsNumber(text[i]))
                {
                    char ch = (char)(((int)text[i] + s - (int)'0') % 10 + (int)'0');
                    result += ch;
                }
                else
                {
                    result += text[i];
                }
            }
            return result;
        }
        public String decrypt(String text)
        {
            String result = "";

            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsUpper(text[i]))
                {
                    char ch = (char)((((int)text[i] - s - 65) % 26) + 26 + 65);
                    if ((int)ch - 65 > 25) ch = (char)((int)ch - 26);
                    result += ch;
                }
                else if (char.IsLower(text[i]))
                {
                    char ch = (char)((((int)text[i] - s - 97) % 26) + 26 + 97);
                    if ((int)ch - 97 > 25) ch = (char)((int)ch - 26);
                    result += ch;
                }
                else if (IsNumber(text[i]))
                {
                    char ch = (char)((((int)text[i] - s - 48) % 10) + 10 + 48);
                    if ((int)ch - 48 > 9) ch = (char)((int)ch - 10);
                    result += ch;
                }
                else
                {
                    result += text[i];
                }
            }
            return result;
        }
    }
}