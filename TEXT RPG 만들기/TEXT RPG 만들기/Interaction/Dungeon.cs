using Player;
using Enums;
using EnemyManager;
using Battle;
using System.Threading;
using Enemy; 


namespace Dungeon
{
    public class CDungeon
    {
        private CPlayer player;
        private CEnemyManager enemyManager;
        private Random random = new Random();
        
        public CDungeon(CPlayer player)
        {
            this.player = player;
            enemyManager = new CEnemyManager();
        }
        private void StartDungeonbattle(DUNGEON_DIFFICULTY difficultyLevel)
        {
            List<CEnemy> monster = enemyManager.ChooseEnemyDiff(difficultyLevel);
            if (monster.Count > 0)
            {
                CEnemy randomEnemy = monster[random.Next(monster.Count)];
                Console.WriteLine($"{randomEnemy.Name} 출현!");
                Thread.Sleep(1000);

                CBattle battle = new CBattle(player, randomEnemy); //CBattle클래스 생성자를 가지고있는 battle이라는 변수 생성. CBattle을 static으로 안하기 위해 사용.
                battle.StartBattle();
                Console.WriteLine("1. 다음 몬스터와 전투");
                Console.WriteLine("2. 던전 나가기"); 
                string inputnextaction = Console.ReadLine();  //int 형으로 안받고 처음부터 string으로 받아서 굳이 형변환 X

                if (inputnextaction == "1")
                {
                    Console.WriteLine("몬스터를 찾는중");
                    Thread.Sleep(1000);
                    Console.Clear();
                    StartDungeonbattle(difficultyLevel);//재귀 호출해서 다음 몬스터 등장.
                    
                    //재귀로 인해 문제가 생길 경우 while문 고려해봐야할듯.
                }
                else
                {
                    Console.WriteLine("던전에서 나갑니다.");
                    Thread.Sleep(2000);
                    Console.Clear();
                    // 미니맵으로 돌아가는 함수 넣어야함.
                }
            }
        }
        public void EnterDungeon()
        {
            Console.WriteLine("던전에 입장하셨습니다.");
            Console.WriteLine("난이도를 선택해주세요: 1.이지 2.노멀 3.하드 4.나가기");
            string input = Console.ReadLine();
            if (!int.TryParse(input, out int diff))
            {
                Console.WriteLine("숫자를 입력해주세요!");
                Thread.Sleep(1000);
                Console.Clear();


                return;
            }


            switch (diff)
            {
                case 1:
                    StartDungeonbattle (DUNGEON_DIFFICULTY.EASY);
                    break;
                case 2:
                    StartDungeonbattle (DUNGEON_DIFFICULTY.NORMAL);
                    break;
                case 3:
                    StartDungeonbattle(DUNGEON_DIFFICULTY.HARD);
                    break;
                case 4:
                    Console.WriteLine("던전에서 나갑니다.");
                    Console.Clear ();
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다");
                    Console.ReadKey();
                    Console.Clear();
                    break;

            }
        }
    }
}
