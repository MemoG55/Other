using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


//시저암호 인코더
namespace Hacking1
{
    internal class Program
    {
        //문장체크
        public static Boolean CharCheck(String CheckStr)
        {
            int CheckAscii;
            for (int i = 0; i < CheckStr.Length; i++)
            {
                CheckAscii = Convert.ToInt32(CheckStr[i]);
                if (CheckAscii < 65 || CheckAscii > 90)
                {
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
                return false;
            }
            return true;
        }

        //키체크 아스키코드로 체크해서 숫자 범위 내에 입력강요
        public static Boolean KeyCheck(String CheckKey)
        {
            int CheckAscii;
            for (int i = 0; i < CheckKey.Length; i++)
            {
                CheckAscii = Convert.ToInt32(CheckKey[i]);
                if ((CheckAscii < 48 || CheckAscii > 57))
                {
                    return false;
                }
            }
            return true;
        }

        public static void Main(string[] args)
        {
            String str;
            Boolean charcheck; //false 시 다시 입력
            String plus_minus;
            Boolean pmcheck;
            String S_key;
            int key;
            Boolean keycheck;
            int ascii;
            while (true)
            {
                Console.WriteLine("평문을 입력하세요.");
                str = Console.ReadLine();
                str = str.ToUpper();
                charcheck = CharCheck(str);
                if (charcheck == false) {
                    Console.WriteLine("영문자가 아닌 것이 포함됩니다.");
                    Console.WriteLine("다시 입력하세요.");
                    continue;
                }

                char[] cipher = new char[str.Length];

                while (true)
                {
                    Console.WriteLine("암호키의 부호를 설정해주세요.");
                    Console.WriteLine("+, - 중 입력!");
                    plus_minus = Console.ReadLine();
                    pmcheck = PMCheck(plus_minus);
                    if (pmcheck == false)
                    {
                        Console.WriteLine("부호가 아닌 것이 포함됩니다.");
                        Console.WriteLine("다시 입력하세요");
                        continue;
                    }


                    while (true)
                    {
                        Console.WriteLine("암호키를 입력하세요.");
                        S_key = Console.ReadLine();
                        keycheck = KeyCheck(S_key);
                        if (keycheck == false)
                        {
                            Console.WriteLine("숫자가 아닌 것이 포함됩니다.");
                            Console.WriteLine("다시 입력하세요.");
                            continue;
                        }
                        break;
                    }
                    key = int.Parse(S_key);
                    if(plus_minus == "-")
                    {
                        key = key * -1;
                    }
                    break;
                }

                key = key % 26;
                for (int i = 0; i < str.Length; i++)
                {
                    ascii = Convert.ToInt32(str[i]);
                    ascii = ascii + key;
                    if(ascii < 65)
                    {
                        ascii = ascii + 26;
                    }
                    else if (ascii > 90)
                    {
                        ascii = ascii - 26;
                    }
                    cipher[i] = Convert.ToChar(ascii);
                }
                Console.WriteLine(cipher);
            }
        }
    }
}


//시저암호 만들기
//평문받아오기 -> 암호키받아오기 -> 암호문구현