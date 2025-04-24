using Skill;
using Player;
using Battle;
using Enemy;
namespace SkillManager

{
    public class CSkillManager
    {
        //public void UsingSkill(CPlayer player,CSkill skill, CEnemy enemy) 이렇게 두니깐 마나가 부족해도 Battle 클래스에서 case2번이 끝나버리네?
        public bool UsingSkill(CPlayer player, CSkill skill, CEnemy enemy) //bool형태로 바꿔서 마나가 부족할시 case2가 안끝나게.
        {
                if (player.Mp < skill.ManaCost)
                {
                    Console.WriteLine("마나가 부족합니다.");
                    return false;
                }
                else
                {
                    int skillTotalDamage = skill.TotalDamage(player);
                    player.Mp -= skill.ManaCost;
                    enemy.Hp -= skill.SkillDamage;
               

                    Console.WriteLine($"{player.Name}용사님이 {skill.SkillName}을 사용해 {skillTotalDamage}만큼 피해를 주었습니다");
                    Console.WriteLine($"{enemy.Name}의 남은 HP:{Math.Max(0, enemy.Hp)}");
                    return true;
                }
        }
        public static void ShowSkills(CPlayer player)
        {
            Console.WriteLine("=== 보유 스킬 목록 ===");
            int index = 1;
            foreach (var skill in player.Job.Skill)
            {
                int skillTotalDamage = skill.TotalDamage(player);

                Console.WriteLine($"{index++}. {skill.SkillName} - 스킬 데미지: {skillTotalDamage}, 마나 소모량: {skill.ManaCost}");
            }

        }
    }
}
