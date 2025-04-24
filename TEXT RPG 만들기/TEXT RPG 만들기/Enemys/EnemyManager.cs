using System.Reflection.Emit;
using Enums;
using Enemy;

namespace EnemyManager
{
    public class CEnemyManager
    {
        public List<CEnemy> EasyMonster = new List<CEnemy>()
        {
            new CEnemy("슬라임", 70, 20,500),
            new CEnemy("고블린", 40, 25,500),
            new CEnemy("박쥐", 50, 23,500)
        };

        public List<CEnemy> NomalMonster = new List<CEnemy>()
        {
            new CEnemy("오크",100,40,1000),
            new CEnemy("좀비",110,38,1000),
            new CEnemy("트롤",110,45,1000)
        };
        public List<CEnemy> HardMonster = new List<CEnemy>()
        {
            new CEnemy("목 없는 기사",200,60,2000),
            new CEnemy("헬하운드",250,75,2000),
            new CEnemy("시체 골램",300,55,2000)

        };
        public List<CEnemy> ChooseEnemyDiff(DUNGEON_DIFFICULTY enemyDifficultyLevel)
        // 던전 클래스에서 사용해야 할 코드 만들어놓음. 위에 있는 리스트들을 던전 난이도 래벨에 맞춰서 넣어놓음.
        {
            switch (enemyDifficultyLevel)
            {
                case DUNGEON_DIFFICULTY.EASY:
                    return EasyMonster;
                case DUNGEON_DIFFICULTY.NORMAL:
                    return NomalMonster;
                case DUNGEON_DIFFICULTY.HARD:
                    return HardMonster;
                default:
                    return new List<CEnemy>();
            }
        }

    }
}
