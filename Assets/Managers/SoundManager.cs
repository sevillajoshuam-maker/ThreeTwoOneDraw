using UnityEngine;
using System.Collections.Generic;
using System;

public class SoundManager : MonoBehaviour
{

    [SerializeField]
    private AudioClip[] sixShooterSounds;
    [SerializeField]
    private AudioClip[] defendSounds;

    private static List<AudioClip[]> sounds = new List<AudioClip[]>();
    public static SoundManager Instance;
    private AudioSource audioSource;

    private void Awake(){
        if (Instance != null && Instance != this){
            Destroy(this);
        }
        else{
            Instance = this;
        }
    }

    private void Start(){
        audioSource = gameObject.GetComponent<AudioSource>();
        sounds.Add(sixShooterSounds);
        sounds.Add(defendSounds);
    }

    public static void playSound(SoundType sound, float volume = 1){
        Instance.audioSource.PlayOneShot(sounds[((int)sound)][UnityEngine.Random.Range(0, sounds[((int)sound)].Length)], volume);
    }
}

public enum SoundType{
    SixShooterBullet,
    Defend
}