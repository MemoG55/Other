using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

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


/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


//시저암호 만들기
//시저암호 인 / 디코더
namespace Hacking1
{
    internal class Caesar
    {
        public static void Main(string[] args)
        {
            String str, plus_minus, S_key;
            Boolean strcheck, pmcheck, keycheck; //false 시 다시 입력
            int key, ascii;

            while (true)
            {
                Console.WriteLine("평문 또는 암호문을 입력하세요.");
                str = Console.ReadLine();
                str = str.ToUpper();
                strcheck = StrCheck(str);

                if (strcheck == false)
                    continue;

                char[] plain_or_cipher = new char[str.Length];

                while (true)
                {
                    Console.WriteLine("암호키 또는 복호키의 부호를 설정해주세요.");
                    Console.WriteLine("+, - 중 입력!");
                    plus_minus = Console.ReadLine();
                    pmcheck = PMCheck(plus_minus);

                    if (pmcheck == false)
                        continue;

                    break;
                }

                while (true)
                {
                    Console.WriteLine("암호키 또는 복호키를 입력하세요.");
                    S_key = Console.ReadLine();
                    keycheck = KeyCheck(S_key);

                    if (keycheck == false)
                        continue;

                    break;
                }

                key = int.Parse(S_key);

                if (plus_minus == "-")
                    key = key * -1;
                
                key = key % 26;

                for (int i = 0; i < str.Length; i++)
                {
                    ascii = Convert.ToInt32(str[i]);
                    ascii = ascii + key;

                    if (ascii < 65)
                        ascii = ascii + 26;

                    else if (ascii > 90)
                        ascii = ascii - 26;

                    plain_or_cipher[i] = Convert.ToChar(ascii);
                }
                Console.WriteLine(plain_or_cipher);
            }
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

        //부호체크
        public static Boolean PMCheck(String CheckPM)
        {
            if (CheckPM != "+" && CheckPM != "-")
            {
                Console.WriteLine("부호가 아닌 것이 포함됩니다.");
                Console.WriteLine("다시 입력하세요");
                return false;
            }
            return true;
        }

        //키체크 아스키코드로 체크해서 숫자 범위 내에 입력강요
        public static Boolean KeyCheck(String CheckKey)
        {
            int i, CheckKeyAscii;
            for (i = 0; i < CheckKey.Length; i++)
            {
                CheckKeyAscii = Convert.ToInt32(CheckKey[i]);
                if ((CheckKeyAscii < 48 || CheckKeyAscii > 57))
                {
                    Console.WriteLine("숫자가 아닌 것이 포함됩니다.");
                    Console.WriteLine("다시 입력하세요.");
                    return false;
                }
            }
            return true;
        }

    }
}
*/