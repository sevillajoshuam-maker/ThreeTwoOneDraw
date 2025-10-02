using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using System;
using TMPro;
using UnityEngine.SceneManagement;

public class OverworldManager : MonoBehaviour
{
    public AbstractWeapon weapon;
    public GameObject player;

    private bool transition = false;

    public List<AbstractCard> starterDeck = new List<AbstractCard>();

    // Update is called once per frame
    void Update()
    {

        if (!MusicManager.audioSource.isPlaying && !transition)
        {
            MusicManager.playSound(MusicType.Theme, 0.5F);
        }

        if (Input.GetKeyDown(KeyCode.Space) && !transition)
        {
            for (int i = 0; i < 3; i++)
            {
                starterDeck.Add(new Defend());
                starterDeck.Add(new TakeAim());
            }
            weapon = new SixShooter();


            player.GetComponent<SpriteMovement>().isFrozen = true;
            StartCoroutine(startCombat(weapon, starterDeck));
        }
    }

    public IEnumerator startCombat(AbstractWeapon weapon, List<AbstractCard> deck)
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
