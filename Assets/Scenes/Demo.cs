using UnityEngine;
using System.Collections.Generic;

public class Demo : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Encounter demo = new Encounter(Player.deck, new List<AbstractCard>());
        Debug.Log("Current Player Deck: " + demo.currDeck);
        Debug.Log("Current Enemy Deck: " + demo.enemyDeck);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
