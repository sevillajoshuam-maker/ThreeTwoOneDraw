using UnityEngine;
using System.Collections.Generic;

public class Encounter
{
    public List<AbstractCard> currDeck;
    public List<AbstractCard> enemyDeck;

    public Encounter(List<AbstractCard> currDeck, List<AbstractCard> enemyDeck){
        this.currDeck = new List<AbstractCard>(currDeck);
        this.enemyDeck = new List<AbstractCard>(enemyDeck);
    }

    public override string ToString(){
        string deck1 = "[";
        for(int i = 0; i < currDeck.Count; i++){
            deck1 += currDeck[i];
            if(i != currDeck.Count-1){
                deck1 += ", ";
            }
            else{
                deck1 += "]";
            }
        }

        string deck2 = "[";
        for(int i = 0; i < enemyDeck.Count; i++){
            deck2 += enemyDeck[i];
            if(i != enemyDeck.Count-1){
                deck2 += ", ";
            }
            else{
                deck2 += "]";
            }
        }

        return "Player Deck: " + deck1 + "\nEnemy Deck: " + deck2;
    }

}
