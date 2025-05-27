using UnityEngine;
public class EncounterControl : MonoBehaviour
{
    public static EncounterControl Instance {get; private set;}

    public Encounter currEncounter;
    [SerializeField]
    private CardPrefab cardBlueprint;

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
        reapplyHand();
        Debug.Log(currEncounter);
        
    }

    public void reapplyHand(){
        for(int i = 0; i < currEncounter.hand.Count; i++){
            CardPrefab newCard = Instantiate(cardBlueprint, cardPosition(i), Quaternion.identity) as CardPrefab;
            newCard.setData(currEncounter.hand[i]);
        }
    }

    public Vector2 cardPosition(int num){
        return new Vector2((3/ (float)(currEncounter.hand.Count - 1) * (num - 1)), -4);
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.Space))
        {
        currEncounter.Draw();
        Debug.Log(currEncounter);
        }
    }

}
