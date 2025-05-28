using UnityEngine;
using System.Collections.Generic;

public class EncounterControl : MonoBehaviour
{
    public static EncounterControl Instance {get; private set;}

    public Encounter currEncounter;
    [SerializeField]
    private CardPrefab cardBlueprint;
    public CardPrefab hoveredCard;

    public GameObject deckPlaceholder;
    public GameObject discardPilePlaceholder;

    public SpriteRenderer discardSpriteRenderer;

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

        deckPlaceholder.SetActive(true);
        discardPilePlaceholder.SetActive(true);
        discardSpriteRenderer = discardPilePlaceholder.GetComponent<SpriteRenderer>();

        reapplyHand();
        Debug.Log(currEncounter);
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
            else if(hoveredCard != null && Input.GetKeyDown(KeyCode.Space)){
                hoveredCard.use();
                
                discardSpriteRenderer.sprite = hoveredCard.thisCard.IMAGE;
                currEncounter.Discard(hoveredCard.thisCard);
                
                reapplyHand();
            }
        }
        
    }

}
