using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Array
{
    class Program
    {
        static void IntTest(ref int value)
        {
            value = value + 10;
        }

        static void ArrayTest(int[] array)
        {
            array[2] = 999;
        }

        static void Main(string[] args)
        {
            /* 배열(Array)
             * 동일한 자료형의 요소들로 구성된 데이터 집함
             * 인덱스를 통하여 배열요소(Element)에 접근할 수 있음
             * 배열의 처음 요소의 인덱스는 0부터 시작함
             */

            /* <배열 기본>
             * 배열을 만들기 위해 자료형과 크기를 정하여 생성
             * 배열의 요소에 접근하기 위해 [인덱스]를 사용
             * 배열의 Length를 통해 크기를 확인
             * 자료형[] 배열이름 = new 자료형[크기];
             */
            //int[] scores = new int[5];      //크기 5의 배열 선언

            /*
            string[] shortCuts = new string[4];

            shortCuts[0] = "포션";
            shortCuts[1] = "파폭";
            shortCuts[2] = "부적";
            shortCuts[3] = "폭탄";

            for(int i = 0; i > 4; i++)
            {
                Console.WriteLine("{0}번째 아이템은 {1} 입니다.",i, shortCuts[i]);
            }
            */

            //string[,] students = new string[8, 30];

            int[] test = { 1, 2, 3, 4 };
            Console.WriteLine("함수 전 값 : {0}", test[2]);
            ArrayTest(test);
            Console.WriteLine("함수 전 값 : {0}", test[2]);
        }
    }
}
