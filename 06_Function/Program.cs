using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Function
{
    class Program
    {
        /*
        static void PrintProfile(string name, string phone)
        {
            if (name == "")
            {
                Console.WriteLine("이름을 입력해주세요.");
                return;  //void 반환형에서 return을 진행하는 경우 함수가 종료됨.
            }
        }
        */

        /*
        static void TripleShot(int damage1,int damage2, int damage3)
        {
            Console.WriteLine("찌르기! : {0}",damage1);
            Console.WriteLine("베기! : {0}",damage2);
            Console.WriteLine("때리기! : {0}",damage3);
        }
        */

        /*
        static string MakeFishCake(string taste, float time)
        {
            if (taste == "")
            {
                Console.WriteLine("앙금없는 붕어빵은 만들수 없습니다.");
                return "속 없는 붕어빵";
            }
        
            Console.WriteLine("반죽물을 붓습니다.");
            Console.WriteLine("{0} 앙금을 넣습니다.",taste);
            if (time < 20)
            {
                Console.WriteLine("{0} 초 동안 굽습니다.", time);
                Console.WriteLine("붕어빵 완성!");
                return;
            }
        }
        /*

        /* 함수 (Function)
            * 미리 정해진 동작을 수행하는 코드 묶음
            * 어떤 처리를 미리 함수로 만들어 두면 다시 반복적으로 사용가능
            */

        /*
        static int Divide(int left, int right, out int remain)
        {
            remain = left % right;
            return left / right;
        }
        */

        static void Swap(ref int left, ref int right)
        {
            int temp = left;
            left = right;
            right = temp;
        }

        /* 반환형 (Return Type)
         * 함수의 결과(출력) 데이터의 자료형
         * 함수가 끝나기전까지 반드시 return으로 반환형에 맞는 데이터를 출력해야함
         * 함수 진행 중 return을 만나는 경우 그 즉시 결과 데이터를 반환하고 함수가 종료됨
         * 함수의 결과(출력)이 없는 경우 반환형은 void이며 ruturn을 생략가능
         */

        static void Main(string[] args)
        {
            /*
            while(true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                        Console.WriteLine("위로 이동!");
                        break;
                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                        Console.WriteLine("왼쪽 이동!");
                        break;
                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        Console.WriteLine("아래 이동!");
                        break;
                    case ConsoleKey.D:
                    case ConsoleKey.RightArrow:
                        Console.WriteLine("오른쪽 이동!");
                        break;
                }
            }
            */

            /*
            int result;
            int remain;

            result = Divide(11, 3, out remain);
            Console.WriteLine("11 / 3은 몫 {0} 나머지 {1}", result, remain);
            */

            int a = 10;
            int b = 20;

            //두 숫자를 교체하는 기능
            Swap(ref a, ref b);

            //a : 20, b : 10
            Console.WriteLine("a : {0}, b : {1}", a, b);
        }
    }
}