using UnityEngine;

public class Defend : AbstractSkill
{
    public Defend(): base("Defend", 2, ImageLibrary.take_aim_concept_art, "Negate the first bullet to hit you during the next three seconds."){}

    public override void use(){
        Debug.Log(this);
    }
}
