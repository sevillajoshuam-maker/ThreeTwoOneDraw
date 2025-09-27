using System;
using Unity.VisualScripting;
using UnityEngine;

public class WinchesterBullet : AbstractBullet
{
    // TODO: change art
    public WinchesterBullet() : base("Winchester Bullet", 2, ImageLibrary.winchester_art,
        "Fire one FAST bullet that deals 5 damage", 5, Speed.Fast, ImageLibrary.winchester_bullet,
        ImageLibrary.winchester_bullet_super, SoundType.WinchesterBullet)
    {
    }

    //When the card is played, call the fire method with this bullet passed
    //Also propogate the shooter to the fire() method to dictate where the bullet spawns/bullet direction
    public override void use(AbstractPlayer user, float duration, TimeSlot slot)
    {
        BulletManager.Instance.fire(user, this, this.sound);
    }

    public override Vector3 flightPath(float x, float y, float pixelPerSecond)
    {
        return new Vector3(pixelPerSecond / 50F, pixelPerSecond / 50F * -0.05F * (float)(1 / Math.Sqrt(8 - x)), 0);
    }
}