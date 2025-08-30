using UnityEngine;
using System.Collections.Generic;

public abstract class AbstractWeapon
{
    //Create instance variables to holg the data of all time slots and all bullets
    public InfoNode[] nodes;
    public readonly List<AbstractCard> bullets;

    //2 arg constructor
    public AbstractWeapon(){
        this.bullets = new List<AbstractCard>();
        this.nodes = new InfoNode[10];
    }
}

//This class holds the data of a specific time slot
public class InfoNode{

    //Time slot specific data
    //Position of timer and slot as well as added cost
    public readonly int diff;
    public readonly Vector2 timer;
    public readonly Vector2 slot;

    //3 arg constructor
    public InfoNode(int diff, Vector2 timerLocation, Vector2 slotLocation){
        this.diff = diff;
        this.timer = timerLocation;
        this.slot = slotLocation;
    }

    //Virtual method that is overridden by any subclass which has behaviour when a bullet occupies this slot
    public virtual void ifBullet(AbstractBullet bullet){}
} 
