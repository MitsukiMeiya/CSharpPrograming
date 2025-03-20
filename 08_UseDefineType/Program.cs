using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_UseDefineType
{
    class Program
    {
        struct Skill
        {
            public string name;
            public float coolTime;
            public int cost;
            public float range;
        }
        /*
        enum RockpaperScissor
        {
            Rock=1,
            Scissor,
            Paper
        }
        */

        /*
        enum Equipment
        {
            Head, Body, Arm, Size
        }
        */

        static void Main(string[] args)
        {
            /*//가위 바위 보 게임
             string commend = "바위";
             switch (commend)
             {
                 case "가위":
                     Console.WriteLine("가위를 냅니다.");
                     break;
                 case "바위":
                     Console.WriteLine("바위를 냅니다.");
                     break;
                 case "보":
                     Console.WriteLine("보를 냅니다.");
                     break;
                 default:
                     Console.WriteLine("잘못 냈습니다.");
                     break;
             }
            */

            /*
            //장비 유형에 따라 여러 장비를 저장하는 배열을 만든다
            string[] equiments = new string[(int)Equipment.Size];

            //머리 부분을 사용
            // 머리 : 0번에 해당하는 공간에 저장&불러오기 할 필요가 있음
            // 여기서 0 번으로 쓰는 경우 헷갈릴 수 잇지만
            // (int)로 형변환을 이용한다면 머리라는 이름으로 명확하며 실수하지 않게 사용이 가능
            // 또한 0부터 시작한다는 열거형의 특징상 배열의 0~ 장비유형 갯수 만큼 사용도 가능
            equiments[(int)Equipment.Head] = "철투구";
            */

            Skill[] skills = new Skill[4];

            Skill fireball;
            fireball.name = "파이어볼";
            fireball.coolTime = 2.5f;
            fireball.cost = 10;
            fireball.range = 3.5f;

            Skill smash;
            smash.name = "강타";
            smash.coolTime = 10f;
            smash.cost = 3;
            smash.range = 20f;

            Skill lance;
            lance.name = "창던지기";
            lance.coolTime = 10f;
            lance.cost = 3;
            lance.range = 20f;

            Skill ultimate;
            ultimate.name = "궁극기";
            ultimate.coolTime = 10f;
            ultimate.cost = 3;
            ultimate.range = 20f;

            skills[0] = fireball;
            skills[1] = smash;
            skills[2] = lance;
            skills[3] = ultimate;

            while(true)
            {
                Console.Write("사용할 스킬 : ");
                string input = Console.ReadLine();
                int value = int.Parse(input);

                Console.WriteLine("{0} 스킬을 사용합니다.", skills[value].name);
                Console.WriteLine("마나가 {0} 감소합니다.", skills[value].cost);
                Console.WriteLine("쿨타임을 {0}초 돌립니다.", skills[value].coolTime);
                Console.WriteLine("공격 범위 {0} 을 확인합니다.", skills[value].range);
            }
        }
    }
}
