using UnityEngine;

public class SpriteMovement : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.DownArrow)){
            gameObject.transform.position -= new Vector3(0, 0.01f,0);
        }
        else if(Input.GetKey(KeyCode.UpArrow)){
            gameObject.transform.position += new Vector3(0, 0.01f,0);
        }
        else if(Input.GetKey(KeyCode.RightArrow)){
            gameObject.transform.position += new Vector3(0.01f, 0,0);
        }
        else if(Input.GetKey(KeyCode.LeftArrow)){
            gameObject.transform.position -= new Vector3(0.01f, 0,0);
        }

    }
}
