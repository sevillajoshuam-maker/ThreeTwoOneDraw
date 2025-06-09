using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

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

    //Relays if the player or enemy can currently play a card or perform an action
    public bool playerTurn;
    public bool enemyTurn;

    //Variable to hold if the next bullet negates enemy defends
    private bool takeAimActive;

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

        position = -1;
        visibleHand = new List<CardPrefab>();

        setUI(true);
        playerTurn = true;
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
            StartCoroutine(wait(currEnemy.trySomething()+currEnemy.costAdjust, currEnemy));
        }

        if(currEncounter != null){

            //Draw a card if the player clicks W
            if (Input.GetKeyDown(KeyCode.W))
            {
                currPlayer.Draw();
                reapplyHand();
            }
            //Exit the card selection if the player clicks S
            else if (Input.GetKeyDown(KeyCode.S)){
                position = -1;
                if(hoveredCard != null){
                    hoveredCard.deselected();
                    hoveredCard = null;
                }
            }
            //Move the index of the selected card right when the playef clicks D
            else if (Input.GetKeyDown(KeyCode.D)){
                if(position == -1 || position == currPlayer.hand.Count - 1){
                    position = 0;
                }
                else{
                    position += 1;
                }
            //Move the index of the selected card left when the playef clicks A
            } else if (Input.GetKeyDown(KeyCode.A)){
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
            else if(hoveredCard != null && (Input.GetMouseButtonDown(0)) && playerTurn){
                hoveredCard.use(currPlayer);
                StartCoroutine(EncounterControl.Instance.wait(hoveredCard.thisCard.COST, currPlayer));

                discardSpriteRenderer.sprite = hoveredCard.thisCard.IMAGE;
                currPlayer.Discard(hoveredCard.thisCard);
                
                position = (position == 0)? position + 1: position - 1;
                reapplyHand();
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
        deckPlaceholder.SetActive(state);
        discardPilePlaceholder.SetActive(state);
        platformPlaceholder.SetActive(state);
        playerSpritePlaceholder.SetActive(state);
        enemySpritePlaceholder.SetActive(state);
        playerHealthBarSprite.SetActive(state);
        enemyHealthBarSprite.SetActive(state);
    }

    //Turn off player turn for the passed cost
    public IEnumerator wait(int sec, AbstractPlayer user){
        if(user is Enemy){
            EncounterControl.Instance.enemyTurn = false;
        }
        else{
            EncounterControl.Instance.playerTurn = false;
        }
        yield return new WaitForSeconds(sec);
        if(user is Enemy){
            EncounterControl.Instance.enemyTurn = true;
        }
        else{
            EncounterControl.Instance.playerTurn = true;
        }
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
}
