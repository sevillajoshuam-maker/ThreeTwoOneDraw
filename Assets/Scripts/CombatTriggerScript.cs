using UnityEngine;
using UnityEngine.SceneManagement;

public class CombatTriggerScript : MonoBehaviour
{

    BoxCollider2D hitBox;

    void Awake(){
        hitBox = gameObject.GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D other){
        Debug.Log("Enter");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
    
}
