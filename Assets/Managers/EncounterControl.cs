using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class EncounterControl : MonoBehaviour
{
    //Create a single, static instance of this manager that will be referenced 
    public static EncounterControl Instance {get; private set;}

    public Encounter currEncounter;
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
        currEncounter = encounter;
        setUI(true);
        playerTurn = true;

        discardSpriteRenderer = discardPilePlaceholder.GetComponent<SpriteRenderer>();

        reapplyHand();
    }

    //Destroy all card prefabs and created a new list of prefabs to visually represent the current hand
    public void reapplyHand(){
        GameObject[] visibleCards = GameObject.FindGameObjectsWithTag("Card");
        foreach(GameObject card in visibleCards){
            Destroy(card);
        }

        for(int i = 0; i < currEncounter.hand.Count; i++){
            CardPrefab newCard = Instantiate(cardBlueprint, cardPosition(i), Quaternion.identity) as CardPrefab;
            newCard.setData(currEncounter.hand[i], i);
        }
    }

    //Calculate the card prefab position depending on hand size
    public Vector2 cardPosition(int num){
        if(currEncounter.hand.Count > 1){
            return new Vector2((currEncounter.hand.Count*1.45F)/ (float)(currEncounter.hand.Count - 1) * (num - ((float)(currEncounter.hand.Count)/3)), -4);
        }
        else{
            return new Vector2(0,-4);
        }
        
    }

    //Check every update whether the player draws or plays a card
    void Update(){
        playerHealthBar.value = (float)Player.health / Player.maxHealth;
        enemyHealthBar.value = (float)currEncounter.enemy.health / currEncounter.enemy.maxHealth;

        if(currEncounter != null){
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                currEncounter.Draw();
                reapplyHand();
            }

            //If a card is selected, the player has an action, and the user clicks Spacebar => Call the card's use() method and discard it
            else if(hoveredCard != null && Input.GetKeyDown(KeyCode.Space) && playerTurn){
                hoveredCard.use();
                StartCoroutine(EncounterControl.Instance.wait(hoveredCard.thisCard.COST));

                discardSpriteRenderer.sprite = hoveredCard.thisCard.IMAGE;
                currEncounter.Discard(hoveredCard.thisCard);
                
                reapplyHand();
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow)){
                BulletManager.Instance.fire("ENEMY", new SixShooterBullet(), currEncounter.enemy);
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
    public IEnumerator wait(int sec){
        EncounterControl.Instance.playerTurn = false;
        yield return new WaitForSeconds(sec);
        EncounterControl.Instance.playerTurn = true;
    }
}
