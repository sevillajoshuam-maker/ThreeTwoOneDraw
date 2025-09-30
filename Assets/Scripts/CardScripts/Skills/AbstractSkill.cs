using UnityEngine;

public abstract class AbstractSkill : AbstractCard
{
    //Constructor that calls the AbstractCard constructor
    public AbstractSkill(string name, int cost, Sprite image, string desc): base(name, cost, image, desc){}
}
