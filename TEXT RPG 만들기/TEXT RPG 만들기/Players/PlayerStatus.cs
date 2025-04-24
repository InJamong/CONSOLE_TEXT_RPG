using Job;
using Player;

namespace ShowPlayerStatus
{
    public class CPlayerStatus
    {
        public void ShowPlayerStatus(CPlayer player)
        {
            Console.WriteLine($"====={player.Name}용사님의 스테이터스=====");
            Console.WriteLine($"직업: {player.Job.JobName}");
            Console.WriteLine($"HP: {player.MaxHp}");
            Console.WriteLine($"MP: {player.MaxMp}");
            Console.WriteLine($"공격력: {player.Atk}");
            Console.WriteLine($"방어력: {player.Def}");
            Console.WriteLine("==============================");
            Console.WriteLine("인벤토리:P");
            Console.WriteLine($"소지 골드: {player.Gold}");
            if (player.EquippedArmor != null)
            {
            Console.WriteLine($"장착 중인 방어구: {player.EquippedArmor.Name}");

            }
            else
            {
                Console.WriteLine("장착중인 방어구 :");
            }
            if (player.EquippedWeapon != null)
            {
                Console.WriteLine($"장착 중인 무기: {player.EquippedWeapon.Name}");

            }
            else
            {
                Console.WriteLine($"장착중인 무기 :");
            }
            Console.WriteLine("==============================");
        }
    }
}
