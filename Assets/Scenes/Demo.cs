using UnityEngine;
using System.Collections.Generic;

public class Demo : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Set player health to 100 and create basic deck
        Player.healDamage(100);
        for(int i = 0; i < 6; i++){
            Player.deck.Add(new SixShooterBullet());
            if(i % 2 == 0){
                Player.deck.Add(new Defend());
                Player.deck.Add(new TakeAim());
            }
        }

        //Begin a new encounter with the player deck and an enemy deck with a single card
        EncounterControl.Instance.startEncounter(new Encounter(Player.deck, new Enemy(new List<AbstractCard>(Player.deck), 100, 0)));
           
    }
}
