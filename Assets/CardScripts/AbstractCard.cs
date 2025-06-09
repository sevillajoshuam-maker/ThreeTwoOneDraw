using UnityEngine;

public abstract class AbstractCard
{
    //All instance variables needed by all cards
    public readonly string NAME;
    public readonly int COST;
    public readonly Sprite IMAGE;
    private readonly string DESC;

    //4 argument constructor
    public AbstractCard(string name, int cost, Sprite image, string description){
        NAME = name;
        COST = cost;
        IMAGE = image;
        DESC = description;
    }

    //The tostring for all cards, simply returns the card name
    public override string ToString(){
        return NAME;
    }

    //Abstract method to be implement by specific cards
    //The method requires the user of the card (could be player or enemies) 
    // so card behaviour can depend on type of user playing said card
    public abstract void use(AbstractPlayer user);

}
