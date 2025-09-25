using UnityEngine;
using System;
public class SpriteMovement : MonoBehaviour
{

    [SerializeField]
    public Animator anim;
    private float count = 0;
    public float moveSpeed = 10;
    private Vector3 input;
    private bool isMoving = false;
    public bool isFrozen = false;
    private float i = 0;
    private float j = 0;

    void Update()
    {
        double horizontal = Input.GetAxisRaw("Horizontal");
        double vertical = Input.GetAxisRaw("Vertical");
        Move(horizontal, vertical);
        Animate();
    }
    void Move(double x, double y)
    {
        if (!isFrozen) {
            //complicated math equations so that moving diagonally isn't faster than walking straight
            double x_y_Squared = Math.Pow(x, 2) + Math.Pow(y, 2);
            double a = x / Math.Sqrt(x_y_Squared);
            double b = y / Math.Sqrt(x_y_Squared);
            i = (float)x; //math equations done in double datatype but vectors are done in floats
            j = (float)y; //i and j convert double a and b into float datatype
            input = new Vector3(i, j, 0);
            gameObject.transform.position +=  input* moveSpeed * Time.deltaTime;
        }
    }
    

    private void walkingSound()
    {
        if (!SoundManager.audioSource.isPlaying)
        {
            SoundManager.playSound(SoundType.WildWestWalking);
            count = 10f;
        }
        else
        {
            count -= 0.01f;
        }
    }
    private void Animate()
    {
        if (!isFrozen) {
            if (input.magnitude > 0.1f || input.magnitude < -0.1f)
            {
                isMoving = true;
                walkingSound();
            }
            else
            {
                isMoving = false;
            }
            if (isMoving)
            {
                anim.SetFloat("x", i);
                anim.SetFloat("y", j);

            }
            anim.SetBool("isMoving",isMoving);
        }
    }
}
