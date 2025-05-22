using UnityEngine;

public abstract class AbstractCard
{
    public readonly string NAME;
    public readonly int COST;
    private readonly string IMAGE;
    private readonly string DESC;

    public AbstractCard(string name, int cost, string filePath, string description){
        NAME = name;
        COST = cost;
        IMAGE = filePath;
        DESC = description;
    }

    public override string ToString(){
        return NAME;
    }

}
