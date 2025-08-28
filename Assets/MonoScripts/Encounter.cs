using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEngine.LightTransport;

public class Encounter
{
    //Instance variables to hold this specific enemy and player
    public Player player;
    public Enemy enemy;

    //2 argument constructor that sets the current player, current enemy, and passes the current weapon to WeaponMono
    public Encounter(Player player, Enemy enemy, AbstractWeapon weapon){
        this.enemy = enemy;
        this.player = player;
        WeaponMono.Instance.activateWeapon(weapon);
    }

    //Returns the entire player deck, hand, and enemy deck as a string
    public override string ToString(){
        string deck1 = "[";
        for(int i = 0; i < player.deck.Count; i++){
            deck1 += player.deck[i];
            if(i != player.deck.Count-1){
                deck1 += ", ";
            }
        }
        deck1 += "]";

        string handString = "[";
        for (int i = 0; i < player.hand.Count; i++)
        {
            handString += player.hand[i];
            if (i != player.hand.Count - 1)
            {
                handString += ", ";
            }
        }
        handString += "]";

        string deck2 = "[";
        for(int i = 0; i < enemy.deck.Count; i++){
            deck2 += enemy.deck[i];
            if(i != enemy.deck.Count-1){
                deck2 += ", ";
            }
        }
        deck2 += "]";

        return "Player Deck: " + deck1 + "\nPlayer Hand: " + handString + "\nEnemy Deck"+deck2;
    }

}
