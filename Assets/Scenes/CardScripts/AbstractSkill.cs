using UnityEngine;

public abstract class AbstractSkill : AbstractCard
{
    public AbstractSkill(string name, int cost, string filePath, string desc): base(name, cost, filePath, desc){}
}
