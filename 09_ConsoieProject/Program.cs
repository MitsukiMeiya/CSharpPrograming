using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace _09_ConsoleProject
{
    class Program
    {
        struct Position
        {
            public int x;
            public int y;
        }
        static void Main(string[] args)
        {
            bool gameOver = false;
            Position playerPos;
            Position goalPos;
            bool[,] map; 

            Start(out playerPos, out goalPos, out map);
            while (gameOver == false)
            {
                Render(playerPos, goalPos, map);
                ConsoleKey Key = Input();
                Update(Key, ref playerPos, goalPos, map, ref gameOver);
            }
            End();
        }

        // 시작 작업
        static void Start(out Position playerPos, out Position goalPos, out bool[,] map)
        {
            // 게임 설정
            Console.CursorVisible = false;
            // 플레이어 초기 위치 설정하기
            playerPos.x = 1;
            playerPos.y = 1;
            // 목적지 위치 설정하기
            goalPos.x = 13;
            goalPos.y = 8;
            // 맵 설정하기
            map = new bool[10,15]
            {
                     //  0      1      2     3       4      5     6       7      8     9      10     11     12     13     14
               /*0*/ { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false },
               /*1*/ { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
               /*2*/ { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
               /*3*/ { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
               /*4*/ { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
               /*5*/ { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
               /*6*/ { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
               /*7*/ { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
               /*8*/ { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
               /*9*/ { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false },
            };

            ShowTitle();
        }
        // 타이틀 출력
        static void ShowTitle()
        {
            Console.WriteLine("------------------------");
            Console.WriteLine("레전드 미로 찾기");
            Console.WriteLine("------------------------");
            Console.WriteLine();
            Console.WriteLine("아무키다 눌러서 시작하세요...");

            Console.ReadKey(true);
            Console.Clear();
        }
        // 출력 작업
        static void Render(Position playerPos, Position goalPos, bool[,] map)
        {
            // 콘솔 지우기
            Console.Clear();
            PrintMap(map);
            PrintGoal(goalPos);
            PrintPlayer(playerPos);
        }
        // 맵 출력
        static void PrintMap(bool[,] map)
        {
            //맵출력
            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    if (map[y, x] == false)
                    {
                        Console.Write('#');  //벽
                    }
                    else
                    {
                        Console.Write(' ');  // 빈 공간
                    }
                }
                Console.WriteLine();
            }
        }
        // 플레이어 출력
        static void PrintPlayer(Position playerPos)
        {
            // 플레이어 위치로 커서 옮기기
            Console.SetCursorPosition(playerPos.x, playerPos.y);
            // 플레이어 출력
            Console.ForegroundColor = ConsoleColor.Green; // 플레이어 색 변경
            Console.Write('P');
            Console.ResetColor();
        }
        // 골 출력
        static void PrintGoal(Position goalPos)
        {
            Console.SetCursorPosition(goalPos.x, goalPos.y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write('G');
            Console.ResetColor();
        }
        // 입력 작업
        static ConsoleKey Input()
        {
            return Console.ReadKey(true).Key;
        }
        // 처리 작업
        static void Update(ConsoleKey key, ref Position playerPos, Position goalPos, bool[,] map, ref bool gameOver)
        {
            Move(key, ref playerPos, map);
            bool isClear=CheckGameClear(playerPos, goalPos);
            if (isClear)
            {
                // 게임 종료
                gameOver = true;
            }
        }
        // 이동
        static void Move(ConsoleKey key, ref Position playerPos, bool[,] map)
        {
            switch (key)
            {
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    //이동하기 전 벽이 있는지 확인해서 벽이 아니면 움직이게
                    if (map[playerPos.y, playerPos.x - 1] == true)
                    {
                        playerPos.x--;
                    }
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    if (map[playerPos.y, playerPos.x + 1] == true)
                    {
                        playerPos.x++;
                    }
                    break;
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    if (map[playerPos.y - 1, playerPos.x] == true)
                    {
                        playerPos.y--;
                    }
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    if (map[playerPos.y + 1, playerPos.x] == true)
                    {
                        playerPos.y++;
                    }
                    break;
            }
        }
        // 클리어 조건 확인
        static bool CheckGameClear(Position playerPos, Position goalPos)
        {
            // 플레이어가 골 위치에 도달했을 때
            // 플레이어의 x위치가 골 x위치랑 같으면서 동시에
            // 플레이어의 y위치가 골 y위치랑 같으면
            bool success = (playerPos.x == goalPos.x) && (playerPos.y == goalPos.y);
            // 게임은 클리어 되었다 라고 판정
            return success;
        }
        // 종료 작업
        static void End()
        {
            Console.Clear();
            Console.WriteLine("축하합니다!!!! 미로 찾기에 성공하셨습니다.");
        }
    }
}
