using Battle;
using Boss;
using Player;

namespace Bossroom
{
    internal class CBossroom
    {
        public void EnterBossroom(CPlayer player)
        {
           
            Console.Clear();
            Console.WriteLine("음습한 기운이 다가옵니다");
            Console.WriteLine("보스 히드라가 모습을 드러냈습니다!");
            CBoss boss = new CBoss("히드라", 5000, 300, 0, 200, 600);
            CBattle bossBattle = new CBattle(player, boss);
            bossBattle.StartBattle(); // 전투 시작
            bossBattle.EndBattle();
            Console.Clear();
        }
    }
}
