using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class Enemy : AbstractPlayer
{
    public int costAdjust {get; private set;}

    public Enemy(List<AbstractCard> deck, int maxHealth, int costAdjust) : base(deck, maxHealth){
        this.costAdjust = costAdjust;
    }

    public int trySomething(){
        int cost = 0;
        int num = rand.Next(0, hand.Count);
        cost = hand[num].COST;
        hand[num].use(this);
        return cost;
    }
}
