using UnityEngine;
using System;
public class SpriteMovement : MonoBehaviour
{
    [SerializeField]
    private Sprite[] sprites;
    private SpriteRenderer rendr;

    private float count = 0;
    public float speed = 10;

    void Start(){
        rendr = gameObject.GetComponent<SpriteRenderer>();
        rendr.sprite = sprites[0];
    }
    // Update is called once per frame
    void Move(double x, double y, int animFrame)
    {
        //complicated math equations so that moving diagonally isn't faster than walking straight
        double x_y_Squared = Math.Pow(x, 2) + Math.Pow(y, 2);
        double a = x / Math.Sqrt(x_y_Squared);
        double b = y / Math.Sqrt(x_y_Squared);
        float i = (float)a; //math equations done in double datatype but vectors are done in floats
        float j = (float)b; //i and j convert double a and b into float datatype
        gameObject.transform.position += new Vector3(i, j, 0) * speed * Time.deltaTime;
        rendr.sprite = sprites[animFrame];
        walkingSound();
    }   
    void Update()
    {
        double horizontal = Input.GetAxisRaw("Horizontal");
        double vertical = Input.GetAxisRaw("Vertical");
        if (Input.GetKey(KeyCode.DownArrow)) {
            Move(horizontal, vertical, 0);
        }
        else if (Input.GetKey(KeyCode.UpArrow)) {
            Move(horizontal, vertical, 2);

        }
        else if (Input.GetKey(KeyCode.RightArrow)) {
            Move(horizontal, vertical, 3);

        }
        else if (Input.GetKey(KeyCode.LeftArrow)) {
            Move(horizontal, vertical, 1);

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
