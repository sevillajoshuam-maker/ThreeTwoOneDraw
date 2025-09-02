using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using System;
using TMPro;

public class EncounterControl : MonoBehaviour
{
    //Create a single, static instance of this manager that will be referenced 
    public static EncounterControl Instance {get; private set;}

    //Variables dictated by the passed Encounter
    public Encounter currEncounter;
    public Enemy currEnemy;
    public Player currPlayer;

    //Card Prefab
    [SerializeField]
    private CardPrefab cardBlueprint;

    //Currently selected card
    public CardPrefab hoveredCard {get; set;}

    //All UI elements
    public GameObject deckPlaceholder;
    public GameObject discardPilePlaceholder;
    public GameObject platformPlaceholder;
    public GameObject playerSpritePlaceholder;
    public GameObject enemySpritePlaceholder;
    public GameObject playerHealthBarSprite;
    public GameObject enemyHealthBarSprite;

    public Slider playerHealthBar;
    public Slider enemyHealthBar;

    private SpriteRenderer discardSpriteRenderer;

    //Holds the index of the card that is being selected
    public int position;

    //List of all cards that in the player hand
    public List<CardPrefab> visibleHand;
    public List<AbstractCard> deck;

    //Relays if the player or enemy can currently play a card or perform an action
    public bool enemyTurn;

    //Variable to hold if the next bullet negates enemy defends
    public bool takeAimActive;

    //If the instance is the first one, it becomes the Instance.
    //Otherwise is is destroyed
    public void Awake(){
        if (Instance != null && Instance != this){
            Destroy(this);
        }
        else{
            Instance = this;
        }
    }

    //Begin the passed Encounter instance
    public void startEncounter(Encounter encounter){
        currEnemy = encounter.enemy;
        currPlayer = encounter.player;
        currEncounter = encounter;
        
        currPlayer.addBullets(encounter.weapon.bullets);


        Debug.Log(currEnemy);
        Debug.Log(currPlayer);

        position = -1;
        visibleHand = new List<CardPrefab>();

        setUI(true);
        enemyTurn = true;

        discardSpriteRenderer = discardPilePlaceholder.GetComponent<SpriteRenderer>();

        takeAimActive = false;

        reapplyHand();
    }

    //Destroy all card prefabs and created a new list of prefabs to visually represent the current hand
    public void reapplyHand(){
        foreach(CardPrefab card in visibleHand){
            Destroy(card.gameObject);
        }
        visibleHand = new List<CardPrefab>();

        for(int i = 0; i < currEncounter.player.hand.Count; i++){
            CardPrefab newCard = Instantiate(cardBlueprint, cardPosition(i), Quaternion.identity) as CardPrefab;
            newCard.setData(currPlayer.hand[i], i);
            visibleHand.Add(newCard);
        }
    }

    //Calculate the card prefab position depending on hand size
    public Vector2 cardPosition(int num){
        if(currEncounter.player.hand.Count > 1){
            return new Vector2((currPlayer.hand.Count*1.45F)/ (float)(currPlayer.hand.Count - 1) * (num - ((float)(currPlayer.hand.Count)/3)), -4);
        }
        else{
            return new Vector2(0,-4);
        }
        
    }

