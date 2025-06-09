using UnityEngine;
using System.Collections;

public class DefenseManager : MonoBehaviour
{
    //Create a single, static instance of this manager that will be referenced 
    public static DefenseManager Instance {get; private set;}

    //Store the three types of defends, and the enemy defend
    public GameObject smallPlayerDefense;
    public GameObject mediumPlayerDefense;
    public GameObject largePlayerDefense;
    public GameObject smallEnemyDefense;

    //Store all sprite renderers for different defenses
    SpriteRenderer smallDefenseSprite;
    SpriteRenderer mediumDefenseSprite;
    SpriteRenderer largeDefenseSprite;
    SpriteRenderer smallEnemyDefenseSprite;
    
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
            smallEnemyDefenseSprite = smallEnemyDefense.GetComponent<SpriteRenderer>();
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
    public void defend(Type size, AbstractPlayer user){
        if(user is Enemy){
            smallEnemyDefense.GetComponent<PlayerDefense>().defend();
            StartCoroutine(show(0.5F, smallEnemyDefenseSprite));
        }
        else{
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

    //Helper method that enables the passed sprite for specified number of seconds
    //Used to flash the sprite of enemy defends when played
    public IEnumerator show(float num, SpriteRenderer sprite){
        sprite.enabled = true;
        yield return new WaitForSeconds(num);
        sprite.enabled = false;
    }

    void Update(){

        //If there is a currently selected card that is a skill
        if(EncounterControl.Instance.hoveredCard != null && EncounterControl.Instance.hoveredCard.thisCard is AbstractSkill){

            //Save the type of the selected card
            Type size = ((AbstractSkill)EncounterControl.Instance.hoveredCard.thisCard).TYPE;

            //Pass the correct defense game object depending on type of hovered card
            if(size == Type.SmallDefend){
                defenseFollowMouse(smallPlayerDefense);
            }
            else if(size == Type.MediumDefend){
                defenseFollowMouse(mediumPlayerDefense);
            }
            else if(size == Type.LargeDefend){
                defenseFollowMouse(largePlayerDefense);
            }
        }
    }

    //Activates the sprites and forces the passed defense Game Object to follow the mouse
    void defenseFollowMouse(GameObject defense){
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        defense.GetComponent<SpriteRenderer>().enabled = true;
        defense.transform.position = new Vector3(mousePosition.x, mousePosition.y, 0);
    }
}
