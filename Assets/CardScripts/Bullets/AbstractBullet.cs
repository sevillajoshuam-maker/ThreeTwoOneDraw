using UnityEngine;

public abstract class AbstractBullet : AbstractCard
{
    //Bullet specific instance variables
    public readonly int DAMAGE;
    public readonly Speed SPEED;
    public readonly Sprite bulletSprite;
    public readonly Sprite superBulletSprite;

    //Constructor that calls the AbstractCard constructor
    public AbstractBullet(string name, int cost, Sprite image, string desc, int damage, Speed speed, Sprite bullet, Sprite superBullet): base(name, cost, image, desc){
        DAMAGE = damage;
        SPEED = speed;
        bulletSprite = bullet;
        superBulletSprite = superBullet;
    }
}

//All possible bullet speeds
public enum Speed{
    Sluggish = 10, //10 ft per second
    Slow = 15, //15 ft per second
    Average = 20, //20 ft per second
    Fast = 30, // 30 ft per second
    Lightning = 50, // 50 ft per second
}
