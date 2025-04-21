using Job;
using Player;

namespace ShowPlayerStatus
{
    public class CPlayerStatus
    {
        public void ShowPlayerStatus(CPlayer player)
        {
            Console.WriteLine($"====={player.Name} 스테이터스=====");
            Console.WriteLine($"직업: {player.Job.JobName}");
            Console.WriteLine($"HP: {player.Hp}");
            Console.WriteLine($"MP: {player.Mp}");
            Console.WriteLine($"공격력: {player.Atk}");
            Console.WriteLine($"방어력: {player.Def}");
            Console.WriteLine($"소지 골드: {player.Gold}");
            Console.WriteLine("==============================");
        }
    }
}
