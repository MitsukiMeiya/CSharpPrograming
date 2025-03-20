using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_Project_S
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
            char[,] map;

            Start(out playerPos, out map);
            while (gameOver == false)
            {
                Render(playerPos, map);
                ConsoleKey key = Input();
                Update(key, ref playerPos, map, ref gameOver);
            }
            End();
        }
        static void Start(out Position playerPos, out char[,] map)
        {
            // 게임 설정
            Console.CursorVisible = false;

            // 플레이어 위치 설정
            playerPos.x = 4;
            playerPos.y = 4;

            // 맵 설정
            map = new char[8, 8]
            {
                { ' ', ' ', '▒', '▒', '▒', ' ', ' ', ' '},
                { ' ', ' ', '▒', '□', '▒', ' ', ' ', ' '},
                { ' ', ' ', '▒', ' ', '▒', '▒', '▒', '▒'},
                { '▒', '▒', '▒', '■', ' ', '■', '□', '▒'},
                { '▒', '□', ' ', '■', ' ', '▒', '▒', '▒'},
                { '▒', '▒', '▒', '▒', '■', '▒', ' ', ' '},
                { ' ', ' ', ' ', '▒', '□', '▒', ' ', ' '},
                { ' ', ' ', ' ', '▒', '▒', '▒', ' ', ' '},
            };
        }
        static void Render(Position playerPos, char[,] map)
        {
            Console.SetCursorPosition(0, 0);
            PrintMap(map);
            PrintPlayer(playerPos);
        }
        static void PrintMap(char[,] map)
        {
            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    Console.Write(map[y, x]);
                }
                Console.WriteLine();
            }
        }
        static void PrintPlayer(Position playerPos)
        {
            Console.SetCursorPosition(playerPos.x, playerPos.y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write('▼');
            Console.ResetColor();
        }
        static ConsoleKey Input()
        {
            return Console.ReadKey(true).Key;
        }
        static void Update(ConsoleKey key, ref Position playerPos, char[,] map, ref bool gameOver)
        {
            Move(key, ref playerPos, map);
            bool isClear = IsClear(map);
            if (isClear==true)
            {
                gameOver = true;
            }
        }
        static void Move(ConsoleKey key, ref Position playerPos, char[,] map)
        {
            // 지금 상황 : 4방향에 대해서 모두 다 만들어둔 경우
            // 개선 사항 : 방향만 다를 뿐, 밀리고 못 밀리고에 대한 내용은 공통적이다
            // 플레이어 위치, 움직일 위치, 그 뒤 위치
            Position targetPos;
            Position overPos;

            switch (key)
            {
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    targetPos.x = playerPos.x - 1;
                    targetPos.y = playerPos.y;
                    overPos.x = playerPos.x - 2;
                    overPos.y = playerPos.y;
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    targetPos.x = playerPos.x + 1;
                    targetPos.y = playerPos.y;
                    overPos.x = playerPos.x + 2;
                    overPos.y = playerPos.y;
                    break;
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    targetPos.x = playerPos.x;
                    targetPos.y = playerPos.y - 1;
                    overPos.x = playerPos.x;
                    overPos.y = playerPos.y - 2;
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    targetPos.x = playerPos.x;
                    targetPos.y = playerPos.y + 1;
                    overPos.x = playerPos.x;
                    overPos.y = playerPos.y + 2;
                    break;
                default:
                    return;
            }

            // 움직이는 방향에 박스가 있을 때
            if (map[targetPos.y, targetPos.x] == '■')
            {
                // 그 다음 위치에 골이 있을 때
                if(map[overPos.y, overPos.x] == '□')
                {
                    // 1. 골 위치에 골 박스로
                    map[overPos.y, overPos.x] = '▣';
                    // 2. 박스 위치를 빈 칸으로
                    map[targetPos.y, targetPos.x] = ' ';
                    // 3. 플레이어를 움직이려는 위치로
                    playerPos.x = targetPos.x;
                    playerPos.y = targetPos.y;
                }
                // 그 다음 위치에 빈칸이 있을 때
                else if(map[overPos.y, overPos.x] == ' ')
                {
                    // 1. 빈칸 위치에 박스로
                    map[overPos.y, overPos.x] = '■';
                    // 2. 박스 위치를 빈 칸으로
                    map[targetPos.y, targetPos.x] = ' ';
                    // 3. 플레이어를 움직이려는 위치로
                    playerPos.x = targetPos.x;
                    playerPos.y = targetPos.y;
                }
            }
            // 움직이는 방향에 골이 있을 때
            else if (map[targetPos.y, targetPos.x] == '□')
            {
                playerPos.x = targetPos.x;
                playerPos.y = targetPos.y;
            }
            // 움직이는 방향에 골 박스가 있을 때
            else if (map[targetPos.y, targetPos.x] == '▣')
            {
                // 그 다음 위치에 골이 있을 때
                if (map[overPos.y, overPos.x] == '□')
                {
                    // 1. 골 위치에 골 박스로
                    map[overPos.y, overPos.x] = '▣';
                    // 2. 박스 위치를 빈 칸으로
                    map[targetPos.y, targetPos.x] = ' ';
                    // 3. 플레이어를 움직이려는 위치로
                    playerPos.x = targetPos.x;
                    playerPos.y = targetPos.y;
                }
                // 그 다음 위치에 빈칸이 있을 때
                else if (map[overPos.y, overPos.x] == ' ')
                {
                    // 1. 빈칸 위치에 박스로
                    map[overPos.y, overPos.x] = '■';
                    // 2. 박스 위치를 빈 칸으로
                    map[targetPos.y, targetPos.x] = ' ';
                    // 3. 플레이어를 움직이려는 위치로
                    playerPos.x = targetPos.x;
                    playerPos.y = targetPos.y;
                }
            }
            // 움직이는 방향에 빈 칸이 있을 때
            else if (map[targetPos.y, targetPos.x] == ' ')
            {
                playerPos.x = targetPos.x;
                playerPos.y = targetPos.y;
            }
            // 움직이는 방향에 벽이 있을 때
            else if (map[targetPos.y, targetPos.x] == '▒')
            {
                //아무것도 안함
            }

            /*
            switch (key)
            {
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    // 움직이는 방향에 박스가 있을 때
                    if (map[playerPos.y, playerPos.x - 1] == '■')
                    {
                        // 1. 박스의 목적지가 벽이나 박스인 경우
                        if (map[playerPos.y, playerPos.x - 2] == '▒' ||
                           map[playerPos.y, playerPos.x - 2] == '■')
                        {
                            //밀리면 안된다.
                        }
                        // 2. 박스의 목적지에 빈칸인 경우
                        else if (map[playerPos.y, playerPos.x - 2] == ' ')
                        {
                            //박스를 밀고 이동한다.
                            map[playerPos.y, playerPos.x - 1] = ' ';
                            map[playerPos.y, playerPos.x - 2] = '■';
                            playerPos.x--;
                        }
                        // 3. 박스의 목적지가 골인 경우
                        else if (map[playerPos.y, playerPos.x - 2] == '□')
                        {
                            //박스를 밀어서 골에 넣고 이동한다.
                            map[playerPos.y, playerPos.x - 1] = ' ';
                            map[playerPos.y, playerPos.x - 2] = '▣';
                            playerPos.x--;
                        }
                    }
                    // 움직이려는 방향에 골 안에 있는 박스가 있을 때
                    else if (map[playerPos.y, playerPos.x - 1] == '▣')
                    {
                        // 1. 밀릴 위치가 빈칸인 경우
                        if (map[playerPos.y, playerPos.x - 2] == ' ')
                        {
                            map[playerPos.y, playerPos.x - 1] = '□';
                            map[playerPos.y, playerPos.x - 2] = '■';
                            playerPos.x--;
                        }
                        // 2. 밀릴 위치가 골인 경우
                        else if (map[playerPos.y, playerPos.x - 2] == '□')
                        {
                            map[playerPos.y, playerPos.x - 1] = '□';
                            map[playerPos.y, playerPos.x - 2] = '▣';
                            playerPos.x--;
                        }
                    }
                    // 빈칸이면 이동한다
                    else if (map[playerPos.y, playerPos.x - 1] == ' ' ||
                             map[playerPos.y, playerPos.x - 1] == '□')
                    {
                        playerPos.x--;
                    }
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    // 움직이는 방향에 박스가 있을 때
                    if (map[playerPos.y, playerPos.x + 1] == '■')
                    {
                        // 1. 박스의 목적지가 벽이나 박스인 경우
                        if (map[playerPos.y, playerPos.x + 2] == '▒' ||
                           map[playerPos.y, playerPos.x + 2] == '■')
                        {
                            //밀리면 안된다.
                        }
                        // 2. 박스의 목적지에 빈칸인 경우
                        else if (map[playerPos.y, playerPos.x + 2] == ' ')
                        {
                            //박스를 밀고 이동한다.
                            map[playerPos.y, playerPos.x + 1] = ' ';
                            map[playerPos.y, playerPos.x + 2] = '■';
                            playerPos.x++;
                        }
                        // 3. 박스의 목적지가 골인 경우
                        else if (map[playerPos.y, playerPos.x + 2] == '□')
                        {
                            //박스를 밀어서 골에 넣고 이동한다.
                            map[playerPos.y, playerPos.x + 1] = ' ';
                            map[playerPos.y, playerPos.x + 2] = '▣';
                            playerPos.x++;
                        }
                    }
                    // 움직이려는 방향에 골 안에 있는 박스가 있을 때
                    else if (map[playerPos.y, playerPos.x + 1] == '▣')
                    {
                        // 1. 밀릴 위치가 빈칸인 경우
                        if (map[playerPos.y, playerPos.x + 2] == ' ')
                        {
                            map[playerPos.y, playerPos.x + 1] = '□';
                            map[playerPos.y, playerPos.x + 2] = '■';
                            playerPos.x++;
                        }
                        // 2. 밀릴 위치가 골인 경우
                        else if (map[playerPos.y, playerPos.x + 2] == '□')
                        {
                            map[playerPos.y, playerPos.x + 1] = '□';
                            map[playerPos.y, playerPos.x + 2] = '▣';
                            playerPos.x++;
                        }
                    }
                    else if (map[playerPos.y, playerPos.x + 1] == ' ' ||
                             map[playerPos.y, playerPos.x + 1] == '□')
                    {
                        playerPos.x++;
                    }
                    break;
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    // 움직이는 방향에 박스가 있을 때
                    if (map[playerPos.y - 1, playerPos.x] == '■')
                    {
                        // 1. 박스의 목적지가 벽이나 박스인 경우
                        if (map[playerPos.y - 2, playerPos.x] == '▒' ||
                           map[playerPos.y - 2, playerPos.x] == '■')
                        {
                            //밀리면 안된다.
                        }
                        // 2. 박스의 목적지에 빈칸인 경우
                        else if (map[playerPos.y - 2, playerPos.x] == ' ')
                        {
                            //박스를 밀고 이동한다.
                            map[playerPos.y - 1, playerPos.x] = ' ';
                            map[playerPos.y - 2, playerPos.x] = '■';
                            playerPos.y--;
                        }
                        // 3. 박스의 목적지가 골인 경우
                        else if (map[playerPos.y - 2, playerPos.x] == '□')
                        {
                            //박스를 밀어서 골에 넣고 이동한다.
                            map[playerPos.y - 1, playerPos.x] = ' ';
                            map[playerPos.y - 2, playerPos.x] = '▣';
                            playerPos.y--;
                        }
                    }
                    // 움직이려는 방향에 골 안에 있는 박스가 있을 때
                    else if (map[playerPos.y - 1, playerPos.x] == '▣')
                    {
                        // 1. 밀릴 위치가 빈칸인 경우
                        if (map[playerPos.y - 2, playerPos.x] == ' ')
                        {
                            map[playerPos.y - 1, playerPos.x] = '□';
                            map[playerPos.y - 2, playerPos.x] = '■';
                            playerPos.y--;
                        }
                        // 2. 밀릴 위치가 골인 경우
                        else if (map[playerPos.y - 2, playerPos.x] == '□')
                        {
                            map[playerPos.y - 1, playerPos.x] = '□';
                            map[playerPos.y - 2, playerPos.x] = '▣';
                            playerPos.y--;
                        }
                    }
                    else if (map[playerPos.y - 1, playerPos.x] == ' ' ||
                             map[playerPos.y - 1, playerPos.x] == '□')
                    {
                        playerPos.y--;
                    }
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    // 움직이는 방향에 박스가 있을 때
                    if (map[playerPos.y + 1, playerPos.x] == '■')
                    {
                        // 1. 박스의 목적지가 벽이나 박스인 경우
                        if (map[playerPos.y + 2, playerPos.x] == '▒' ||
                           map[playerPos.y + 2, playerPos.x] == '■')
                        {
                            //밀리면 안된다.
                        }
                        // 2. 박스의 목적지에 빈칸인 경우
                        else if (map[playerPos.y + 2, playerPos.x] == ' ')
                        {
                            //박스를 밀고 이동한다.
                            map[playerPos.y + 1, playerPos.x] = ' ';
                            map[playerPos.y + 2, playerPos.x] = '■';
                            playerPos.y++;
                        }
                        // 3. 박스의 목적지가 골인 경우
                        else if (map[playerPos.y + 2, playerPos.x] == '□')
                        {
                            //박스를 밀어서 골에 넣고 이동한다.
                            map[playerPos.y + 1, playerPos.x] = ' ';
                            map[playerPos.y + 2, playerPos.x] = '▣';
                            playerPos.y++;
                        }
                    }
                    // 움직이려는 방향에 골 안에 있는 박스가 있을 때
                    else if (map[playerPos.y + 1, playerPos.x] == '▣')
                    {
                        // 1. 밀릴 위치가 빈칸인 경우
                        if (map[playerPos.y + 2, playerPos.x] == ' ')
                        {
                            map[playerPos.y + 1, playerPos.x] = '□';
                            map[playerPos.y + 2, playerPos.x] = '■';
                            playerPos.y++;
                        }
                        // 2. 밀릴 위치가 골인 경우
                        else if (map[playerPos.y + 2, playerPos.x] == '□')
                        {
                            map[playerPos.y + 1, playerPos.x] = '□';
                            map[playerPos.y + 2, playerPos.x] = '▣';
                            playerPos.y++;
                        }
                    }
                    else if (map[playerPos.y + 1, playerPos.x] == ' ' ||
                             map[playerPos.y + 1, playerPos.x] == '□')
                    {
                        playerPos.y++;
                    }
                    break;
            }*/
        }
        static bool IsClear(char[,] map)
        {
            int goalCount = 0;
            //클리어 조건 : 빈칸이 없을 때
            foreach (char tile in map)
            {
                if (tile == '□')
                {
                    goalCount++;
                    break;
                }
            }

            if (goalCount == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static void End()
        {
            Console.Clear();
            Console.WriteLine("축하합니다!\n소코반 게임을 성공적으로 완료했습니다.");
        }
    }
}
