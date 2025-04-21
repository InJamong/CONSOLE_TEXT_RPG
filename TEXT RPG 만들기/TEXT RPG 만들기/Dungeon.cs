using Enemy;
using Player;
using Enums;
using EnemyManager;


namespace Dungeon
{
    public class CDungeon
    {
        private CEnemyManager enemyManager;
        private Random random = new Random();

        public CDungeon()
        {
            enemyManager = new CEnemyManager();
            random = new Random();
        }
        private void StartDungeonbattle(DUNGEON_DIFFICULTY difficultyLevel)
        {
            List<CEnemy> monster = enemyManager.ChooseEnemyDiff(difficultyLevel);
            if (monster.Count > 0)
            {
                CEnemy randomEnemy = monster[random.Next(monster.Count)];
                Console.WriteLine($"{randomEnemy.Name} 출현!");  
            }
        }
        public void EnterDungeon()
        {
            Console.WriteLine("던전에 입장하셨습니다.");
            Console.WriteLine("난이도를 선택해주세요: 1.이지 2.노멀 3.하드 4.나가기");
            int diff = int.Parse(Console.ReadLine());
            
           
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
                    //맵클래스 다 만들고 맵으로 돌아가는 함수 넣어야함.
                    break;

            }
        }





    }

}
