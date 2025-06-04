using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class EncounterControl : MonoBehaviour
{
    //Create a single, static instance of this manager that will be referenced 
    public static EncounterControl Instance {get; private set;}

    public Encounter currEncounter;
    public Enemy currEnemy;
    public Player currPlayer;
    [SerializeField]
    private CardPrefab cardBlueprint;
    public CardPrefab hoveredCard {private get; set;}

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

    //Relays if the player can currently play a card or perform an action
    public bool playerTurn;
    public bool enemyTurn;

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

        setUI(true);
        playerTurn = true;
        enemyTurn = true;

        discardSpriteRenderer = discardPilePlaceholder.GetComponent<SpriteRenderer>();

        reapplyHand();
    }

    //Destroy all card prefabs and created a new list of prefabs to visually represent the current hand
    public void reapplyHand(){
        GameObject[] visibleCards = GameObject.FindGameObjectsWithTag("Card");
        foreach(GameObject card in visibleCards){
            Destroy(card);
        }

        for(int i = 0; i < currEncounter.player.hand.Count; i++){
            CardPrefab newCard = Instantiate(cardBlueprint, cardPosition(i), Quaternion.identity) as CardPrefab;
            newCard.setData(currPlayer.hand[i], i);
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
        playerHealthBar.value = (float)currPlayer.health / currPlayer.maxHealth;
        enemyHealthBar.value = (float)currEnemy.health / currEnemy.maxHealth;

        if(enemyTurn){
            StartCoroutine(wait(currEnemy.trySomething()+currEnemy.costAdjust, currEnemy));
        }

        if(currEncounter != null){
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                currPlayer.Draw();
                reapplyHand();
            }

            //If a card is selected, the player has an action, and the user clicks Spacebar => Call the card's use() method and discard it
            else if(hoveredCard != null && Input.GetKeyDown(KeyCode.Space) && playerTurn){
                hoveredCard.use(currPlayer);
                StartCoroutine(EncounterControl.Instance.wait(hoveredCard.thisCard.COST, currPlayer));

                discardSpriteRenderer.sprite = hoveredCard.thisCard.IMAGE;
                currPlayer.Discard(hoveredCard.thisCard);
                
                reapplyHand();
            }
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

    public void endEncounter(AbstractPlayer winner){
        setUI(false);
        Debug.Log(winner);
        GameObject[] visibleCards = GameObject.FindGameObjectsWithTag("Card");
        foreach(GameObject card in visibleCards){
            Destroy(card);
        }
        gameObject.SetActive(false);
    }
}
