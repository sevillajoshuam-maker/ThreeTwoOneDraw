using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEngine.LightTransport;

public class Encounter
{
    public List<AbstractCard> currDeck;
    public List<AbstractCard> enemyDeck;

    public List<AbstractCard> hand;

    private int handsize = 3;

    public Encounter(List<AbstractCard> currDeck, List<AbstractCard> enemyDeck){
        this.currDeck = new List<AbstractCard>(currDeck);
        this.enemyDeck = new List<AbstractCard>(enemyDeck);

        System.Random rand = new System.Random();

        hand = new List<AbstractCard>();
        for(int i = 0; i < handsize; i++)
        {
            int num = rand.Next(0, this.currDeck.Count);
            hand.Add(this.currDeck[num]);
            this.currDeck.RemoveAt(num);
        }

        Debug.Log(this);
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

        string handString = "[";
        for (int i = 0; i < hand.Count; i++)
        {
            handString += hand[i];
            if (i != hand.Count - 1)
            {
                handString += ", ";
            }
            else
            {
                handString += "]";
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

        return "Player Deck: " + deck1 + "\nPlayer Hand: " + handString + "\nEnemy Deck"+deck2;
    }

}
