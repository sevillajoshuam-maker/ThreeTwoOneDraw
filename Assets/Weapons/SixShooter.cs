using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class SixShooter : AbstractWeapon{

    //0 arg constructor
    //Adds 6 Six Shooter bullet cards and creates two InfoNodes (one of which is special and adds one to costs)
    public SixShooter() : base(null, new List<AbstractCard>()){
        for(int i = 0; i < 6; i++){
            this.bullets.Add(new SixShooterBullet());
        }
        this.nodes = new InfoNode[10];

        this.nodes[0] = new InfoNode(0, new Vector2(-331f, -167.9f), new Vector2(-8.74f, -1.37f));
        this.nodes[1] = new specialNode(1, new Vector2(-331f, 36f), new Vector2(-8.74f, 2.87f));
    }
}

//A InfoNode subclass test that overrides ifBullet(()
public class specialNode : InfoNode{

    //3 arg constructor that calls base constructor
    public specialNode(int diff, Vector2 timer, Vector2 slot): base(diff, timer, slot){}

    //If a bullet is played to this node, that bullet does double damage
    public override void ifBullet(AbstractBullet bullet){
        bullet.doubleDamage();
    }
}