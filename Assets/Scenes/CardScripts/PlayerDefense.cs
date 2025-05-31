using UnityEngine;
using System.Collections;

public class PlayerDefense : MonoBehaviour
{
    BoxCollider2D hitBox;

    void Awake(){
        hitBox = gameObject.GetComponent<BoxCollider2D>();
    }
    
     public void defend(){
        StartCoroutine(colliderActivate(0.1F));
    }

    void OnTriggerEnter2D(Collider2D other){
        Destroy(other.gameObject);
    }

    private IEnumerator colliderActivate(float num){
        hitBox.enabled = true;
        yield return new WaitForSeconds(num);
        hitBox.enabled = false;
    }
}
