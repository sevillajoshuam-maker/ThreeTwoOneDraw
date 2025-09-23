using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using System;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

public abstract class Enemy : AbstractPlayer
{
    //The value that will offset the seconds it takes for an enemy to play a card
    public int costAdjust {get; private set;}

    //2 arg constuctor that set name to "Enemy"
    public Enemy(List<AbstractCard> deck, int maxHealth, int costAdjust, string name) : base(deck, maxHealth, name){
        this.costAdjust = costAdjust;
    }

    int num = 0;
    int cost = 0;

    //Randomly selects a card in the enemy deck, plays it, and returns the amount of seconds until the next enemy turn
    //If the deck runs low on cards, the discardpile is shuffled back into the deck
    public int trySomething(){
        if(deck.Count <= 1){
            deck.AddRange(discardPile);
            discardPile = new List<AbstractCard>();
        }
        if(num >= deck.Count){
            return 0;
        }
        cost = deck[num].COST;
        deck[num].use(this, 0, null);
        discardPile.Add(deck[num]);
        deck.RemoveAt(num);
        updateCardTypeCounts();
        return cost;
    }

    public int bulletCardCount = 0;
    public int skillCardCount = 0;
    public int defendCardCount = 0;

    public void updateCardTypeCounts()
    {
        bulletCardCount = CountCardsOfType("Bullet");
        skillCardCount = CountCardsOfType("Skill");
        defendCardCount = CountCardsOfType("Defend");
    }

    public void suggestCardType(string type)
    {
 
        if (!"Bullet Skill Defend".Contains(type) || GetCardsOfType(type).Count == 0)
            return;
        List<AbstractCard> options = GetCardsOfType(type);
        num = deck.IndexOf(options[rand.Next(options.Count)]);
    }
}
