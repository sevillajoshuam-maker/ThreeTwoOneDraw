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
            starterDeck.Add(new AdrenalineShot());
            starterDeck.Add(new Defend());
        }

        //Create a new Player object with a new hand
        player = new Player(starterDeck, 100, 2, 2);
        player.dealStartHand();

        List<AbstractCard> enemyStarterDeck = new List<AbstractCard>();

        for (int i = 0; i < 12; i++)
        {
            if (random.Next(3) == 0)
                enemyStarterDeck.Add(new TakeAim());
            if (random.Next(2) == 0)
                enemyStarterDeck.Add(new Defend());
            if (random.Next(1) == 0)
                enemyStarterDeck.Add(new SixShooterBullet());
        }

        //Create a new Enemy object with a new hand
        Enemy starterEnemy = new Enemy(enemyStarterDeck, 100, 1);

        //Create a basic six shooter gun
        Tomahawk starterGun = new Tomahawk();
        
        //Begin a new encounter with the player deck and an enemy deck with a single card
        EncounterControl.Instance.startEncounter(new Encounter(player, starterEnemy, starterGun));
           
    }
}
