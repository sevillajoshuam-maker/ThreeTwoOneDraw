using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class AbstractBullet : AbstractCard
{
    //Bullet specific instance variables
    private List<Func<int, int>> damageModifiers = new();
    private readonly int baseDamage;
    public readonly Speed SPEED;
    public readonly Sprite bulletSprite;
    public readonly Sprite superBulletSprite;
    public readonly SoundType sound;

    //Constructor that calls the AbstractCard constructor
    public AbstractBullet(string name, int cost, Sprite image, string desc, int baseDamage, Speed speed, Sprite bullet,
        Sprite superBullet, SoundType sound) : base(name, cost, image, desc)
    {
        this.sound = sound;
        this.baseDamage = baseDamage;
        SPEED = speed;
        bulletSprite = bullet;
        superBulletSprite = superBullet;
    }

    public int GetDamage()
    {
        return damageModifiers.Aggregate(baseDamage, (acc, fn) => fn(acc));
    }

    public void AddModifier(Func<int, int> modifier)
    {
        damageModifiers.Add(modifier);
    }
}

//All possible bullet speeds
public enum Speed
{
    Sluggish = 10, //10 ft per second
    Slow = 15, //15 ft per second
    Average = 20, //20 ft per second
    Fast = 30, // 30 ft per second
    Lightning = 50, // 50 ft per second
}