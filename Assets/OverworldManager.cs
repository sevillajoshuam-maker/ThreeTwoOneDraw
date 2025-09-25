using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class OverworldManager : MonoBehaviour
{
    public AbstractWeapon weapon;

    public List<AbstractCard> starterDeck = new List<AbstractCard>();

    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            starterDeck.Add(new Defend());
            starterDeck.Add(new TakeAim());
        }
        weapon = new SixShooter();
        EncounterResults.Instance.setNextEnounter(new Encounter(new Player(starterDeck, 100, 2, 2), new Bandit(), weapon));
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Additive);
            DisableOverworld.Instance.enableOverworld(false);
        }
    }
}
