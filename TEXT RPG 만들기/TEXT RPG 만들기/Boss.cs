using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enemy;

namespace Boss
{
    internal class CBoss : CEnemy
    {
        public int BHeal { get; set; }
        public int BSkillDamage { get; set; }

        public CBoss(string name, int hp, int atk, int gold, int bheal, int bskillDamage) : base(name, hp, atk, 0)
        {
            this.BHeal = bheal;
            this.BSkillDamage = bskillDamage;
        }
    }
}
   

 

    