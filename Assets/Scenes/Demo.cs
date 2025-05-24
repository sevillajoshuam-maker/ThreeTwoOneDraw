using UnityEngine;
using System.Collections.Generic;

public class Demo : MonoBehaviour
{
    public EncounterControl encounterControl;
    public CardPrefab cardBlueprint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        encounterControl = gameObject.AddComponent<EncounterControl>();
        encounterControl.cardBlueprint = this.cardBlueprint;

        for(int i = 0; i < 6; i++){
            Player.deck.Add(new SixShooterBullet());
            if(i % 2 == 0){
                Player.deck.Add(new Defend());
                Player.deck.Add(new TakeAim());
            }
        }

        encounterControl.startEncounter(new Encounter(Player.deck, new List<AbstractCard> {new SixShooterBullet()}));
           
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
