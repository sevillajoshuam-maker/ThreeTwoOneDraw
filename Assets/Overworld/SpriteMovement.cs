using UnityEngine;

public class SpriteMovement : MonoBehaviour
{
    [SerializeField]
    private Sprite[] sprites;
    private SpriteRenderer rendr;

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
        }
        else if(Input.GetKey(KeyCode.UpArrow)){
            gameObject.transform.position += new Vector3(0, 0.01f,0);
            rendr.sprite = sprites[2];
        }
        else if(Input.GetKey(KeyCode.RightArrow)){
            gameObject.transform.position += new Vector3(0.01f, 0,0);
            rendr.sprite = sprites[3];
        }
        else if(Input.GetKey(KeyCode.LeftArrow)){
            gameObject.transform.position -= new Vector3(0.01f, 0,0);
            rendr.sprite = sprites[1];
        }

    }
}
