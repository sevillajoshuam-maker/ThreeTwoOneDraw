using UnityEngine;
using System.Collections.Generic;
using System;

public class SoundManager : MonoBehaviour
{

    [SerializeField]
    private AudioClip[] sixShooterSounds;
    [SerializeField]
    private AudioClip[] defendSounds;
    [SerializeField]
    private AudioClip[] cardDrawSounds;
    [SerializeField]
    private AudioClip[] tomahawkSounds;
    [SerializeField]
    private AudioClip[] winchesterSounds;

    private static List<AudioClip[]> sounds = new List<AudioClip[]>();
    public static SoundManager Instance;
    private AudioSource audioSource;

    private void Awake(){
        if (Instance != null && Instance != this){
            Destroy(this);
        }
        else{
            Instance = this;
            audioSource = gameObject.GetComponent<AudioSource>();
            sounds.Add(sixShooterSounds);
            sounds.Add(defendSounds);
            sounds.Add(cardDrawSounds);
            sounds.Add(tomahawkSounds);
        }
    }

    private void Start(){
        audioSource = gameObject.GetComponent<AudioSource>();
        sounds.Add(sixShooterSounds);
        sounds.Add(defendSounds);
        sounds.Add(cardDrawSounds);
        sounds.Add(winchesterSounds);
    }

    public static void playSound(SoundType sound, float volume = 1){
        Instance.audioSource.PlayOneShot(sounds[((int)sound)][UnityEngine.Random.Range(0, sounds[((int)sound)].Length)], volume);
    }
}

public enum SoundType{
    SixShooterBullet,
    Defend, 
    CardDraw,
    TomahawkBullet, 
    WinchesterBullet
}