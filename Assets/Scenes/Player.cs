using UnityEngine;
using System.Collections.Generic;

public static class Player
{
    //Create the player deck and health to be used by all scripts
    public static List<AbstractCard> deck = new List<AbstractCard>();
    public static int health {get; private set;}
    public static int maxHealth = 100;

    //Remove health equal to passed parameter, health cannot got below 0
    public static void takeDamage(int num){
        if(num >= 0){
            health -= num;
        }

        if(health <= 0){
            health = 0;
        }
    }

    //Heal health equal to passed parameter, health cannot exceed 100
    public static void healDamage(int num){
        if(num >= 0){
            health += num;
        }
        if(health >= maxHealth){
            health = 100;
        }
    }

}
