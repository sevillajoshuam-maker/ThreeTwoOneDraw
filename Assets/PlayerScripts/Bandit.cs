using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using System;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

public class Bandit : Enemy{
    System.Random random = new System.Random();

    public Bandit(): base(new List<AbstractCard>(), 100, 1, "Bandit"){
        for (int i = 0; i < 12; i++)
        {
            if (random.Next(1) == 0)
                deck.Add(new Defend());
            if (random.Next(2) == 0)
                deck.Add(new SixShooterBullet());
        }
    }
}
