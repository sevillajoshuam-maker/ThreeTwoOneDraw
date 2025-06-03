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

    //Remove health equal to passed parameter, health cannot got below 0
    public void takeDamage(int num){
        if(num >= 0){
            health -= num;
        }

        if(health <= 0){
            health = 0;
        }
    }

    //Heal health equal to passed parameter, health cannot exceed 100
    public void healDamage(int num){
        if(num >= 0){
            health += num;
        }
        if(health >= maxHealth){
            health = 100;
        }
    }
}
