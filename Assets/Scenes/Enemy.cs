using UnityEngine;
using System.Collections.Generic;

public class Enemy
{
    public List<AbstractCard> deck {get; private set;}
    public int maxHealth {get; private set;}
    public int costAdjust {get; private set;}
    public int health {get; private set;}

    public Enemy(List<AbstractCard> deck, int maxHealth, int costAdjust){
        this.maxHealth = maxHealth;
        this.deck = deck;
        this.costAdjust = costAdjust;
        health = maxHealth;
    }
}
