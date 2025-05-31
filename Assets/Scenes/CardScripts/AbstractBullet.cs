using UnityEngine;

public abstract class AbstractBullet : AbstractCard
{
    public readonly int DAMAGE;
    public readonly Speed SPEED;
    public readonly Sprite bulletSprite;

    public AbstractBullet(string name, int cost, Sprite image, string desc, int damage, Speed speed, Sprite bullet): base(name, cost, image, desc){
        DAMAGE = damage;
        SPEED = speed;
        bulletSprite = bullet;
    }
}

public enum Speed{
    Sluggish = 10, //5 ft per second
    Slow = 15, //10 ft per second
    Average = 20, //15 ft per second
    Fast = 30, // 20 ft per second
    Lightning = 50, // 50 ft per second
}
