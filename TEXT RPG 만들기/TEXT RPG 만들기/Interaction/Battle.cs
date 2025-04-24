using Player;
using EnemyManager;
using Skill;
using SkillManager;
using System.Threading;
using Inventory;
using Boss;
using Enemy;

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
            Console.WriteLine("=============================");
            Console.WriteLine($"===플레이어===");
            Console.WriteLine($"HP:{player.Hp}/{player.MaxHp} MP:{player.Mp}/{player.MaxMp}");
            Console.WriteLine($"공격력: {player.Atk} 방어력: {player.Def}");
            Console.WriteLine("=============================");
            Console.WriteLine("===적===");
            Console.WriteLine($"{enemy.Name} HP:{enemy.Hp}/{enemy.MaxHp} 공격력{enemy.Atk}");
            Console.WriteLine("=============================");
            Console.WriteLine("1. 일반 공격");
            Console.WriteLine("2. 스킬 사용");
            Console.WriteLine("3. 물약 사용");
            if (enemy is CBoss boss) // 적이 보스일 때만 보스 이미지를 출력
            {
                ShowBossImage(boss); // 보스 이미지를 출력하는 메서드 호출
            }
        

        string selectAction = Console.ReadLine();

            int damage = Math.Max(1, enemy.Atk - player.Def);

            switch (selectAction)
            {
                case "1":
                    Console.WriteLine($"{player.Name}용사님이 공격!");
                    enemy.Hp -= player.Atk;
                    Thread.Sleep(500);
                    Console.WriteLine($"{enemy.Name}의 HP가 {player.Atk}만큼 감소하여, 남은 HP는 {Math.Max(0, enemy.Hp)}입니다.");
                    Thread.Sleep(1000);

                    if (enemy is CBoss boss1)
                    {
                        Random rand = new Random();
                        int bossAction = rand.Next(0, 2); //일반공격 2. 스킬. 힐은 턴마다 할꺼임.
                        if (bossAction == 0)
                        {
                            Console.WriteLine($"{boss1.Name}가 {player.Name}용사님에게 공격했습니다.");
                            Console.WriteLine($"{player.Name}용사님이 {boss1.Atk}만큼 피해를 입었습니다.");
                            player.Hp -= boss1.Atk - player.Def;
                            Thread.Sleep(1500);
                            Console.WriteLine($"{boss1.Name}의 잘린 머리가 다시 회복되었습니다.");
                            Console.WriteLine($"{boss1.BHeal}만큼 체력을 회복했습니다.");
                            Thread.Sleep(1500);
                            boss1.Hp = Math.Min(boss1.MaxHp, boss1.Hp + boss1.BHeal);
                        }
                        else if (bossAction == 1)
                        {
                            Console.WriteLine($"{boss1.Name}가 {player.Name}용사님에게 불을 내뿜었습니다.");
                            Console.WriteLine($"{player.Name}용사님이 {boss1.BSkillDamage}만큼 피해를 입었습니다.");
                            player.Hp -= boss1.BSkillDamage - player.Def;
                            Console.WriteLine($"{boss1.Name}의 잘린 머리가 다시 회복되었습니다.");
                            Console.WriteLine($"{boss1.BHeal}만큼 체력을 회복했습니다.");
                            Thread.Sleep (1500);
                            boss1.Hp = Math.Min(boss1.MaxHp, boss1.Hp + boss1.BHeal);
                        }
                    }
                    else if (enemy.Hp > 0)
                    {

                        Thread.Sleep(500);
                        Console.WriteLine($"{enemy.Name}이(가) {player.Name}용사님에게 {damage}만큼 피해를 입혔습니다");
                        player.Hp -= damage;
                        Console.WriteLine($"{player.Name}용사님의 남은 HP는{Math.Max(0, player.Hp)}입니다.");
                        Thread.Sleep(500);
                        break;
                    }
                    
                    break;
                case "2":
                    Console.WriteLine("사용할 스킬을 선택해주세요");
                    CSkillManager.ShowSkills(player); //스킬 목록 보여줌.
                    Console.WriteLine("뒤로 가실려면 0을 눌러주세요");
                    if (!int.TryParse(Console.ReadLine(), out int skillChoice))
                    {
                        Console.WriteLine("잘못된 입력입니다. 숫자를 입력해주세요");
                        Thread.Sleep(500);
                            return;
                        //int skillChoice = int.Parse(Console.ReadLine()); 이거로 했더니 엔터한번 잘못 누르면 그냥 콘솔창 멈춰서 제발.. TryParse 쓰자...
                    }
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
                    if (enemy is CBoss boss2)
                    {
                        Random rand = new Random();
                        int bossAction = rand.Next(0, 2); //일반공격 2. 스킬. 힐은 턴마다 할꺼임.
                        if (bossAction == 0)
                        {
                            Console.WriteLine($"{boss2.Name}가 {player.Name}용사님에게 공격했습니다.");
                            Console.WriteLine($"{player.Name}용사님이 {boss2.Atk}만큼 피해를 입었습니다.");
                            player.Hp -= boss2.Atk - player.Def;
                            Console.WriteLine($"{boss2.Name}의 잘린 머리가 다시 회복되었습니다.");
                            Console.WriteLine($"{boss2.BHeal}만큼 체력을 회복했습니다.");
                            boss2.Hp = Math.Min(boss2.MaxHp, boss2.Hp + boss2.BHeal);
                        }
                        else if (bossAction == 1)
                        {
                            Console.WriteLine($"{boss2.Name}가 {player.Name}용사님에게 불을 내뿜었습니다.");
                            Console.WriteLine($"{player.Name}용사님이 {boss2.Atk * 3}만큼 피해를 입었습니다.");
                            player.Hp -= boss2.Atk * 3 - player.Def;
                            Console.WriteLine($"{boss2.Name}의 잘린 머리가 다시 회복되었습니다.");
                            Console.WriteLine($"{boss2.BHeal}만큼 체력을 회복했습니다.");
                            boss2.Hp = Math.Min(boss2.MaxHp, boss2.Hp + boss2.BHeal);
                        }
                    }
                    else if (enemy.Hp > 0)
                    {
                        Thread.Sleep(1000);
                        Console.WriteLine($"{enemy.Name}이 {player.Name}용사님에게 {damage}만큼 피해를 입혔습니다");
                        player.Hp -= damage;
                        Console.WriteLine($"{player.Name}용사님의 남은 HP는{Math.Max(0, player.Hp)}입니다.");
                        Thread.Sleep(500);
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
                Console.WriteLine($"{player.Name}용사님의 눈앞이 깜깜해졌습니다.");
                Console.WriteLine($"신전에서 {player.Gold / 2}골드를 사용해 살아났습니다.");
                Console.WriteLine($"소지 중인 {player.Gold / 2}골드를 잃으셨습니다.");
                player.Gold =player.Gold / 2;
                Thread.Sleep(1000);
                enemy.ResetEnemyStatus();
                player.PlayerDefaultStatus();
            }
            else if (enemy.Hp <= 0)
            {
                if (enemy is CBoss)
                {
                    Console.WriteLine("보스를 처지하셨습니다!");
                    Console.WriteLine("왕국에 평화가 찾아왔습니다");
                    Console.WriteLine("게임 클리어!!");
                    Console.WriteLine("게임을 끝내려면 아무키나 눌러주세요");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine($"{enemy.Name} 처지!");
                    Console.WriteLine($"{enemy.Gold}의 골드를 얻었습니다");
                    player.Gold += enemy.Gold;
                    enemy.ResetEnemyStatus();
                    player.PlayerDefaultStatus();
                }
                    


            }
        }
        public void PrintWithCustomColors(string text)
        {
            foreach (var ch in text)
            {
                switch (ch)
                {
                    case '○':
                        Console.ForegroundColor = ConsoleColor.DarkYellow; // ○는 갈색
                        break;
                    case '□':
                        Console.ForegroundColor = ConsoleColor.Black; // □는 하얀색
                        break;
                    case '●':
                        Console.ForegroundColor = ConsoleColor.Red; // ●는 빨간색
                        break;
                    case '■':
                        Console.ForegroundColor = ConsoleColor.Gray; // ■는 검정
                        break;
                    default:
                        Console.ResetColor(); // 기본 색상으로 리셋
                        break;
                }

                Console.Write(ch); // 색상 적용된 문자 출력
            }

            Console.ResetColor(); // 마지막에는 색상을 리셋
        }
        public void ShowBossImage(CBoss boss)
        {
            // 보스 이미지 출력
            Console.SetCursorPosition(60, 2);
            PrintWithCustomColors("□□□□□□□□□□□□□□■□□□□□□□□□□□□□□");
            Console.SetCursorPosition(60, 3);
            PrintWithCustomColors("□□□□□□□□□□□□□■○■□■□□□□□□□□□□□");
            Console.SetCursorPosition(60, 4);
            PrintWithCustomColors("□□□□□■■■■■□□■○○■■○■□■■■■■■■□□");
            Console.SetCursorPosition(60, 5);
            PrintWithCustomColors("□□□□■○○○○○■■○○○○○○○■○○○○○○○■□");
            Console.SetCursorPosition(60, 6);
            PrintWithCustomColors("□□□□□■●●●●○○○○○○○○○○○○●●●●■□□");
            Console.SetCursorPosition(60, 7);
            PrintWithCustomColors("□□□□□□■●●○○○○○○○○○○○○●●●●■□□□");
            Console.SetCursorPosition(60, 8);
            PrintWithCustomColors("□□□□□□□■○○○○○○○○○○○○○○○○○○■□□");
            Console.SetCursorPosition(60, 9);
            PrintWithCustomColors("□□□□□□■○○○○●○○○●●●●●■○●●●●○■□");
            Console.SetCursorPosition(60, 10);
            PrintWithCustomColors("□□□□□□■○●○●○○○●●●●●●●○○●●■■□□");
            Console.SetCursorPosition(60, 11);
            PrintWithCustomColors("□□□□□■○○○○○○○●●○○●●●●○○○○■□□□");
            Console.SetCursorPosition(60, 12);
            PrintWithCustomColors("□□□□□■○○○□○○○●■■■○○●●○●●●○■□□");
            Console.SetCursorPosition(60, 13);
            PrintWithCustomColors("□□□□□■○○□■○○●■○○■○○●●○●●■■□□□");
            Console.SetCursorPosition(60, 14);
            PrintWithCustomColors("□□□□□□■□■○○○■○○○○■●●●○●■□□□□□");
            Console.SetCursorPosition(60, 15);
            PrintWithCustomColors("□□□□□□□■○○○■○○○■■●●●●○■□□□□□□");
            Console.SetCursorPosition(60, 16);
            PrintWithCustomColors("□□□□□□□□■■■○○■■●●●●●○○■□□□□□□");
            Console.SetCursorPosition(60, 17);
            PrintWithCustomColors("□□□□□■□□□□□□■●●●●●●●○■□□□□□□□");
            Console.SetCursorPosition(60, 18);
            PrintWithCustomColors("□□□□■○■□□□■■○●●●●●●○■□□□□□□□□");
            Console.SetCursorPosition(60, 19);
            PrintWithCustomColors("□□□■○■□□□■○●●●●●●○○■□□□□□□□□□");
            Console.SetCursorPosition(60, 20);
            PrintWithCustomColors("□□□■○■■□■○○●●●●●■■■■■■□□□□□□□");
            Console.SetCursorPosition(60, 21);
            PrintWithCustomColors("□□□■○○○■■○○○○○●●●●●●○○■□□□□□□");
            Console.SetCursorPosition(60, 22);
            PrintWithCustomColors("□□■○○■■□■○○○○○○○○○○○○○○■□□□□□");
            Console.SetCursorPosition(60, 23);
            PrintWithCustomColors("□■○■○■□□□■●○○○○○○○○○○○○■□□□□□");
            Console.SetCursorPosition(60, 24);
            PrintWithCustomColors("□■○■■○■■■○●●○○○○○○○○○○■□□□□□□");
            Console.SetCursorPosition(60, 25);
            PrintWithCustomColors("□■○■■■○○○○○○●●●●●●●●●■□□□□□□□");
            Console.SetCursorPosition(60, 26);
            PrintWithCustomColors("□□■○○■■■■○○○○○○○○●●●●○■□□□□□□");
            Console.SetCursorPosition(60, 27);
            PrintWithCustomColors("□□□■■○○○○○○○○○○○○○○○○○○■□□□□□");
            Console.SetCursorPosition(60, 28);
            PrintWithCustomColors("□□□□□■■■■■○○○○○○○○○○○○○■□□□□□");
            Console.SetCursorPosition(60, 29);
            PrintWithCustomColors("□□□□□□□□□□■○○○○○○○○○○○■□□□□□□");
            Console.SetCursorPosition(60, 30);
            PrintWithCustomColors("□□□□□□□□□□□■■■■■■■■■■■□□□□□□□");
            Console.SetCursorPosition(60, 31);
            PrintWithCustomColors("□□□□□□□□□□□□□□□□□□□□□□□□□□□□□");
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 12);

        }
    } 

    
}
