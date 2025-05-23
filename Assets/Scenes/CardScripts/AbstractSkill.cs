using UnityEngine;

public abstract class AbstractSkill : AbstractCard
{
    public AbstractSkill(string name, int cost, Sprite image, string desc): base(name, cost, image, desc){}
}
