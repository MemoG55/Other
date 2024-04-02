using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hacking2_Affine
{//3, 6 MYNAMEIS
 //3, 2 ILOVEMYSCHOOL
    internal class Program
    {
        static void Main(string[] args)
        {
            String strOriginal = "MYNAMEIS";//평문
            int i;
            int ascii;
            char[] cipher = new char[strOriginal.Length];
            for (i = 0; i < strOriginal.Length; i++)
            {
                ascii = Convert.ToInt32(strOriginal[i]);
                ascii = (ascii - 65) * 3 + 6; //암호키
                if (ascii > 25)
                {
                    ascii = ascii % 26;
                }
                ascii = ascii + 65;
                cipher[i] = Convert.ToChar(ascii);
            }
            Console.WriteLine(cipher);
        }
    }
}