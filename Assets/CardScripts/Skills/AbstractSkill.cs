using UnityEngine;

public abstract class AbstractSkill : AbstractCard
{
    //Skill specific type
    public readonly Type TYPE;

    //Constructor that calls the AbstractCard constructor
    public AbstractSkill(string name, int cost, Sprite image, string desc, Type type): base(name, cost, image, desc){
       TYPE = type;
    }
}

//All possible types of skills, including all sizes of defenses
public enum Type{
    SmallDefend,
    MediumDefend,
    LargeDefend, 
    Other
}

