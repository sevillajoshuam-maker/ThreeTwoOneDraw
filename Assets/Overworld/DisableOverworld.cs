using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System;

public class DisableOverworld : MonoBehaviour
{

    public static DisableOverworld Instance { get; private set; }
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

    [SerializeField]
    private List<GameObject> allObjects = new List<GameObject>();
    public void enableOverworld(bool state)
    {
        foreach (GameObject singleObject in allObjects)
        {
            singleObject.SetActive(state);
        }
    }

}
