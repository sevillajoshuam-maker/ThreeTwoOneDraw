using UnityEngine;

public abstract class AbstractBullet : AbstractCard
{
    public readonly int DAMAGE;
    public readonly int SPEED;

    public AbstractBullet(string name, int cost, string filePath, int damage, int speed): base(name, cost, filePath){
        DAMAGE = damage;
        SPEED = speed;
    }
}
