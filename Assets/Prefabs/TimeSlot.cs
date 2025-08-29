using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using System;
using TMPro;

public class TimeSlot : MonoBehaviour
{
    //The game objects to visually show what card is occupying this slot and current time
    private TextMeshProUGUI timerText;
    private GameObject imageObject;
    private SpriteRenderer rendr;

    //The info related to this slot
    private InfoNode thisInfo;

    //Boolean for if the slot is open to another card or not
    public bool occupied {get; private set;}

    //Set all the data associated with this slot
    public void setData(InfoNode info, GameObject image, TextMeshProUGUI text){
        thisInfo = info;
        timerText = text;
        this.imageObject = image;
        rendr = imageObject.GetComponent<SpriteRenderer>();
        occupied = false;
    }

    //Start this slot's timer based on the provided cards cost
    public IEnumerator wait(int sec, AbstractPlayer user, AbstractCard selectedCard){
        //Make the slot occupied
        occupied = true;

        //If its a bullet, call the node's corresponding method
        if(selectedCard is AbstractBullet){
            Debug.Log(thisInfo is specialNode);
            thisInfo.ifBullet((AbstractBullet)selectedCard);
        }

        //Set the image to the sprite of the occupying card
        rendr.sprite = selectedCard.IMAGE;

        //While there is time left
        float duration = sec + thisInfo.diff;
        while(duration > 0){

            //Alter the time by the time since last frame
            duration -= Time.deltaTime;
            if(duration <= 0){
                duration = 0;
            }

            //Updated the temp timer
            timerText.text = Math.Round(duration, 4) + "";

            yield return null;  
        }

        //Use the passed cards method
        if(selectedCard != null){
                selectedCard.use(user);
        }

        //Remove sprite and change the slot to unoccupied
        rendr.sprite = null;
        occupied = false;
    }

}