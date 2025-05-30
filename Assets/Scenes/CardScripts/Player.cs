using UnityEngine;
using System.Collections.Generic;

public static class Player
{
    public static List<AbstractCard> deck = new List<AbstractCard>();
    public static int health {get; private set;}

    public static void takeDamage(int num){
        if(num >= 0){
            health -= num;
        }

        if(health <= 0){
            health = 0;
        }
    }

    public static void healDamage(int num){
        if(num >= 0){
            health += num;
        }
        if(health >= 100){
            health = 100;
        }
    }

}
