using Skill;

namespace Job
{
    public abstract class CJob
    {
        public string JobName { get; set; }
        public int BaseHp { get; set; }
        public int BaseMp { get; set; }
        public int BaseAtk { get; set; }
        public int BaseDef { get; set; }

        public List<CSkill> Skill { get; set; } = new List<CSkill>();
    }
    public class CWarrior : CJob
    {
        public CWarrior()
        {
            JobName = "전사";
            BaseHp = 100;
            BaseMp = 30;
            BaseAtk = 10;
            BaseDef = 10;
            Skill.Add(new CSkill("신성검", 5, 20));
            Skill.Add(new CSkill("길로틴", 7, 50));
            Skill.Add(new CSkill("버서크 퓨리", 15, 100));
        }

    }
    public class CMage : CJob
    {
        public CMage()
        {
            JobName = "마법사";
            BaseHp = 70;
            BaseMp = 100;
            BaseAtk = 5;
            BaseDef = 8;
            Skill.Add(new CSkill("블레이즈", 10, 50));
            Skill.Add(new CSkill("인페르노", 13, 80));
            Skill.Add(new CSkill("종말의 부름", 20, 200));


        }

    }
    public class Ccheat : CJob
    {
        public Ccheat()
        {
            JobName = "Cheat";
            BaseHp = 100000;
            BaseMp = 100000;
            BaseAtk = 2000;
            BaseDef = 2000;
            Skill.Add(new CSkill("cheat 1", 10, 50));
            Skill.Add(new CSkill("cheat 2", 13, 80));
            Skill.Add(new CSkill("chaet 3", 20, 200));
        }
    }
}
