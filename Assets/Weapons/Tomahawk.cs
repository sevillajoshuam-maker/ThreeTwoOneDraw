using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class Tomahawk : AbstractWeapon
{
    //0 arg constructor
    //Adds 6 Six Shooter bullet cards and creates two InfoNodes (one of which is special and adds one to costs)
    public Tomahawk() : base(3f)
    {
        for (int i = 0; i < 4; i++)
        {
            this.bullets.Add(new TomahawkBullet());
        }

        this.nodes[0] = new InfoNode(0, new Vector2(-331f, -167.9f), new Vector2(-8.74f, -1.37f));
        this.nodes[1] = new InfoNode(1, new Vector2(-331f, 36f), new Vector2(-8.74f, 2.87f));
        this.nodes[2] = new InfoNode(2, new Vector2(-201f, 36f), new Vector2(-8.74f, 5.87f));
    }
}