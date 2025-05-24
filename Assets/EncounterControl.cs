using UnityEngine;
public class EncounterControl : MonoBehaviour
{
    public static Encounter currEncounter;
    public CardPrefab cardBlueprint;

    public void startEncounter(Encounter encounter){
        currEncounter = encounter;

        Debug.Log(currEncounter);

        CardPrefab newCard = Instantiate(cardBlueprint, new Vector2(0,0), Quaternion.identity) as CardPrefab;
        newCard.setData(new TakeAim());
        Debug.Log(newCard.ToString());
    }

}
