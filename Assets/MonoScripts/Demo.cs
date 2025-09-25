using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class Demo : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Begin a new encounter with the next ecnounter stored in the DoNotDestroy script, EncounterResult
        EncounterControl.Instance.startEncounter(EncounterResults.Instance.nextEncounter);
    }
}
