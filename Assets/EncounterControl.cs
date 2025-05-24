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

        Debug.Log(currEncounter);

        CardPrefab newCard = Instantiate(cardBlueprint, new Vector2(0,0), Quaternion.identity) as CardPrefab;
        newCard.setData(new TakeAim());
        Debug.Log(newCard.ToString());
    }

}
