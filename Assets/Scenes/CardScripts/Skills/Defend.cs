using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Defend : AbstractSkill
{
    public Defend(): base("Defend", 2, ImageLibrary.take_aim_concept_art, "Negate the first bullet to hit you during the next three seconds.", Type.Defend){}

    public override void use(){
        DefenseManager.Instance.makeInvisible();
        DefenseManager.Instance.defend();
    }
}
