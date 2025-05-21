using UnityEngine;

public abstract class AbstractCard
{
    public readonly string NAME;
    public readonly int COST;
    private readonly string IMAGE;

    public AbstractCard(string name, int cost, string filePath){
        NAME = name;
        COST = cost;
        IMAGE = filePath;
    }

}
