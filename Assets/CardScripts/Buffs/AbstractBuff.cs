using UnityEngine;

public abstract class AbstractBuff : AbstractCard
{
    //Constructor that calls the AbstractCard constructor
    public AbstractBuff(string name, int cost, Sprite image, string desc): base(name, cost, image, desc){}
}
