using UnityEngine;
using System.Collections.Generic;

public class Player : AbstractPlayer
{   
    //Holds the cost in seconds of drawing a card
    public int drawCost {get; private set;}

    //3 arg consturctor that sets name to "Player"
    public Player(List<AbstractCard> deck, int maxHealth, int drawCost) : base(deck, maxHealth){
        name = "Player";
        this.drawCost = drawCost;
    }

}
