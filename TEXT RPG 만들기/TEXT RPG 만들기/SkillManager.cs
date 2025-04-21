using Skill;
using Player;

namespace SkillManager
{
    internal class CSkillManager
    {
        public void UsingSkill(CPlayer player,CSkill skill)
        {
            if (player.Mp < skill.ManaCost)
            {
                Console.WriteLine("마나가 부족합니다.");
                return;
            }
            else
            {
                skill.TotalDamage(player);
                player.Mp -= skill.ManaCost;
                Console.WriteLine($"{player.Name}이{skill.SkillName}을 사용해 {skill.SkillDamage}만큼 피해를 주었습니다");
            }
        }
    }
}
