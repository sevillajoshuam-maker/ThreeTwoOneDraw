using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Defend : AbstractSkill
{
    //0 argument constructor that makes a basic defense with size small
    public Defend(): base("Defend", 2, ImageLibrary.take_aim_concept_art, "Negate any bullets within a SMALL window.", Type.SmallDefend){}

    //When the card is played, make the small defense invisible and destroy any bullets in the collider
    public override void use(AbstractPlayer user){
        Debug.Log(this);
        DefenseManager.Instance.makeInvisible(this.TYPE);
        DefenseManager.Instance.defend(this.TYPE);
    }
}
