using System.Reflection.Emit;
using Enemy;
using Enums;

namespace EnemyManager
{
    public class CEnemyManager
    {
        public List<CEnemy> EasyMonster = new List<CEnemy>()
        {
            new CEnemy("슬라임", 70, 10,100),
            new CEnemy("고블린", 40, 15,100),
            new CEnemy("박쥐", 50, 13,100)
        };

        public List<CEnemy> NomalMonster = new List<CEnemy>()
        {
            new CEnemy("오크",100,20,500),
            new CEnemy("좀비",110,18,500),
            new CEnemy("트롤",110,21,500)
        };
        public List<CEnemy> HardMonster = new List<CEnemy>()
        {
            new CEnemy("목 없는 기사",200,40,1000),
            new CEnemy("헬하운드",250,35,1000),
            new CEnemy("시체 골램",300,45,1000)

        };
        public List<CEnemy> ChooseEnemyDiff(DUNGEON_DIFFICULTY enemyDifficultyLevel)
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
