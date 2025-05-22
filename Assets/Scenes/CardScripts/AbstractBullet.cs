using UnityEngine;

public abstract class AbstractBullet : AbstractCard
{
    public readonly int DAMAGE;
    public readonly int SPEED;

    public AbstractBullet(string name, int cost, string filePath, string desc, int damage, int speed): base(name, cost, filePath, desc){
        DAMAGE = damage;
        SPEED = speed;
    }
}
