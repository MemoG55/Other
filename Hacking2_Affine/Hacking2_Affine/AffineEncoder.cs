using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


//아핀암호 만들기
//아핀암호 인코더
//아핀암호는 시저암호와 다르게 +암호키가 아닌 암호키숫자에 따른 알파벳이 규정됨
//시저암호는 암호키를 알면 -를 붙이거나 26-암호키를 하여 복호키를 알아낼 수 있지만
//아핀암호는 ax+b <-> (x-b)a^(-1) 공식이기에 바로 구할 수 없음. 인코더 디코더 단순통합불가, (25초과거나 -25초과시 나머지로 계산) -> 1은 b, -1은 z
//모듈러 공식이기에 a^(-1)를 분모취급도 못함, 공식 필요
//가능한 키 제공 -> 역원은 단방향이 아니라 양방향임 기억해둘것 +++++++
namespace Hacking2_Affine
{
    internal class AffineEncoder
    {
        public static void Main(string[] args)
        {
            //변수선언들
            String str, plus_minus0, plus_minus1, S_key0, S_key1;
            Boolean strcheck, pmcheck, keycheck; //false 시 다시 입력
            int key0, key1, ascii, i;

            //반복문 시작
            while (true)
            {
                Console.WriteLine("평문을 입력하세요.");
                str = Console.ReadLine();
                str = str.ToUpper();
                strcheck = StrCheck(str);

                if (strcheck == false)
                    continue;

                char[] plain_or_cipher = new char[str.Length];

                //첫번째 암호키 설정
                while (true)
                {
                    Console.WriteLine("첫번째 암호키의 부호를 설정해주세요.");
                    Console.WriteLine("+, - 중 입력!");
                    plus_minus0 = Console.ReadLine();
                    pmcheck = PMCheck(plus_minus0);

                    if (pmcheck == false)
                        continue;

                    break;
                }
                while (true)
                {
                    Console.WriteLine("첫번째 암호키를 입력하세요.");
                    S_key0 = Console.ReadLine();
                    keycheck = KeyCheck(S_key0);

                    if (keycheck == false)
                        continue;

                    break;
                }

                //두번째 암호키 설정
                while (true)
                {
                    Console.WriteLine("두번째 암호키의 부호를 설정해주세요.");
                    Console.WriteLine("+, - 중 입력!");
                    plus_minus1 = Console.ReadLine();
                    pmcheck = PMCheck(plus_minus1);

                    if (pmcheck == false)
                        continue;

                    break;
                }
                while (true)
                {
                    Console.WriteLine("두번째 암호키를 입력하세요.");
                    S_key1 = Console.ReadLine();
                    keycheck = KeyCheck(S_key1);

                    if (keycheck == false)
                        continue;

                    break;
                }

                //공식 시작
                int.TryParse(S_key0, out key0);
                int.TryParse(S_key1, out key1);

                if (plus_minus0 == "-")
                    key0 = key0 * -1;
                if (plus_minus1 == "-")
                    key1 = key1 * -1;

                for (i = 0; i < str.Length; i++)
                {
                    ascii = Convert.ToInt32(str[i]);
                    ascii = (ascii - 65) * key0 + key1;

                    if (ascii < 0)
                        ascii = (ascii % 26) + 26;

                    if (ascii > 25)
                        ascii = ascii % 26;
                    

                    ascii = ascii + 65;
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