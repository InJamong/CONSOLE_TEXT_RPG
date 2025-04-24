using Player;
using Enemy;
using EnemyManager;
using Skill;
using SkillManager;
using System.Threading;
using Inventory;

namespace Battle
{
    public class CBattle
    {
        public CPlayer player;
        public CEnemy enemy;
        public CSkillManager skillManager;

        public CBattle(CPlayer player, CEnemy enemy)
        {
            this.player = player;
            this.enemy = enemy;
            this.skillManager = new CSkillManager();
        }


        public void StartBattle()
        {
            if (player == null)
            {
                Console.WriteLine("플레이어가 null입니다. 전투를 시작할 수 없습니다.");
                return;
            }

            if (enemy == null)
            {
                Console.WriteLine("적이 null입니다. 전투를 시작할 수 없습니다.");
                return;
            }
            player.SaveDefaultStatus(); //플레이어 초기값 저장

            Console.WriteLine($"전투 시작! {player.Name}용사님이 {enemy.Name}을(를) 조우");
            Thread.Sleep(2000);

            while (player.Hp > 0 && enemy.Hp > 0)
            {
                ShowBattel(); //실제 전투관련 로직 만들기.
                if (player.Hp <= 0 || enemy.Hp <= 0) break;
            }
            EndBattle();
        }
        public void ShowBattel()
        {
            Console.Clear();
            Console.WriteLine("================================================");
            Console.WriteLine($"===플레이어===");
            Console.WriteLine($"HP:{player.Hp}/{player.MaxHp}  MP:{player.Mp}/{player.MaxMp}");
            Console.WriteLine($"공격력: {player.Atk}   방어력: {player.Def}");
            Console.WriteLine("================================================");
            Console.WriteLine("===적===");
            Console.WriteLine($"{enemy.Name}    HP:{enemy.Hp}/{enemy.MaxHp}   공격력{enemy.Atk}");
            Console.WriteLine("================================================");
            Console.WriteLine("1. 일반 공격");
            Console.WriteLine("2. 스킬 사용");
            Console.WriteLine("3. 물약 사용");

            string selectAction = Console.ReadLine();


            switch (selectAction)
            {
                case "1":
                    Console.WriteLine($"{player.Name}용사님이 공격!");
                    enemy.Hp -= player.Atk;
                    Thread.Sleep(500);
                    Console.WriteLine($"{enemy.Name}의 HP가 {player.Atk}만큼 감소하여, 남은 HP는 {enemy.Hp}입니다.");
                    Thread.Sleep(1000);

                    if (enemy.Hp > 0)
                    {
                        Thread.Sleep(500);
                        Console.WriteLine($"{enemy.Name}이(가) {player.Name}용사님에게 {enemy.Atk}만큼 피해를 입혔습니다");
                        player.Hp -= enemy.Atk;
                        Console.WriteLine($"{player.Name}용사님의 남은 HP는{Math.Max(0, player.Hp)}입니다.");
                        Thread.Sleep(1000);

                        break;
                    }
                    break;
                case "2":
                    Console.WriteLine("사용할 스킬을 선택해주세요");
                    CSkillManager.ShowSkills(player); //스킬 목록 보여줌.
                    Console.WriteLine("뒤로 가실려면 0을 눌러주세요");
                    int skillChoice = int.Parse(Console.ReadLine());  
                    if (skillChoice == 0)
                    {
                        Console.WriteLine("스킬 선택을 취소했습니다.");
                        Thread.Sleep(1000);
                        break;
                    }
                    var selectskill = player.Job.Skill[skillChoice - 1]; 
                    bool succes = skillManager.UsingSkill(player, selectskill, enemy);
                    Thread.Sleep(1000);
                    if (!succes)
                    {
                        Console.WriteLine("다시 선택해주세요");
                        Thread.Sleep(500);
                        return;
                    }

                    if (enemy.Hp > 0)
                    {
                        Thread.Sleep(1000);
                        Console.WriteLine($"{enemy.Name}이 {player.Name}용사님에게 {enemy.Atk}만큼 피해를 입혔습니다");
                        player.Hp -= enemy.Atk;
                        Console.WriteLine($"{player.Name}용사님의 남은 HP는{Math.Max(0, player.Hp)}입니다.");
                        Thread.Sleep(2000);
                        break;
                    }
                    break;
                case "3": //인벤토리에 있는 물약을 사용하는 메서드 넣어야함.
                    player.Inventory.UsingPotion(player);
                    break;

                default:
                    Console.WriteLine("잘못된 입력입니다. 다시 선택하세요.");
                    break;

            }
        }
        public void EndBattle()
        {
            if (player.Hp <= 0)
            {
                Console.WriteLine($"{player.Name}용사님의 눈앞이 깜깜해졌습니다. 신전에서 {player.Gold / 2}골드를 사용해 살아났습니다. ");
                Console.WriteLine($"소지 중인 {player.Gold / 2}골드를 잃으셨습니다.");
                player.Gold =player.Gold / 2;
                enemy.ResetEnemyStatus();
                player.PlayerDefaultStatus();
            }
            else if (enemy.Hp <= 0)
            {
                Console.WriteLine($"{enemy.Name} 처지!");
                Console.WriteLine($"{enemy.Gold}의 골드를 얻었습니다");
                player.Gold += enemy.Gold;
                enemy.ResetEnemyStatus();
                player.PlayerDefaultStatus();


            }
        }
    } 
    
}
