using UnityEngine;
using System.Collections.Generic;

public class AbstractPlayer
{
    //Create the player deck and health to be used by all scripts
    public List<AbstractCard> deck;
    public List<AbstractCard> masterDeck;
    public int health {get; set;}
    public int maxHealth = 100;

    public List<AbstractCard> hand;
    public List<AbstractCard> discardPile;

    public System.Random rand;

    int maxHandSize = 8;
    int handsize = 3;

    public AbstractPlayer(List<AbstractCard> deck, int maxhealth){
        masterDeck = new List<AbstractCard>(deck);
        this.deck = new List<AbstractCard>(deck);
        this.maxHealth = maxhealth;
        health = this.maxHealth;
        rand = new System.Random();

        hand = new List<AbstractCard>();
        discardPile = new List<AbstractCard>();
    }

    public void dealStartHand(){
        for(int i = 0; i < handsize; i++)
        {
            int num = rand.Next(0, deck.Count);
            hand.Add(deck[num]);
            deck.RemoveAt(num);
        }
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

    public void Draw(){
        if(deck.Count > 0 && hand.Count < maxHandSize){
            int num = rand.Next(0, deck.Count);
            hand.Add(deck[num]);
            deck.RemoveAt(num);
        }
    }

    //Moves the provided card from the hand to the discard pile
    public void Discard(AbstractCard discardedCard){
        if(discardedCard != null){
            discardPile.Add(discardedCard);
            hand.Remove(discardedCard);
        }
    }
}
