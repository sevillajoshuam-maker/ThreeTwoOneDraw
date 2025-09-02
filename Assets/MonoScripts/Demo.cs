using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class Demo : MonoBehaviour
{
    public static Player player;

    public GameObject tempSlotImage1;
    public GameObject tempTimer1;

    public GameObject tempSlotImage2;
    public GameObject tempTimer2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        List<AbstractCard> starterDeck = new List<AbstractCard>();

        //Set player health to 100 and create basic deck
        for(int i = 0; i < 3; i++){
            starterDeck.Add(new Defend());
            starterDeck.Add(new TakeAim());
            starterDeck.Add(new CardBlueprint());
        }

        //Create a new Player object with a new hand
        player = new Player(starterDeck, 100, 2, 2);
        player.dealStartHand();
        
        //Create a new Enemeny object with a new hand
        Enemy starterEnemy = new Enemy(new List<AbstractCard>()
        {new Defend(), new Defend()}, 100, 1);

        //Create a basic six shooter gun
        SixShooter starterGun = new SixShooter();
        
        //Begin a new encounter with the player deck and an enemy deck with a single card
        EncounterControl.Instance.startEncounter(new Encounter(player, starterEnemy, starterGun));
           
    }
}
