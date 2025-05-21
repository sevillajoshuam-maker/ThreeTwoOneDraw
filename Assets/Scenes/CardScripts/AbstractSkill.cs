using UnityEngine;

public abstract class AbstractSkill : AbstractCard
{
    public AbstractSkill(string name, int cost, string filePath): base(name, cost, filePath){}
}
