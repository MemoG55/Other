using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hacking_Multiplicative
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int[,] multiplicative = new int[6, 6];
            int asciicharnumber = 65;
            int asciiintnumber = 48;
            int sequence = 0;
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (asciicharnumber < 91)
                    {
                        multiplicative[i, j] = asciicharnumber;
                        asciicharnumber++;
                    }
                    else
                    {
                        multiplicative[i, j] = asciiintnumber;
                        asciiintnumber++;
                    }
                    Console.Write(multiplicative[i, j] + " ");
                }
                Console.Write('\n');
            }
            String str, s_key;
            bool strcheck, keycheck;

            while (true)
            {
                str = ReadStr();
                strcheck = StrCheck(str);
                if (strcheck == false)
                    continue;

                while (true)
                {
                    s_key = ReadKey();
                    keycheck = KeyCheck(s_key);
                    if (keycheck == false)
                        continue;
                }
                final(str, s_key);
            }

        }

        //문장입력
        public static String ReadStr()
        {
            String str;
            Console.WriteLine("평문을 입력하세요");
            str = Console.ReadLine();
            str = str.ToUpper();
            return str;
        }

        //문장체크
        public static Boolean StrCheck(String CheckStr)
        {
            int i, CheckStrAscii;
            for (i = 0; i < CheckStr.Length; i++)
            {
                CheckStrAscii = Convert.ToInt32(CheckStr[i]);
                if (CheckStrAscii < 65 || CheckStrAscii > 90)
                {
                    Console.WriteLine("영문자가 아닌 것이 포함됩니다.");
                    Console.WriteLine("다시 입력하세요.");
                    return false;
                }
            }
            return true;
        }

        //키입력
        public static String ReadKey()
        {
            String s_key;
            Console.WriteLine("영문 암호키를 순서로 입력하세요");
            s_key = Console.ReadLine();
            return s_key;
        }

        //키체크
        public static Boolean KeyCheck(String CheckKey)
        {
            int i, CheckKeyAscii;
            for (i = 0; i < CheckKey.Length; i++)
            {
                CheckKeyAscii = Convert.ToInt32(CheckKey[i]);
                if ((CheckKeyAscii < 65 || CheckKeyAscii > 90))
                {
                    Console.WriteLine("영문자가 아닌 것이 포함됩니다.");
                    Console.WriteLine("다시 입력하세요.");
                    return false;
                }
            }
            return true;
        }

        //총계산
        public static void final(String str, String s_key)
        {
            int i;
            char[] key = new char[s_key.Length];
            for (i = 0; i < s_key.Length; i++)
            {
                key[i] = Convert.ToChar(s_key[i]);
            }
            
        }
    }
}


/*
namespace Hacking3_Substitution
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String str, s_key;
            bool strcheck, keycheck;

            while (true)
            {
                str = ReadStr();
                strcheck = StrCheck(str);
                if (strcheck == false)
                    continue;

                while (true)
                {
                    s_key = ReadKey();
                    keycheck = KeyCheck(s_key);
                    if (keycheck == false)
                        continue;
                }

                final(str, s_key);

            }
            
        }

        //문장입력
        public static String ReadStr()
        {
            String str;
            Console.WriteLine("평문을 입력하세요");
            str = Console.ReadLine();
            str = str.ToUpper();
            return str;
        }

        //문장체크
        public static Boolean StrCheck(String CheckStr)
        {
            int i, CheckStrAscii;
            for (i = 0; i < CheckStr.Length; i++)
            {
                CheckStrAscii = Convert.ToInt32(CheckStr[i]);
                if (CheckStrAscii < 65 || CheckStrAscii > 90)
                {
                    Console.WriteLine("영문자가 아닌 것이 포함됩니다.");
                    Console.WriteLine("다시 입력하세요.");
                    return false;
                }
            }
            return true;
        }

        //키입력
        public static String ReadKey()
        {
            String s_key;
            Console.WriteLine("1~9 암호키를 순서로 입력하세요");
            s_key = Console.ReadLine();
            return s_key;
        }

        //키체크
        public static Boolean KeyCheck(String CheckKey)
        {
            int i, CheckKeyAscii;
            for (i = 0; i < CheckKey.Length; i++)
            {
                CheckKeyAscii = Convert.ToInt32(CheckKey[i]);
                if ((CheckKeyAscii < 49 || CheckKeyAscii > 57))
                {
                    Console.WriteLine("1~9 숫자가 아닌 것이 포함됩니다.");
                    Console.WriteLine("다시 입력하세요.");
                    return false;
                }
            }
            return true;
        }

        //총계산
        public static void final(String str, String s_key)
        {
            int i;
            int[] key = new int[s_key.Length];
            for (i = 0; i < s_key.Length; i++)
            {
                key[i] = Convert.ToInt32(s_key[i]);
            }

        }
    }
}
 */