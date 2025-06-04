using UnityEngine;

public class SixShooterBullet : AbstractBullet
{
    //0 argument constructor that makes a basic six shooter bullet
    public SixShooterBullet(): base("Six Shooter Bullet", 3, ImageLibrary.dark_take_aim_concept_art, "Fire one SLOW bullet that deals 25 damage", 25, Speed.Slow, ImageLibrary.default_bullet_concept_art){

    }

    //When the card is played, call the fire method with this bullet passed
    public override void use(AbstractPlayer user){
        Debug.Log(this);
       BulletManager.Instance.fire(user, this);
    }
}
