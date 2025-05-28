using UnityEngine;

public abstract class AbstractBullet : AbstractCard
{
    public readonly int DAMAGE;
    public readonly Speed SPEED;

    public AbstractBullet(string name, int cost, Sprite image, string desc, int damage, Speed speed): base(name, cost, image, desc){
        DAMAGE = damage;
        SPEED = speed;
    }
}

public enum Speed{
    Sluggish,
    Slow,
    Average,
    Fast,
    Lightning,
}
