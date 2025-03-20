using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Loop
{
    class Program
    {
        static void Main(string[] args)
        {
            /*************************************************************
             * for 반복문
             * 초기화, 조건식, 증감연산으로 구성된 반복분
             *************************************************************/

            // for (int i = 0; i < 10; i++)
            // {
            //     Console.WriteLine("똑같은 작업 {0}",i);
            // }

            // 삼육구
            // Console.WriteLine("삼육구 삼육구 삼육구 삼육구");
            // for (int i = 1; i < 11; i++)
            // {
            //     if (i % 3 == 0)
            //     {
            //         Console.WriteLine("짝");
            //     }
            //     else
            //     {
            // 
            //         Console.WriteLine(i);
            //     }
            // }

            // 홀짝게임
            // Console.WriteLine("홀짝게임");
            // for(int i = 0; i < 10; i++)
            // {
            //     if (i % 2 == 0)
            //         Console.WriteLine("{0} : 짝", i);
            //     else
            //         Console.WriteLine("{0} : 홀", i);
            // }

            // 이중반복
            // for(int i = 0; i < 3; i++)
            // {
            //     for(int j = 0; j < 3; j++)
            //     {
            //         Console.WriteLine("반복한다!");
            //     }
            // }

            // Console.WriteLine("구구단");
            // for(int dan = 2; dan < 10; dan++)
            // {
            //     Console.WriteLine("{0}단!", dan);
            //     for(int number = 1; number < 10; number++)
            //     {
            //         Console.WriteLine("{0} * {1} = {2}", dan, number, dan * number);
            //     }
            //     Console.WriteLine();
            // }

            /*************************************************************
             * while 반복문
             * 조건식의 true, false에 따라 블록을 반복하는 반복문
             *************************************************************/

            // 동전교환기
            // int coin = 200;
            // while (coin > 0)
            // {
            //     Console.WriteLine("100원 동전을 꺼냅니다");
            //     coin -= 100;
            // }

            /************************************************************* 
             * do while 반복문
             * 블록을 한번 실행 후 조건식의 true, false에 따라 블록을 반복하는 반복분
             *************************************************************/

            // int choice;
            // do
            // {
            //     Console.Write("1에서 9 사이의 수를 입력하세요 : ");
            //     string input = Console.ReadLine();
            //     int.TryParse(input, out choice);
            // } while ((1 < choice && choice <= 9) == false);

            /************************************************************* 
             * break 제어문
             * 가장 가까운 반복문을 종료
             *************************************************************/

            // int potionPos = 800;
            // for(int i = 1; i < 1000; i++)
            // {
            //     Console.WriteLine("{0}번째칸에 포션이 있는지 확인합니다.", i);
            //     if (i == potionPos)
            //     {
            //         Console.WriteLine("포션을 찾았습니다.");
            //         Console.WriteLine("포션을 사용합니다.");
            //     }
            // }

            // while (true)
            // {
            //     Console.WriteLine("1. 공격한다. / 2. 방어한다. / 3. 도망친다.");
            //     Console.Write("행동을 선택하세요 : ");
            //     string input = Console.ReadLine();
            //     if (input == "1")
            //     {
            //         Console.WriteLine("플레이어가 공격합니다.");
            //     }
            //     else if (input == "2")
            //     {
            //         Console.WriteLine("플레이어가 방어합니다.");
            //     }
            //     else if (input == "3")
            //     {
            //         Console.WriteLine("플레이어가 도망칩니다.");
            //         break;
            //     }
            //     else
            //     {
            //         Console.WriteLine("잘못 입력했습니다.");
            //     }
            //     Console.WriteLine();
            // }

            // int num = 35;
            // for(int i = 2; i < num; i++)
            // {
            //     if (num % i == 0)
            //     {
            //         Console.WriteLine($"{num}을 나눌 수 있는 가장 작은 수는 {i} 입니다.");
            //         break;
            //     }
            // }

            /************************************************************* 
            * continue 제어문
            * 가장 가까운 반복문의 새 반복을 시작
            *************************************************************/

            // 홀수는 아군, 짝수는 적군
            // for(int i=1; i <=8; i++)
            // {
            //     if (i % 2 == 1)
            //         continue;
            // 
            //     Console.WriteLine("{0}번 플레이어를 공격합니다.", i);
            // }

            // 4번 플레이어가 무적, 6번 플레이어는 내 캐릭터 일때
            for(int i=1; i <=8; i++)
            {
                if (i == 4)
                {
                    Console.WriteLine("4번 플레이어는 무적이라 공격하지 못합니다.");
                    continue;
                }

                if (i == 6)
                {
                    Console.WriteLine("4번 플레이어는 내 캐릭터라서 공격하지 않습니다.");
                    continue;
                }

                Console.WriteLine("{0}번 플레이어를 공격합니다.", i);
            }
        }
    }
}