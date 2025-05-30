using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class EncounterControl : MonoBehaviour
{
    public static EncounterControl Instance {get; private set;}

    public Encounter currEncounter;
    [SerializeField]
    private CardPrefab cardBlueprint;
    public CardPrefab hoveredCard {private get; set;}

    public GameObject deckPlaceholder;
    public GameObject discardPilePlaceholder;
    public GameObject platformPlaceholder;
    public GameObject playerSpritePlaceholder;
    public GameObject enemySpritePlaceholder;

    private SpriteRenderer discardSpriteRenderer;

    public bool playerTurn;

    public void Awake(){
        if (Instance != null && Instance != this){
            Destroy(this);
        }
        else{
            Instance = this;
        }
    }

    public void startEncounter(Encounter encounter){
        currEncounter = encounter;
        setUI(true);
        playerTurn = true;

        discardSpriteRenderer = discardPilePlaceholder.GetComponent<SpriteRenderer>();

        reapplyHand();
    }

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

    public Vector2 cardPosition(int num){
        if(currEncounter.hand.Count > 1){
            return new Vector2((currEncounter.hand.Count*1.45F)/ (float)(currEncounter.hand.Count - 1) * (num - ((float)(currEncounter.hand.Count)/3)), -4);
        }
        else{
            return new Vector2(0,-4);
        }
        
    }

    void Update(){
        if(currEncounter != null){
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                currEncounter.Draw();
                reapplyHand();
            }
            else if(hoveredCard != null && Input.GetKeyDown(KeyCode.Space) && playerTurn){
                hoveredCard.use();
                StartCoroutine(EncounterControl.Instance.wait(hoveredCard.thisCard.COST));

                discardSpriteRenderer.sprite = hoveredCard.thisCard.IMAGE;
                currEncounter.Discard(hoveredCard.thisCard);
                
                reapplyHand();
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow)){
                BulletManager.Instance.fire("ENEMY", new SixShooterBullet());
            }
        }
        
    }

    private void setUI(bool state){
        deckPlaceholder.SetActive(state);
        discardPilePlaceholder.SetActive(state);
        platformPlaceholder.SetActive(state);
        playerSpritePlaceholder.SetActive(state);
        enemySpritePlaceholder.SetActive(state);

    }

    public IEnumerator wait(int sec){
        EncounterControl.Instance.playerTurn = false;
        yield return new WaitForSeconds(sec);
        EncounterControl.Instance.playerTurn = true;
    }
}
