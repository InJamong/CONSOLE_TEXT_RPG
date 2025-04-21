namespace Enemy;

public class CEnemy
{
    public string Name { get; set; }
    public int Hp {  get; set; }
    public int Atk { get; set; }
    public int Gold { get; set; }
    

    public CEnemy(string name, int hp, int atk, int gold)
    {
        this.Name = name;
        this.Hp = hp;
        this.Atk = atk;
        this.Gold = gold;
    }
  
    
    
}

