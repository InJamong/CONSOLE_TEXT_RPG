using Job;

namespace Player
{
    public class CPlayer
    {
        public string Name { get; set; }
        public int Hp { get; set; }
        public int Mp { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }
        public int Gold { get; set; }
        public CJob Job { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public CPlayer(string name,int gold, CJob job,int x,int y)
        {
            this.Name = name;
            this.Job = job;
            this.Gold = gold;
            this.X = 0;
            this.Y = 0;
            Hp = job.BaseHp;
            Mp = job.BaseHp;
            Atk = job.BaseAtk;
            Def = job.BaseDef;


        }
        
    }
}
