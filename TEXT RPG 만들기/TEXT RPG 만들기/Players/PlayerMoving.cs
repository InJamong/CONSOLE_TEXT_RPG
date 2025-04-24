using Map;
using Player;


namespace PlayerMoving
{
    internal class CPlayerMoving
    {
        public void Move(ConsoleKey key, CPlayer player,CMap map)
        {
            int mapHeight = map.mapData.GetLength(0); // 세로
            int mapWidth = map.mapData.GetLength(1);  // 가로
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    if(player.X>0)
                        player.X--;
                    break;
                case ConsoleKey.RightArrow:
                    if(player.X<mapWidth-1)
                    player.X++;
                    break;
                case ConsoleKey.UpArrow:
                    if(player.Y>0)
                    player.Y--;
                    break;
                case ConsoleKey.DownArrow:
                    if(player.Y<mapHeight-1)
                    player.Y++;
                    break;
            }
        }
    }
}
