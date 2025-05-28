using UnityEngine;

public abstract class AbstractCard
{
    public readonly string NAME;
    public readonly int COST;
    public readonly Sprite IMAGE;
    private readonly string DESC;

    public AbstractCard(string name, int cost, Sprite image, string description){
        NAME = name;
        COST = cost;
        IMAGE = image;
        DESC = description;
    }

    public override string ToString(){
        return NAME;
    }

    public abstract void use();

}
