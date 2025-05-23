using UnityEngine;

public abstract class AbstractBullet : AbstractCard
{
    public readonly int DAMAGE;
    public readonly int SPEED;

    public AbstractBullet(string name, int cost, Sprite image, string desc, int damage, int speed): base(name, cost, image, desc){
        DAMAGE = damage;
        SPEED = speed;
    }
}