    //Check every update whether the player draws or plays a card
    void Update(){
        //Calculate the current health of the enemy and player
        playerHealthBar.value = (float)currPlayer.health / currPlayer.maxHealth;
        enemyHealthBar.value = (float)currEnemy.health / currEnemy.maxHealth;

        //If the enemy has a turn, randomly pick an action and pause the enemy turn for the returned seconds
        if(enemyTurn){
            StartCoroutine(wait(currEnemy.trySomething()+currEnemy.costAdjust));
        }

        if(currEncounter != null){

            //Draw a card if the player clicks W
            if (Input.GetKeyDown(KeyCode.W))
            {
                //Only draws a new card if it is the player turn
                /*if(playerTurn && currPlayer.hand.Count < currPlayer.maxHandSize){
                    currPlayer.Draw();
                    //StartCoroutine(wait(currPlayer.drawCost, currPlayer));
                    reapplyHand();
                }*/

                if(currPlayer.hand.Count < currPlayer.maxHandSize){
                    currPlayer.Draw();
                    //StartCoroutine(wait(currPlayer.drawCost, currPlayer));
                    reapplyHand();
                }


            }
            //Exit the card selection if the player clicks S
            else if (Input.GetKeyDown(KeyCode.E)){
                currPlayer.Shuffle();
                discardSpriteRenderer.sprite = null;
                Debug.Log(currEncounter);
            }
            //Exit the card selection if the player clicks S
            else if (Input.GetKeyDown(KeyCode.DownArrow)){
                position = -1;
                if(hoveredCard != null){
                    hoveredCard.deselected();
                    hoveredCard = null;
                }
            }
            //Move the index of the selected card right when the playef clicks D
            else if (Input.GetKeyDown(KeyCode.RightArrow)){
                if(position == -1 || position == currPlayer.hand.Count - 1){
                    position = 0;
                }
                else{
                    position += 1;
                }
            //Move the index of the selected card left when the playef clicks A
            } else if (Input.GetKeyDown(KeyCode.LeftArrow)){
                if(position == -1 || position == 0){
                    position = currPlayer.hand.Count - 1;
                }
                else{
                    position -= 1;
                }
            }
            //The enemy fires a bullet when Q is pressed, for testing purposes
            else if (Input.GetKeyDown(KeyCode.Q)){
                BulletManager.Instance.fire(currEnemy, new SixShooterBullet());
            }

            //If a card is selected, the player has an action, and the user clicks the mouse  => Call the card's use() method and discard it
            else if(hoveredCard != null){

                //For any number key pressed (0-9), call the time slot with the associated index
                if(Input.GetKeyDown(KeyCode.Alpha1)){
                    playCardToSlot(0);
                }
                else if(Input.GetKeyDown(KeyCode.Alpha2)){
                    playCardToSlot(1);
                }
                else if(Input.GetKeyDown(KeyCode.Alpha3)){
                    playCardToSlot(2);
                }
                else if(Input.GetKeyDown(KeyCode.Alpha4)){
                    playCardToSlot(3);
                }
                else if(Input.GetKeyDown(KeyCode.Alpha5)){
                    playCardToSlot(4);
                }
                else if(Input.GetKeyDown(KeyCode.Alpha6)){
                    playCardToSlot(5);
                }
                else if(Input.GetKeyDown(KeyCode.Alpha7)){
                    playCardToSlot(6);
                }
                else if(Input.GetKeyDown(KeyCode.Alpha8)){
                    playCardToSlot(7);
                }
                else if(Input.GetKeyDown(KeyCode.Alpha9)){
                    playCardToSlot(8);
                }
                else if(Input.GetKeyDown(KeyCode.Alpha0)){
                    playCardToSlot(9);
                }
                
            }
        }

        //Visually show which card is selected and set hoveredCard to the currently selected card
        if(position < visibleHand.Count && position >= 0){
            if(hoveredCard != null){
                hoveredCard.deselected();
            }
            hoveredCard = visibleHand[position];
            hoveredCard.selected();
        }
    }

    //Turn on or off all UI elements
    private void setUI(bool state){
        //deckPlaceholder.SetActive(state);
        //discardPilePlaceholder.SetActive(state);
        platformPlaceholder.SetActive(state);
        playerSpritePlaceholder.SetActive(state);
        enemySpritePlaceholder.SetActive(state);
        playerHealthBarSprite.SetActive(state);
        enemyHealthBarSprite.SetActive(state);
    }

    //Turn off player turn for the passed cost
    public IEnumerator wait(int sec){
        EncounterControl.Instance.enemyTurn = false;

        //While there is time left
        float duration = sec;
        while(duration > 0){

            //Alter the time by the time since last frame
            duration -= Time.deltaTime;
            if(duration <= 0){
                duration = 0;
            }

            yield return null;  
        }
        EncounterControl.Instance.enemyTurn = true;
    }

    //The encounter ends whenever player or enemy reach 0 health
    public void endEncounter(AbstractPlayer winner){
        setUI(false);
        Debug.Log(winner);

        //Deactivate all visible cards
        GameObject[] visibleCards = GameObject.FindGameObjectsWithTag("Card");
        foreach(GameObject card in visibleCards){
            Destroy(card);
        }

        //Deactivate all visible bullets
        GameObject[] allBullets = GameObject.FindGameObjectsWithTag("Bullet");
        foreach(GameObject bullet in allBullets){
            Destroy(bullet);
        }
        gameObject.SetActive(false);
    }

    //Play the current card to the time slot at the provided index
    public void playCardToSlot(int index){

        //If the time slot does not exist or if it has a card already in it
        if(WeaponMono.Instance.allSlots[index] == null || WeaponMono.Instance.allSlots[index].occupied){
            Debug.Log("Not valid Slot");
            return;
        }

        //Start the specific time slot's timer with the card that is currently selected
        StartCoroutine(WeaponMono.Instance.allSlots[index].wait(hoveredCard.thisCard.COST, currPlayer, hoveredCard.thisCard));

        //Discard the card
        discardSpriteRenderer.sprite = hoveredCard.thisCard.IMAGE;
        currPlayer.Discard(hoveredCard.thisCard);
        
        //Reapply the visuals for the player's hand
        position = (position == 0)? position + 1: position - 1;
        reapplyHand();
    }
}
