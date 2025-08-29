using UnityEngine;
using TMPro;

public class WeaponMono : MonoBehaviour
{
    //The ten time slots that will be accessed by EncounterControl
    public TimeSlot[] allSlots = new TimeSlot[10];

    [SerializeField]
    private TimeSlot slotBlueprint; 

    [SerializeField]
    private GameObject tempSlotImage1;
    [SerializeField]
    private GameObject tempTimer1;

    [SerializeField]
    private GameObject tempSlotImage2;
    [SerializeField]
    private GameObject tempTimer2; 

    //Create a singleton instance
    public static WeaponMono Instance {get; private set;}

    //An array of game objects which hold the visual timer and slot
    GameObject[] timers;
    GameObject[] visualSlots;

    public void Awake(){
        if (Instance != null && Instance != this){
            Destroy(this);
        }
        else{

            //Populate the arrays with the current game objects retrived from the serialized field
            Instance = this;
            timers = new GameObject[10];
            timers[0] = tempTimer1;
            timers[1] = tempTimer2;

            visualSlots = new GameObject[10];
            visualSlots[0] = tempSlotImage1;
            visualSlots[1] = tempSlotImage2;
        }
    }

    //Call this method when combat startes and pass the current weapon
    public void activateWeapon(AbstractWeapon weapon){

        //Attach each node from the weapon to the newly created time slots
        for(int i = 0; i < weapon.nodes.Length; i++){
            if(weapon.nodes[i] != null){
                TimeSlot slot = Instantiate(slotBlueprint, new Vector2(0,0), Quaternion.identity);
                slot.setData(weapon.nodes[i], visualSlots[i], timers[i].GetComponent<TextMeshProUGUI>());
                allSlots[i] = slot;
            }
        }
    }
}
