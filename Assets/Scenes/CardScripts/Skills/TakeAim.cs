using UnityEngine;

public class TakeAim : AbstractSkill
{
    public TakeAim(): base("Take Aim", 3, ImageLibrary.take_aim_concept_art, "The next bullet you fire ignores any defense."){}

    public override void use(){
        Debug.Log(this);
    }
}
