using UnityEngine;
using System.Collections;

public class DefenseManager : MonoBehaviour
{
    public static DefenseManager Instance {get; private set;}

    public GameObject playerDefense;
    public BoxCollider2D playerDefenseActivate;

    public void Awake(){
        if (Instance != null && Instance != this){
            Destroy(this);
        }
        else{
            Instance = this;
            playerDefenseActivate = gameObject.GetComponent<BoxCollider2D>();
        }
    }

    public void makeVisible(){
        playerDefense.SetActive(true);
    }

    public void makeInvisible(){
        playerDefense.SetActive(false);
    }

    public void defend(){
        StartCoroutine(colliderActivate(0.5F));
    }

    void OnTriggerEnter2D(Collider2D other){
        Destroy(other.gameObject);
    }

    private IEnumerator colliderActivate(float num){
        playerDefenseActivate.enabled = true;
        yield return new WaitForSeconds(num);
        playerDefenseActivate.enabled = false;
    }
}
