using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _99_Test
{
    class Program
    {
        static int[] solution(int n)
        {
            int[] answer = new int[n];
            for (int i = 0; i < n; i++)
            {
                if (i % 2 != 0)
                {
                    answer[i]= i;
                }
                Console.Write(answer[i]);
            }
            return answer;
        }
        static void Main(string[] args)
        {
            solution(10);
        }
    }
}
