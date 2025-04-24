using Player;
using PlayerMoving;
using Dungeon;

namespace Map
{
    public class CMap
    {
        public int[,] mapData;
        public CMap()
        {
            mapData = new int[7, 7];
            ResetMap();
        }
        public void ResetMap()
        {
            for (int x = 0; x < mapData.GetLength(0); x++)
            {
                for (int y = 0; y < mapData.GetLength(1); y++)
                {
                    mapData[x, y] = 0;
                }
            }
            mapData[3, 1] = 1; //상점
            mapData[3, 5] = 2; //던전
            mapData[0, 3] = 3; //보스방
        }
     
        /*public void EnterDungeon(CPlayer player) 없어도 되는 코드
        {
            if (mapData[player.Y, player.X] == 2)
            {
                CDungeon dungeon = new CDungeon(player);
                dungeon.EnterDungeon();
            }
        }*/
    }
    
}
