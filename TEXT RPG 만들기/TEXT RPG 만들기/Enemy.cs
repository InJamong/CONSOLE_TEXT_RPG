﻿namespace Enemy;

public class CEnemy
{
    public string Name { get; set; }
    public int MaxHp {  get; set; }
    public int Hp {  get; set; }
    public int Atk { get; set; }
    public int Gold { get; set; }

    private int defaultHp;
    

    public CEnemy(string name, int hp, int atk, int gold)
    {
        this.Name = name;
        this.Hp = hp;
        this.Atk = atk;
        this.Gold = gold;

        MaxHp = hp;

        defaultHp = hp; //전투 이후에도 Hp리셋 시켜야하니깐 만듦.
    }
    public void ResetEnemyStatus() //전투 이후에 리셋 시킴.
    {
        Hp = defaultHp;
    }

}

