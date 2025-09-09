using UnityEngine;

public class CardBlueprint : AbstractSkill
{

    //These are all the default values
    //For an actual card, the needed values would be passed directly to base()
    private static string nameOfCard = "Default Card";
    private static int costOfCard = 1;
    private static Sprite imageOfCard = ImageLibrary.default_card;
    private static string descOfCard = "This is a default card";

    //0 argument constructor that calls the AbstractSkill constructor
    //Pass the arguments in that order to base
    public CardBlueprint():base(nameOfCard, costOfCard, imageOfCard, descOfCard){}

    //Override the use() method and put whatever the card does when it activates here
    public override void use(AbstractPlayer user, float duration, TimeSlot slot){
        Debug.Log("The Default Card Was Played");
    }
}
