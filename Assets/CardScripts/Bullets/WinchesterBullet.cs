using System;
using Unity.VisualScripting;
using UnityEngine;

public class WinchesterBullet : AbstractBullet
{
    // TODO: change art
    public WinchesterBullet() : base("Winchester Bullet", 2, ImageLibrary.winchester_art,
        "Fire one FAST bullet that deals 5 damage", 5, Speed.Fast, ImageLibrary.default_bullet_concept_art,
        ImageLibrary.default_superBullet_concept_art, SoundType.WinchesterBullet)
    {
    }

    //When the card is played, call the fire method with this bullet passed
    //Also propogate the shooter to the fire() method to dictate where the bullet spawns/bullet direction
    public override void use(AbstractPlayer user, float duration)
    {
        BulletManager.Instance.fire(user, this, this.sound);
    }
}