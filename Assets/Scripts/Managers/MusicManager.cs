using UnityEngine;
using System.Collections.Generic;

public class MusicManager : MonoBehaviour
{

    [SerializeField]
    private AudioClip mainTheme;
    [SerializeField]
    private AudioClip intro;
    [SerializeField]
    private AudioClip tutorialTheme;

    private static List<AudioClip> sounds = new List<AudioClip>();
    public static AudioSource audioSource;

    private void Start()
    {
        DontDestroyOnLoad(this);
        audioSource = gameObject.GetComponent<AudioSource>();
        sounds.Add(mainTheme);
        sounds.Add(intro);
        sounds.Add(tutorialTheme);
    }

    public static void playSound(MusicType sound, float volume = 1)
    {
        if ((int)sound >= sounds.Count)
        {
            return;
        }
        audioSource.PlayOneShot(sounds[(int)sound], volume);
    }

}

public enum MusicType
{
    Theme,
    Intro,
    Tutorial
}
