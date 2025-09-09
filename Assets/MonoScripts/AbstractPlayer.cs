using UnityEngine;
using System.Collections.Generic;

public abstract class AbstractPlayer
{
    //Create variables used by both player and enemy
    public List<AbstractCard> deck;
    public List<AbstractCard> masterDeck;
    public int health {get; set;}
    public int maxHealth = 100;
    public string name;

    public List<AbstractCard> hand;
    public List<AbstractCard> discardPile;

    public System.Random rand;

    public int maxHandSize = 8;
    int handsize = 3;

    //A 2 arg constructor that creates an AbtsractPlayer with max health, an empty hand/discard pile, and a deck
    public AbstractPlayer(List<AbstractCard> deck, int maxhealth){
        masterDeck = new List<AbstractCard>(deck);
        this.deck = new List<AbstractCard>(deck);
        this.maxHealth = maxhealth;
        health = this.maxHealth;
        rand = new System.Random();

        hand = new List<AbstractCard>();
        discardPile = new List<AbstractCard>();
    }

    //Combine the weapons bullets with the master deck
    public void addBullets(List<AbstractBullet> bullets){
        deck = new List<AbstractCard>(masterDeck);
        deck.AddRange(bullets);
    }

    //Randomly select cards from the deck fro the hand
    public void dealStartHand(){
        for(int i = 0; i < handsize; i++)
        {
            Draw();
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

    //Remove a single random card from the deck and put into hand
    public void Draw(){
        if(deck.Count > 0 && hand.Count < maxHandSize){
            SoundManager.playSound(SoundType.CardDraw);
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

    //Return only the name of this object
    public override string ToString(){
        return name;
    }

    //Method to combine the discard pile and deck
    public void Shuffle(){
        deck.AddRange(discardPile);
        discardPile = new List<AbstractCard>();
    }

    public List<AbstractCard> GetCardsOfType (string type)
    {
        return deck.FindAll(card => card.IsCardType(type));
    }

    public int CountCardsOfType(string type)
    {
        return GetCardsOfType(type).Count;
    }
}
