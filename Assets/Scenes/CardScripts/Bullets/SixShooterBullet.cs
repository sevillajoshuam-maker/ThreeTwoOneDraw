using UnityEngine;

public class SixShooterBullet : AbstractBullet
{
    public SixShooterBullet(): base("Six Shooter Bullet", 5, ImageLibrary.dark_take_aim_concept_art, "Fire one SLOW bullet that deals 25 damage", 1, Speed.Slow, ImageLibrary.default_bullet_concept_art){

    }

    public override void use(){
       BulletManager.Instance.fire("PLAYER", this);
    }
}
