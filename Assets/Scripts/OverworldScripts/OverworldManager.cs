using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class OverworldManager : MonoBehaviour
{
    public AbstractWeapon weapon;

    public List<AbstractCard> starterDeck = new List<AbstractCard>();

    // Update is called once per frame
    void Update()
    {

        if (!MusicManager.audioSource.isPlaying)
        {
            MusicManager.playSound(MusicType.Theme, 0.5F);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < 3; i++)
            {
                starterDeck.Add(new Defend());
                starterDeck.Add(new TakeAim());
            }
            weapon = new SixShooter();

            DisableOverworld.Instance.enableOverworld(false);
            EncounterControl.Instance.startEncounter(new Encounter(new Player(starterDeck, 100, 2, 2), new Bandit(), weapon));
        }
    }

}
