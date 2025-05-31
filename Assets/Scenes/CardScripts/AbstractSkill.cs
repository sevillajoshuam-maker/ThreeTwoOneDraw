using UnityEngine;

public abstract class AbstractSkill : AbstractCard
{
    public readonly Type TYPE;

    public AbstractSkill(string name, int cost, Sprite image, string desc, Type type): base(name, cost, image, desc){
       TYPE = type;
    }
}

public enum Type{
    SmallDefend,
    MediumDefend,
    LargeDefend, 
    Other
}

