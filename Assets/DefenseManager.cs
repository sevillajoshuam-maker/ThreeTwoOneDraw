using UnityEngine;
using System.Collections;

public class DefenseManager : MonoBehaviour
{
    public static DefenseManager Instance {get; private set;}

    public GameObject smallPlayerDefense;
    public GameObject mediumPlayerDefense;
    public GameObject largePlayerDefense;

    SpriteRenderer smallDefenseSprite;
    SpriteRenderer mediumDefenseSprite;
    SpriteRenderer largeDefenseSprite;

    public void Awake(){
        if (Instance != null && Instance != this){
            Destroy(this);
        }
        else{
            Instance = this;

            smallDefenseSprite = smallPlayerDefense.GetComponent<SpriteRenderer>();
            mediumDefenseSprite = mediumPlayerDefense.GetComponent<SpriteRenderer>();
            largeDefenseSprite = largePlayerDefense.GetComponent<SpriteRenderer>();
        }
    }

    public void makeVisible(Type size){
        if(size == Type.SmallDefend){
            smallDefenseSprite.enabled = true;
        }
        else if(size == Type.MediumDefend){
            mediumDefenseSprite.enabled = true;
        }
        else if(size == Type.LargeDefend){
            largeDefenseSprite.enabled = true;
        }
    }

    public void makeInvisible(Type size){
        if(size == Type.SmallDefend){
            smallDefenseSprite.enabled = false;
        }
        else if(size == Type.MediumDefend){
            mediumDefenseSprite.enabled = false;
        }
        else if(size == Type.LargeDefend){
            largeDefenseSprite.enabled = false;
        }
    }

    public void defend(Type size){
        if(size == Type.SmallDefend){
            smallPlayerDefense.GetComponent<PlayerDefense>().defend();
        }
        else if(size == Type.MediumDefend){
            mediumPlayerDefense.GetComponent<PlayerDefense>().defend();

        }
        else if(size == Type.LargeDefend){
            largePlayerDefense.GetComponent<PlayerDefense>().defend();

        }
    }
}
