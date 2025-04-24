
using System.Text;
using Map;
using Player;
using ShowPlayerStatus;

namespace PrintMap
{
    internal class CPrintMap
    {
        //private CPlayerStatus playerStatus; //플레이어 상태를 보여주는 클래스 객체
        public void print(CMap map, CPlayer player)
        {
            
            int mapHeight = map.mapData.GetLength(0);
            int mapWidth = map.mapData.GetLength(1);
            for (int x = 0; x < map.mapData.GetLength(0); x++)
            {
                for (int y = 0; y < map.mapData.GetLength(1); y++)
                {
                    if (x == player.Y && y == player.X)
                    {
                        Console.SetCursorPosition(y * 2, x);
                        Console.Write("♣");
                    }
                    else if (map.mapData[x, y] == 0)
                    {
                        Console.SetCursorPosition(y * 2, x);
                        Console.Write("■");
                    }
                    else if (map.mapData[x, y] == 1)
                    {
                        Console.SetCursorPosition(y * 2, x);
                        Console.Write("Ⓢ");
                    }
                    else if (map.mapData[x, y] == 2)
                    {
                        Console.SetCursorPosition(y * 2, x);
                        Console.Write("Ⓓ");
                    }
                    else if (map.mapData[x, y] == 3)
                    {
                        Console.SetCursorPosition(y * 2, x);
                        Console.Write("Ⓑ");
                    }
                }
                Console.WriteLine();
            }

            /*int mapRightX = mapWidth * 2 + 2;
            Console.SetCursorPosition(mapRightX, 0);

            for (int i = 0; i < mapHeight; i++)
            {
                playerStatus.ShowPlayerStatus(player);  // 플레이어 상태 출력
                Console.SetCursorPosition(mapRightX, i + 2);  // 한 줄씩 내려가면서 출력
            }*/
        }
    }
}
    

