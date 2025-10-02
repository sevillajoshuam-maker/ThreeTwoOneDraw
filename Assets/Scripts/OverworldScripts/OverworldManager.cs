using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using System;
using TMPro;
using UnityEngine.SceneManagement;

public class OverworldManager : MonoBehaviour
{
    public static AbstractWeapon weapon = new SixShooter();
    public GameObject player;

    private static bool transition = false;

    public static List<AbstractCard> starterDeck = new List<AbstractCard>();

    void Start()
    {
        if (!SceneManager.GetSceneByName("CombatDemo").isLoaded)
        {
            SceneManager.LoadScene("CombatDemo", LoadSceneMode.Additive);
        }

        for (int i = 0; i < 3; i++)
        {
            starterDeck.Add(new Defend());
            starterDeck.Add(new TakeAim());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (!MusicManager.audioSource.isPlaying && !transition)
        {
            MusicManager.playSound(MusicType.Theme, 0.5F);
        }
    }

    public static IEnumerator startCombat(AbstractWeapon weapon, List<AbstractCard> deck)
    {
        transition = true;
        MusicManager.audioSource.Stop();
        MusicManager.playSound(MusicType.Intro);

        float duration = 4F;
        while (duration > 0)
        {

            //Alter the time by the time since last frame
            duration -= Time.deltaTime;
            if (duration <= 0)
            {
                duration = 0;
            }

            yield return null;
        }

        SoundManager.playSound(SoundType.SixShooterBullet);
        transition = false;
        DisableOverworld.Instance.enableOverworld(false);
        EncounterControl.Instance.startEncounter(new Encounter(new Player(deck, 100, 2, 2), new Bandit(), weapon));
    }

}
