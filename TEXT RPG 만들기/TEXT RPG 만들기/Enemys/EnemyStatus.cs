using Enemy;

namespace EnemyStatus
{
    public class CEnemyStatus
    {
        public CEnemy EnemyData { get; set; }
        public int CurrentHp {  get; set; }

        public CEnemyStatus(CEnemy enemy)
        {
            EnemyData = enemy;
            CurrentHp = enemy.Hp;
        }

        public bool IsDead() //적의 사망 처리 확인. 사용안한 코드. 없애야함.
        {
            return CurrentHp <= 0;
        }
        public void ShowEnemyStatus() //적의 현재 정보 보여줌.
        {
            Console.WriteLine($"[적]: {EnemyData.Name} [HP]:{CurrentHp}/{EnemyData.Hp} [공격력]:{EnemyData.Atk}");
        }

    }
}
