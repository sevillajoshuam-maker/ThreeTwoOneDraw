using UnityEngine;
using System.Collections.Generic;

public class Player : AbstractPlayer
{   
    //Holds the cost in seconds of drawing a card
    public int drawCost {get; private set;}

    //Holds the cost in seconds of shuffling the discard pile into the deck
    public int shuffleCost {get; private set;}

    //3 arg consturctor that sets name to "Player"
    public Player(List<AbstractCard> deck, int maxHealth, int drawCost, int shuffleCost) : base(deck, maxHealth, "Player"){
        this.drawCost = drawCost;
        this.shuffleCost = shuffleCost;
    }

}
