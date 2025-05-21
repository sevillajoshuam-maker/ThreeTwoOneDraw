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

}
