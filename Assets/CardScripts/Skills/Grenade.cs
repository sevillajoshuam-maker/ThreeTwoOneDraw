using UnityEngine;

public class Grenade : AbstractSkill
{
    //0 argument constructor that makes a basic take aim card
    public TakeAim() : base("Take Aim", 3, ImageLibrary.takeAim_art, "The next bullet you fire ignores any defense.")
    {
    }

    //When this card is played, make the next bullet played "super"
    public override void use(AbstractPlayer user, float duration)
    {
        EncounterControl.Instance.takeAimActive = true;
    }
}