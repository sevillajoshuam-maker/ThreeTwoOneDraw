using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEngine.LightTransport;

public class Encounter
{
    public List<AbstractCard> currDeck;
    public List<AbstractCard> enemyDeck;
    public List<AbstractCard> discardPile;

    public List<AbstractCard> hand;

    System.Random rand;

    private int handsize = 3;
    private int maxHandSize = 8;

    public Encounter(List<AbstractCard> startDeck, List<AbstractCard> startEnemyDeck){
        currDeck = new List<AbstractCard>(startDeck);
        enemyDeck = new List<AbstractCard>(startEnemyDeck);
        discardPile = new List<AbstractCard>();

        rand = new System.Random();

        hand = new List<AbstractCard>();
        for(int i = 0; i < handsize; i++)
        {
            int num = rand.Next(0, currDeck.Count);
            hand.Add(currDeck[num]);
            currDeck.RemoveAt(num);
        }
 
    }

    public void Draw(){
        if(currDeck.Count > 0 && hand.Count < maxHandSize){
            int num = rand.Next(0, currDeck.Count);
            hand.Add(currDeck[num]);
            currDeck.RemoveAt(num);
        }
    }

    public void Discard(AbstractCard discardedCard){
        if(discardedCard != null){
            discardPile.Add(discardedCard);
            hand.Remove(discardedCard);
        }
    }

    public override string ToString(){
        string deck1 = "[";
        for(int i = 0; i < currDeck.Count; i++){
            deck1 += currDeck[i];
            if(i != currDeck.Count-1){
                deck1 += ", ";
            }
        }
        deck1 += "]";

        string handString = "[";
        for (int i = 0; i < hand.Count; i++)
        {
            handString += hand[i];
            if (i != hand.Count - 1)
            {
                handString += ", ";
            }
        }
        handString += "]";

        string deck2 = "[";
        for(int i = 0; i < enemyDeck.Count; i++){
            deck2 += enemyDeck[i];
            if(i != enemyDeck.Count-1){
                deck2 += ", ";
            }
        }
        deck2 += "]";

        return "Player Deck: " + deck1 + "\nPlayer Hand: " + handString + "\nEnemy Deck"+deck2;
    }

}
