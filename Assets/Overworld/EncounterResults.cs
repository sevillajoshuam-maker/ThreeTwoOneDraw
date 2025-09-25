using UnityEngine;
using System.Collections.Generic;

public class EncounterResults : MonoBehaviour
{
    public static EncounterResults Instance { get; private set; }
    public Encounter nextEncounter;
    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void setNextEnounter(Encounter encounter)
    {
        nextEncounter = encounter;
    }

}
