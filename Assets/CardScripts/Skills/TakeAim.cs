using UnityEngine;

public class TakeAim : AbstractSkill
{
    //0 argument constructor that makes a basic take aim card
    public TakeAim(): base("Take Aim", 3, ImageLibrary.take_aim_concept_art, "The next bullet you fire ignores any defense.", Type.Other){}

    //When this card is played, print the ToString() of this card
    public override void use(AbstractPlayer user){
        Debug.Log(this);
    }
}
