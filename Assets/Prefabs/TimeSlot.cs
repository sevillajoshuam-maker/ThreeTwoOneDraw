using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using System;
using TMPro;

public class TimeSlot : MonoBehaviour
{
    public GameObject tempTimer;
    private TextMeshProUGUI timerText;
    private GameObject imageObject;
    private SpriteRenderer rendr;

    private int diff;
    public bool occupied {get; private set;}

    public void setData(int diff, TextMeshProUGUI text, GameObject image){
        this.diff = diff;
        timerText = text;
        this.imageObject = image;
        rendr = imageObject.GetComponent<SpriteRenderer>();
        occupied = false;
    }

    public IEnumerator wait(int sec, AbstractPlayer user, AbstractCard selectedCard){
        occupied = true;
        rendr.sprite = selectedCard.IMAGE;

        //While there is time left
        float duration = sec + diff;
        while(duration > 0){

            //Alter the time by the time since last frame
            duration -= Time.deltaTime;
            if(duration <= 0){
                duration = 0;
            }

            //Updated the temp timer
            if(!(user is Enemy)){
                timerText.text = Math.Round(duration, 4) + "";
            }

            yield return null;  
        }
        if(selectedCard != null){
                selectedCard.use(user);
        }
        rendr.sprite = null;
        occupied = false;
    }

}