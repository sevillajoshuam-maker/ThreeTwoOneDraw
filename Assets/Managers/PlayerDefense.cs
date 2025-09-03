using UnityEngine;
using System.Collections;

public class PlayerDefense : MonoBehaviour
{
    BoxCollider2D hitBox;

    //Retrieve the collider attached to this game object
    void Awake(){
        hitBox = gameObject.GetComponent<BoxCollider2D>();
    }
    
    //Turn on the collider when this method is called by the DefenseManager, which is called by a card's use() method
    public void defend(){
        StartCoroutine(colliderActivate(0.1F));
    }

    //Destroy any bullet in the collider when it is activated
    void OnTriggerEnter2D(Collider2D other){
        BulletPrefab bullet = other.GetComponent<BulletPrefab>();
        SoundManager.playSound(SoundType.Defend);

        //If the bullet is super, the defend reverts the sprite to non-super and takes away super status
        //Otherwise, the bullet is negated
        if(bullet.isSuper){
            bullet.loseSuper();
        }
        else{
            Destroy(other.gameObject);
        }
    }

    //Activates collider for passed seconds (should usually be as short as possible)
    private IEnumerator colliderActivate(float num){
        hitBox.enabled = true;
        yield return new WaitForSeconds(num);
        hitBox.enabled = false;
    }
}
