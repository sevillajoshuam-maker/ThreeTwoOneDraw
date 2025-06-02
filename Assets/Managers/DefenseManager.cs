using UnityEngine;
using System.Collections;

public class DefenseManager : MonoBehaviour
{
    //Create a single, static instance of this manager that will be referenced 
    public static DefenseManager Instance {get; private set;}

    //Store the three types of defends 
    public GameObject smallPlayerDefense;
    public GameObject mediumPlayerDefense;
    public GameObject largePlayerDefense;

    SpriteRenderer smallDefenseSprite;
    SpriteRenderer mediumDefenseSprite;
    SpriteRenderer largeDefenseSprite;

    
    //If the instance is the first one, it becomes the Instance.
    //Otherwise is is destroyed
    public void Awake(){
        if (Instance != null && Instance != this){
            Destroy(this);
        }
        else{
            Instance = this;

            //Retrieve the SpriteRenderersw for all types of defends
            smallDefenseSprite = smallPlayerDefense.GetComponent<SpriteRenderer>();
            mediumDefenseSprite = mediumPlayerDefense.GetComponent<SpriteRenderer>();
            largeDefenseSprite = largePlayerDefense.GetComponent<SpriteRenderer>();
        }
    }

    //Make the defense sprite visible of the passed size
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

    //Make the defense sprite invisible of the passed size
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

    //Activate the associated Defend() method of the passed defense size, this is called by a card's use() method
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
