using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class WeaponMono : MonoBehaviour
{
    //The ten time slots that will be accessed by EncounterControl
    public TimeSlot[] allSlots = new TimeSlot[10];

    [SerializeField]
    private TimeSlot slotBlueprint;

    //Create a singleton instance
    public static WeaponMono Instance { get; private set; }

    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    //Call this method when combat starts and pass the current weapon
    public void activateWeapon(AbstractWeapon weapon)
    {
        //Attach each node from the weapon to the newly created time slots
        for (int i = 0; i < weapon.nodes.Length; i++)
        {
            if (weapon.nodes[i] != null)
            {
                TimeSlot slot = Instantiate(slotBlueprint, indexToPos[i], Quaternion.identity);
                slot.setData(weapon.nodes[i]);
                allSlots[i] = slot;
            }
        }
    }

    public Dictionary<int, Vector2> indexToPos = new Dictionary<int, Vector2>(){
        {0, new Vector2(-8.75f, 3.69f)},
        {1, new Vector2(-7.25f, 2.08f)},
        {2, new Vector2(-8.75f, 0.47f)},
        {3, new Vector2(-7.25f, -1.47f)},
        {4, new Vector2(-8.75f, -2.88f)}
    };
}
