using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class Demo : MonoBehaviour
{
    public static Player player;

    public GameObject tempSlotImage;
    public GameObject tempTimer;

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
        player = new Player(starterDeck, 100, 2, 2);
        player.dealStartHand();
        
        //Create a new Enemeny object with a new hand
        Enemy starterEnemy = new Enemy(new List<AbstractCard>()
        {new Defend(), new Defend()}, 100, 1);

        //Temp TimeSlot
        TimeSlot[] slotArray = new TimeSlot[10];
        slotArray[0] = gameObject.AddComponent<TimeSlot>() as TimeSlot;
        slotArray[0].setData(0, tempTimer.GetComponent<TextMeshProUGUI>(), tempSlotImage);

        //Begin a new encounter with the player deck and an enemy deck with a single card
        EncounterControl.Instance.startEncounter(new Encounter(player, starterEnemy, slotArray));
           
    }
}
