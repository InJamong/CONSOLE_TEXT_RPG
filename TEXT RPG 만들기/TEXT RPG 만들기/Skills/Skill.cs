using Player;

namespace Skill
{
    public class CSkill
    {
        public string SkillName {  get; set; } //스킬 이름 프로퍼티
        public int ManaCost { get; set; } //마나 사용량 프로퍼티
        public int Skillfactor {  get; set; } //스킬 계수 프로퍼티
        public int SkillDamage { get; set; } // 스킬 계수 * 플레이어 공격력/3
        
        public int TotalDamage(CPlayer player)
        {
            SkillDamage = Skillfactor * player.Atk/4;
            return SkillDamage;
        }

        public CSkill(string skillname, int skillfactor, int manacost )
        {
            this.SkillName = skillname;
            this.ManaCost = manacost;
            this.Skillfactor = skillfactor;
            
        }
    }
}
