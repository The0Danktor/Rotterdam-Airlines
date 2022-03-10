using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rotterdam_Airlines
{
    internal class IdHandler
    {
        //DECLARE REFERENCE LIST FOR SUBTRACTION
        private static int[] numRef()
        {
            int[] array = {1,   2,   3,   4,   5,   6,   7,   8,   9, 
                     10,  11,  12,  13,  14,  15,  16,  17,  18,  19, 
                     20,  21,  22,  23,  24,  25,  26,  27,  28,  29, 
                     30,  31,  32,  33,  34,  35,  36,  37,  38,  39, 
                     40,  41,  42,  43,  44,  45,  46,  47,  48,  49, 
                     50,  51,  52,  53,  54,  55,  56,  57,  58,  59, 
                     60,  61,  62,  63,  64,  65,  66,  67,  68,  69, 
                     70,  71,  72,  73,  74,  75,  76,  77,  78,  79, 
                     80,  81,  82,  83,  84,  85,  86,  87,  88,  89, 
                     90,  91,  92,  93,  94,  95,  96,  97,  98,  99, 
                    100, 101, 102, 103, 104, 105, 106, 107, 108, 109, 
                    110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 
                    120, 121, 122, 123, 124, 125, 126, 127, 128, 129, 
                    130, 131, 132, 133, 134, 135, 136, 137, 138, 139, 
                    140, 141, 142, 143, 144, 145, 146, 147, 148, 149, 
                    150, 151, 152, 153, 154, 155, 156, 157, 158, 159, 
                    160, 161, 162, 163, 164, 165, 166, 167, 168, 169, 
                    170, 171, 172, 173, 174, 175, 176, 177, 178, 179, 
                    180, 181, 182, 183, 184, 185, 186, 187, 188, 189, 
                    190, 191, 192, 193, 194, 195, 196, 197, 198, 199, 
                    200, 201, 202, 203, 204, 205, 206, 207, 208, 209, 
                    210, 211, 212, 213, 214, 215, 216, 217, 218, 219, 
                    220, 221, 222, 223, 224, 225, 226, 227, 228, 229, 
                    230, 231, 232, 233, 234, 235, 236, 237, 238, 239,
                    240, 241, 242, 243, 244, 245, 246, 247, 248, 249, 
                    250, 251, 252, 253, 254, 255 };
            return array;
        }

        //DECLARE BASE64 REFERENCE LIST FOR DECODING/ENCODING
        private static IDictionary<string, string> baseRef()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>()
            {
                { "000000", "A" },
                { "000001", "B" },
                { "000010", "C" },
                { "000011", "D" },
                { "000100", "E" },
                { "000101", "F" },
                { "000110", "G" },
                { "000111", "H" },
                { "001000", "I" },
                { "001001", "J" },
                { "001010", "K" },
                { "001011", "L" },
                { "001100", "M" },
                { "001101", "N" },
                { "001110", "O" },
                { "001111", "P" },
                { "010000", "Q" },
                { "010001", "R" },
                { "010010", "S" },
                { "010011", "T" },
                { "010100", "U" },
                { "010101", "V" },
                { "010110", "W" },
                { "010111", "X" },
                { "011000", "Y" },
                { "011001", "Z" },
                { "011010", "a" },
                { "011011", "b" },
                { "011100", "c" },
                { "011101", "d" },
                { "011110", "e" },
                { "011111", "f" },
                { "100000", "g" },
                { "100001", "h" },
                { "100010", "i" },
                { "100011", "j" },
                { "100100", "k" },
                { "100101", "l" },
                { "100110", "m" },
                { "100111", "n" },
                { "101000", "o" },
                { "101001", "p" },
                { "101010", "q" },
                { "101011", "r" },
                { "101100", "s" },
                { "101101", "t" },
                { "101110", "u" },
                { "101111", "v" },
                { "110000", "w" },
                { "110001", "x" },
                { "110010", "y" },
                { "110011", "z" },
                { "110100", "0" },
                { "110101", "1" },
                { "110110", "2" },
                { "110111", "3" },
                { "111000", "4" },
                { "111001", "5" },
                { "111010", "6" },
                { "111011", "7" },
                { "111100", "8" },
                { "111101", "9" },
                { "111110", "-" },
                { "111111", "_" },
            };
            return dict;
        }

        //RETURN RANDOMLY GENERATED ID
        public static string getID()
        {
            //CREATE RANDOM ID
            Random rnd = new Random();
            //int[] values = { rnd.Next(1, 256), rnd.Next(1, 256), rnd.Next(1, 256), rnd.Next(1, 256), rnd.Next(1, 256), rnd.Next(1, 256) };
            int[] getValues()
            {
                return new int[] { 34, 124, 234, 21, 42, rnd.Next(1, 256) };
            }

            //CHECK AND SAVE ID
            Dictionary<string, List<int>> jsonDict = JSON.LoadIdJSON();

            int[] idCheck()
            {
                int[] values = getValues();
                string key = "";
                for (int i = 0; i < 5; i++)
                {
                    int value = values[i];
                    string s = value.ToString();
                    if (s.Length == 1) { s = "00" + s; }
                    if (s.Length == 2) { s = "0" + s; }
                    key += s;
                }

                if (jsonDict.ContainsKey(key))
                {
                    List<int> usedValues = (List<int>)jsonDict[key];
                    if (usedValues.Contains(values[5]))
                    {
                        values = idCheck();
                        return values;
                    }
                    usedValues.Add(values[5]);
                    usedValues.Sort();
                    jsonDict[key] = usedValues;
                }
                else
                {
                    List<int> newValues = new List<int>();
                    newValues.Add(values[5]);
                    newValues.Sort();
                    jsonDict[key] = newValues;
                }
                return values;
            }

            int[] values;
            values = idCheck();
            JSON.SaveIdJSON(jsonDict);

            //ENCODE ID TO BASE64
            string id = encodeID(values);

            return id;
        }

        //REMOVE GIVEN ID FROM DATABASE
        public static void removeID(string id)
        {
            
        }

        //CLEAR THE DATABASE
        public static void clearID()
        {

        }

        //ENCODE A DECIMAL VALUE TO BASE64
        private static string encodeID(int[] values)
        {
            //CONVERT TO BINARY
            string binary = "";
            string zeros = "";
            foreach (int num in values)
            {
                string result = Convert.ToString(num, 2);
                zeros = "";
                for (int i = 0; i < (8 - result.Length); i++)
                {
                    zeros += "0";
                }
                binary += zeros + result;
            }

            //CONVERT TO BASE64
            string base64 = "";
            for (int i = 0; i < (binary.Length / 6); i++)
            {
                string key = binary.Substring(6 * i, 6);
                base64 += baseRef()[key];
            }
            return base64;
        }

        //DECODE A BASE64 VALUE BACK TO DECIMAL
        private static int[] decodeID(string id)
        {
            return new int[] { 255, 255, 255, 255, 255, 255 };
        }
    }
}
