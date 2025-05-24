using UnityEngine;
using System.Collections.Generic;

public class Demo : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for(int i = 0; i < 6; i++){
            Player.deck.Add(new SixShooterBullet());
            if(i % 2 == 0){
                Player.deck.Add(new Defend());
                Player.deck.Add(new TakeAim());
            }
        }

        EncounterControl.Instance.startEncounter(new Encounter(Player.deck, new List<AbstractCard> {new SixShooterBullet()}));
           
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
