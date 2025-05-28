using UnityEngine;

public class SixShooterBullet : AbstractBullet
{
    public SixShooterBullet(): base("Six Shooter Bullet", 2, ImageLibrary.take_aim_concept_art, "Fire one SLOW bullet that deals 25 damage", 1, Speed.Slow){

    }

    public override void use(){
        Debug.Log(this);
    }
}
