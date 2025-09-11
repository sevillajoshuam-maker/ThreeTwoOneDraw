using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class Demo : MonoBehaviour
{
    public static Player player;
    System.Random random = new System.Random();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        List<AbstractCard> starterDeck = new List<AbstractCard>();

        //Set player health to 100 and create basic deck
        for(int i = 0; i < 3; i++){
            starterDeck.Add(new TakeAim());
            starterDeck.Add(new Defend());
        }

        //Create a new Player object with a new hand
        player = new Player(starterDeck, 100, 2, 2);
        player.dealStartHand();

        //Create a new Enemy object with a new hand
        Bandit starterEnemy = new Bandit();

        //Create a basic six shooter gun
        Tomahawk starterGun = new Tomahawk();
        
        //Begin a new encounter with the player deck and an enemy deck with a single card
        EncounterControl.Instance.startEncounter(new Encounter(player, starterEnemy, starterGun));
           
    }
}
