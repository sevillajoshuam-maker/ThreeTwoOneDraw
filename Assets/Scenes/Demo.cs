using UnityEngine;
using System.Collections.Generic;

public class Demo : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for(int i = 0; i < 6; i++){
            Player.deck.Add(new SixShooterBullet());
        }
        
        Encounter demo = new Encounter(Player.deck, new List<AbstractCard>{new SixShooterBullet()});
        Debug.Log(demo);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
