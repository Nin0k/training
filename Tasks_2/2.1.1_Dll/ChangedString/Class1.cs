using System;
using System.Linq;


namespace ChangedString
{
    public class СhangedString
    {
        public char[] new_string;

        public int Length
        {
            get
            {
                return new_string.Length;
            }
        }
        public char this[int index]
        {
            get
            {
                return new_string[index];
            }
            set
            {
                new_string[index] = value;
            }
        }
        public СhangedString(char[] new_string)
        {
            this.new_string = new_string;
        }
        public СhangedString(string input_string)
        {
            this.new_string = new char[input_string.Length];

            for (int i = 0; i < input_string.Length; i++)
            {
                new_string[i] = input_string[i];
            }
        }

        public void GetInfo()
        {

            for (int i = 0; i < new_string.Length; i++)
            {
                Console.Write($"{new_string[i]} ");
            }

        }
        public bool СompareStrings(СhangedString string_two)
        {
            bool rezult = false;
            if (this.Length == string_two.Length)
            {
                for (int i = 0; i < this.Length; i++)
                {
                    if (this[i] != string_two[i])
                    {
                        return false;
                    }
                    else
                    {
                        rezult = true;
                    }
                }
            }
            return rezult;
        }

        public static СhangedString operator +(СhangedString string_one, СhangedString string_two)
        {
            return new СhangedString(string_one.new_string.Concat(string_two.new_string).ToArray());

        }

        public int SearchChar(char wanted)
        {
            int k = -1;

            for (int i = 0; i < this.Length; i++)
            {
                if (this[i] == wanted)
                {
                    return i;
                }
            }
            return k;
        }
        public int SearchChar(char wanted, int n)
        {
            int k = -1;

            for (int i = n; i < this.Length; i++)
            {
                if (this[i] == wanted)
                {
                    return i;
                }
            }
            return k;
        }
        public int LastSearchChar(char wanted)
        {
            int k = -1;

            for (int i = Length - 1; i > 0; i--)
            {
                if (this[i] == wanted)
                {
                    return i;
                }
            }
            return k;
        }
        public string NoArray()
        {
            string str = new string(this.new_string);
            return str;

        }
        public bool RepeatSymbol(char symbol)
        {
            bool rezult = false;
            for (int i = 0; i < this.Length; i++)
            {
                if (this[i] == symbol)
                {
                    if (this[i + 1] == symbol)
                    {
                        rezult = true;
                    }
                }
            }
            return rezult;
        }
    }
}
