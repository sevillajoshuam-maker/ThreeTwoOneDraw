using UnityEngine;

public class SpriteMovement : MonoBehaviour
{
    [SerializeField]
    private Sprite[] sprites;
    private SpriteRenderer rendr;

    private float count = 0;


    void Start(){
        rendr = gameObject.GetComponent<SpriteRenderer>();
        rendr.sprite = sprites[0];
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.DownArrow)){
            gameObject.transform.position -= new Vector3(0, 0.01f,0);
            rendr.sprite = sprites[0];
            walkingSound();
        }
        else if(Input.GetKey(KeyCode.UpArrow)){
            gameObject.transform.position += new Vector3(0, 0.01f,0);
            rendr.sprite = sprites[2];
            walkingSound();
        }
        else if(Input.GetKey(KeyCode.RightArrow)){
            gameObject.transform.position += new Vector3(0.01f, 0,0);
            rendr.sprite = sprites[3];
            walkingSound();
        }
        else if(Input.GetKey(KeyCode.LeftArrow)){
            gameObject.transform.position -= new Vector3(0.01f, 0,0);
            rendr.sprite = sprites[1];
            walkingSound();
        }
    }

    private void walkingSound(){
        if(!SoundManager.audioSource.isPlaying){
            SoundManager.playSound(SoundType.WildWestWalking);
            count = 10f;
        }
        else{
            count -= 0.01f;
        }
    }
}
