using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//아핀암호는 시저암호와 다르게 +암호키가 아닌 암호키숫자에 따른 알파벳이 규정됨
//인코더 공식 : 
//디코더 공식 : 
/*
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

    //y-x = 26 * 몫
    //5x-1 = 26 * 몫
    //몫 = 4
    //x = 21

*/

namespace Hacking2_Affine
{
    internal class Program
    {
        //ascii변환
        public static int[] strChange(String Changestr)
        {
            int i;
            int[] ChangeAscii=new int[Changestr.Length];
            for (i = 0; i < Changestr.Length; i++)
                ChangeAscii[i] = Convert.ToInt32(Changestr[i]);
            return ChangeAscii;
        }

        //문장체크
        public static Boolean CharCheck(String CheckStr)
        {

            int CheckAscii;
            for (int i = 0; i < CheckStr.Length; i++)
            {
                CheckAscii = Convert.ToInt32(CheckStr[i]);
                if (CheckAscii < 65 || CheckAscii > 90)
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
            int CheckAscii;
            for (int i = 0; i < CheckKey.Length; i++)
            {
                CheckAscii = Convert.ToInt32(CheckKey[i]);
                if ((CheckAscii < 48 || CheckAscii > 57))
                {
                    Console.WriteLine("숫자가 아닌 것이 포함됩니다.");
                    Console.WriteLine("다시 입력하세요.");
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
                if (charcheck == false)
                    continue;

                char[] cipher = new char[str.Length];

                while (true)
                {
                    Console.WriteLine("암호키의 부호를 설정해주세요.");
                    Console.WriteLine("+, - 중 입력!");
                    plus_minus = Console.ReadLine();
                    pmcheck = PMCheck(plus_minus);
                    if (pmcheck == false)
                        continue;

                    while (true)
                    {
                        Console.WriteLine("암호키를 입력하세요.");
                        S_key = Console.ReadLine();
                        keycheck = KeyCheck(S_key);
                        if (keycheck == false)
                            continue;
                        break;
                    }

                    key = int.Parse(S_key);
                    if(plus_minus == "-")
                        key = key * -1;
                    break;
                }

                key = key % 26;
                for (int i = 0; i < str.Length; i++)
                {
                    ascii = Convert.ToInt32(str[i]);
                    ascii = ascii + key;
                    if(ascii < 65)
                        ascii = ascii + 26;
                    else if (ascii > 90)
                        ascii = ascii - 26;

                    cipher[i] = Convert.ToChar(ascii);
                }
                Console.WriteLine(cipher);
            }
        }
    }
}


//시저암호 만들기
//평문받아오기 -> 암호키받아오기 -> 암호문구현*/