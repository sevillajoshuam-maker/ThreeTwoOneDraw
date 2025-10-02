using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using System;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

public class Bandit : Enemy
{
    System.Random random = new System.Random();

    public Bandit() : base(new List<AbstractCard>(), 100, 1, "Bandit")
    {
        for (int i = 0; i < 6; i++)
        {
            deck.Add(new Defend());
            deck.Add(new SixShooterBullet(Speed.Sluggish));
            deck.Add(new Dynamite());
        }
    }
}
