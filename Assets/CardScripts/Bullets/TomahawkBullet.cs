using System;
using Unity.VisualScripting;
using UnityEngine;

public class TomahawkBullet : AbstractBullet
{
    //0 argument constructor that makes a basic six shooter bullet
    // TODO: Are we calling this a bullet?
    // TODO: change art
    public TomahawkBullet() : base("Tomahawk Bullet", 2, ImageLibrary.tomahawk_art,
        "Fire one FAST bullet that deals damage on duration it took to cast", 5, Speed.Fast, ImageLibrary.default_bullet_concept_art,
        ImageLibrary.default_superBullet_concept_art, SoundType.TomahawkBullet)
    {
    }

    //When the card is played, call the fire method with this bullet passed
    //Also propogate the shooter to the fire() method to dictate where the bullet spawns/bullet direction
    public override void use(AbstractPlayer user, float duration, TimeSlot slot)
    {
        AddModifier(x => (int)Math.Floor(duration) * x);
        BulletManager.Instance.fire(user, this, this.sound);
    }
}