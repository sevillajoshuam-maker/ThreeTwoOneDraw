using UnityEngine;
using System.Collections.Generic;

public class Player : AbstractPlayer
{   
    //2 arg consturctor that sets name to "Player"
    public Player(List<AbstractCard> deck, int maxHealth) : base(deck, maxHealth){
        name = "Player";
    }

}
