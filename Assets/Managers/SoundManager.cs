using UnityEngine;

public class SoundManager : MonoBehaviour
{

    [SerializeField]
    private AudioClip[] sounds;
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
    }

    public static void playSound(SoundType sound, float volume = 1){
        Instance.audioSource.PlayOneShot(Instance.sounds[(int)sound], volume);
    }
}

public enum SoundType{
    SixShooterBullet,
    Defend
}