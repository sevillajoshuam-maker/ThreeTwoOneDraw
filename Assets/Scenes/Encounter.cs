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

    //2 argument constructor that sets player and enemy decks and draws a starting hand
    public Encounter(List<AbstractCard> startDeck, Enemy enemy){
        currDeck = new List<AbstractCard>(startDeck);
        enemyDeck = new List<AbstractCard>(enemy.deck);
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

    //Randomly moves a card from the player deck to hand, if the handsize isn't too big
    public void Draw(){
        if(currDeck.Count > 0 && hand.Count < maxHandSize){
            int num = rand.Next(0, currDeck.Count);
            hand.Add(currDeck[num]);
            currDeck.RemoveAt(num);
        }
    }

    //Moves the provided card from the hand to the discard pile
    public void Discard(AbstractCard discardedCard){
        if(discardedCard != null){
            discardPile.Add(discardedCard);
            hand.Remove(discardedCard);
        }
    }

    //Returns the entire player deck, hand, and enemy deck as a string
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
