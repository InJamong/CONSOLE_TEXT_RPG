using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Player;
using PlayerMoving;
using Job;
using Dungeon;
using Enemy;
using EnemyManager;
using Map;
using PrintMap;
using ShowPlayerStatus;
using UserGuide;
using System.Text.RegularExpressions;
using Shop;
using System.Threading;
using Inventory;
using Boss;
using Bossroom;
namespace MainGame
{
    public class CMainGame
    {

        private CMap map;
        private CPlayer player;
        private CPrintMap printMap;
        private CPlayerStatus playerStatus;
        private CUserGuide userGuide =new CUserGuide();
        private CShop shop;
        private CDungeon dungeon;
        private CBossroom bossroom;
        


        #region 가운데 정렬 및 글자 깜박이면서 한글자씩 나오게 하는 메서드


        static void TypeWriterBlinkingCenter(string text, int delay)
        {
            int windowWidth = Console.WindowWidth;
            int padding = Math.Max(0, (windowWidth - text.Length) / 2);
            Console.Write(new string(' ', padding)); // 왼쪽 공백으로 가운데 정렬

            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
            Console.WriteLine();
        }
        #endregion

        #region 메인메뉴 메서드
        public void MainMenu()
        {
            Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
            Console.WriteLine("■■■■■■□□□■■■■■■■□■■■■■□■■■■■■■■■■■□■■■□□□■■■■■■■■■■□■■■■■■■■");
            Console.WriteLine("■■■■■□■■■□■■■■■□■□■■■■□■■■■□□□□□■■□■■□■■■□■■□□□□□■■□■■■■■■■■");
            Console.WriteLine("■■■■■□■■■□■■■■□■■■□■■■□■■■■■■■■□■■□■■□■■■□■■■■■■□■■□■■■■■■■■");
            Console.WriteLine("■■■■■■□□□■■■■□■■■■■□■■□□□■■■□□□□■■□■■■□□□■■■■■■■□■■□■■■■■■■■");
            Console.WriteLine("■■■■■■□■□■■■□■■■■■■■□■□■■■■■■■■□■■□■■■■■■■■■■■■■□■■□■■■■■■■■");
            Console.WriteLine("■■■■□□□□□□□■■■■■■■■■■■□■■■■■■■■□■■□■□□□□□□□■■■■■□■■□■■■■■■■■");
            Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■□■■■■■■■■□■■□■■■■□■■■■■■■■□■■□■■■■■■■■");
            Console.WriteLine("■■■■■■□□□■■■■■■■■■■■■■□■■■■■■■■■■■□■■■■□■■■■■■■■■■■□■■■■■■■■");
            Console.WriteLine("■■■■■□■■■□■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
            Console.WriteLine("■■■■■□■■■□■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
            Console.WriteLine("■■■■■■□□□■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
            Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("게임을 시작하시겠습니까?");
            Console.WriteLine("시작하시려면 아무 키나 눌러주세요");
            Console.ReadKey();
            Console.Clear();
            TypeWriterBlinkingCenter("왕국에 사악한 용이 나타났습니다.", 30);
            TypeWriterBlinkingCenter("왕국에서는 용을 무찔러 줄 용사를 찾고 있습니다!", 30);
            TypeWriterBlinkingCenter("용사를 키워서 용을 무찔러주세요!", 30);
            TypeWriterBlinkingCenter("진행하실려면 아무 키나 눌러주세요",0);
            Console.ReadKey();
        }
        #endregion

        #region 플레이어 생성 메서드
        public void CreatePlayer()
        {
            Console.Clear();
            // 플레이어 이름 입력 받기
            Console.WriteLine("용사님의 이름을 알려주세요:");
            string playerName = Console.ReadLine();

            // 직업 선택 메뉴 출력
            Console.WriteLine("용사님의 직업을 선택해주세요:");
            Console.WriteLine("1. 전사 (Warrior)");
            Console.WriteLine("2. 마법사 (Mage)");
            Console.WriteLine("잘못된 입력이 있을 시 기본값(전사)로 설정됩니다.");
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
                case 000112:
                    playerJob = new Ccheat();
                    break;
            }


            // 플레이어 객체 생성 (이름, 금액, 직업, X, Y)
            this.player = new CPlayer(playerName, 5000, playerJob, 0, 0);

            // 플레이어 정보 확인
            Console.WriteLine($"플레이어 이름: {player.Name}, 직업: {player.Job.JobName}, HP: {player.Job.BaseHp}, 공격력: {player.Atk}, 방어력: {player.Def}");
        }
        #endregion

        #region 맵 나오게 함.
        public void ShowingMap()
        {
            
            map = new CMap();
            printMap = new CPrintMap();
            Console.Clear();
            printMap.print(map, player);
        }
        #endregion

        #region 플레이어가 맵에서 이동 루프
        public void Loop()
        {
            
            CPlayerMoving playerMoving = new CPlayerMoving();
            while (true)
            {
                userGuide.UserGuide();
                ShowPlayerStatus();
                printMap.print(map, player);
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.P)
                {
                    Console.Clear();
                    Console.WriteLine("인벤토리 여는중");
                    Thread.Sleep(1000);
                    player.Inventory.InventoryMenu(player);
                    Console.Clear();
                    continue;

                }
                playerMoving.Move(keyInfo.Key, player,map);
                CheackMapInteraction();
            }

        }
        #endregion

        #region 플레이어 맵 상호작용
        private void CheackMapInteraction()
        {
            
            int PlayerLocation = map.mapData[player.Y, player.X];

            switch (PlayerLocation)
            {
                case 1:
                    map.mapData[3, 1] = 1;

                    Console.Clear();
                    Console.WriteLine("상점에 입장합니다");
                    Thread.Sleep(1000);
                    shop.ShowShopMenu(player);
                    break;

                case 2:
                    map.mapData[3, 5] = 2;

                    Console.Clear();
                    Console.WriteLine("던전에 입장합니다.");
                    Thread.Sleep(1000);
                    dungeon.EnterDungeon();
                    break;
                    
                case 3:
                    map.mapData[0, 3] = 3;
                    Console.Clear();
                    Console.WriteLine("보스방에 입장합니다. 건투를 빌어요!");
                    Thread.Sleep(1000);
                    Console.Clear();
                    CBossroom bossroom = new CBossroom();
                    Console.WriteLine("입장하시겠습니까? 입장:1/나중에 도전: 0");
                    int inputBoss = int.Parse(Console.ReadLine());
                    if (inputBoss == 1)
                    {
                        bossroom.EnterBossroom(player);
                    }
                    else
                    {
                        Console.Clear();
                    }
                    break;
                        /*switch(inputBoss)
                        {
                            case 1:
                                bossroom.EnterBossroom(player);
                                break;
                            case 0:
                                Console.Clear();
                                break;
                        }*/
            }
            




        }
        #endregion

        #region 플레이어 스텟
        public void ShowPlayerStatus()
        {
            Console.WriteLine();
            playerStatus = new CPlayerStatus();
            playerStatus.ShowPlayerStatus(player);

        }
        #endregion


        public void MainGame()
        {
            Console.CursorVisible = false;
            Console.OutputEncoding = Encoding.UTF8;
            shop = new CShop();
            MainMenu();
            CreatePlayer();
            dungeon = new CDungeon(player);
            ShowingMap();
            Loop();
        }
        
    }
}
