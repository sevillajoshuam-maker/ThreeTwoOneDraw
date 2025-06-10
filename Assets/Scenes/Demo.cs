using UnityEngine;
using System.Collections.Generic;

public class Demo : MonoBehaviour
{
    public static Player player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        List<AbstractCard> starterDeck = new List<AbstractCard>();

        //Set player health to 100 and create basic deck
        for(int i = 0; i < 6; i++){
            starterDeck.Add(new SixShooterBullet());
            if(i % 2 == 0){
                starterDeck.Add(new Defend());
                starterDeck.Add(new TakeAim());
            }
        }

        //Create a new Player object with a new hand
        player = new Player(starterDeck, 100, 2);
        player.dealStartHand();
        
        //Create a new Enemeny object with a new hand
        Enemy starterEnemy = new Enemy(new List<AbstractCard>()
        {new Defend(), new Defend()}, 100, 1);

        //Begin a new encounter with the player deck and an enemy deck with a single card
        EncounterControl.Instance.startEncounter(new Encounter(player, starterEnemy));
           
    }
}
