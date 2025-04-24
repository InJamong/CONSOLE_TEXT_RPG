using System;
using Player;
using Enemy;
using EnemyManager;
using Enums;
using Battle;
using Dungeon;
using Job;
using Shop;
using MainGame;

class Program
{
    static void Main(string[] args)
    {
        /*// 플레이어 이름 입력 받기
        Console.WriteLine("플레이어의 이름을 입력하세요:");
        string playerName = Console.ReadLine();

        // 직업 선택 메뉴 출력
        Console.WriteLine("직업을 선택하세요:");
        Console.WriteLine("1. 전사 (Warrior)");
        Console.WriteLine("2. 마법사 (Mage)");
        int jobChoice = int.Parse(Console.ReadLine());
        CJob playerJob = null;

        // 직업에 따른 선택 처리
        switch (jobChoice)
        {
            case 1:
                playerJob = new CWarrior();
                break;
            case 2:
                playerJob = new CMage();
                break;

            default:
                Console.WriteLine("잘못된 입력입니다. 전사로 설정됩니다.");
                playerJob = new CWarrior();
                break;
        }

        // 플레이어 객체 생성 (이름, 금액, 직업, X, Y)
        CPlayer player = new CPlayer(playerName, 500, playerJob, 0, 0);

        // 플레이어 정보 확인
        Console.WriteLine($"플레이어 이름: {player.Name}, 직업: {player.Job.JobName}, HP: {player.Job.BaseHp}, 공격력: {player.Atk}, 방어력: {player.Def}");



        CShop shop = new CShop();
        shop.ItemSetUp();
        shop.ShowShopMenu();
        // 던전 객체 생성
        CDungeon dungeon = new CDungeon(player);

        // 던전 입장 (난이도 선택)
        dungeon.EnterDungeon();*/
        CMainGame game = new CMainGame();
        game.MainGame();
      
    }
}

