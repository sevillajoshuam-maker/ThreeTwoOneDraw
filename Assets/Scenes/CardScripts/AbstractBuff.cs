using UnityEngine;

public abstract class AbstractBuff : AbstractCard
{
    public AbstractBuff(string name, int cost, Sprite image, string desc): base(name, cost, image, desc){}
}
