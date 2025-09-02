using UnityEngine;

public abstract class AbstractDefend : AbstractCard
{
    //Skill specific type
    public readonly Type TYPE;

    //Constructor that calls the AbstractCard constructor
    public AbstractDefend(string name, int cost, Sprite image, string desc, Type type) : base(name, cost, image, desc)
    {
        TYPE = type;
    }
}

//All possible types of skills, including all sizes of defenses
public enum Type
{
    Small,
    Medium,
    Large,
    Other
}