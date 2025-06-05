using UnityEngine;
using System.Collections;

public class CardPrefab : MonoBehaviour 
{
    public AbstractCard thisCard;
    public SpriteRenderer rendr;

    private int originalOrder;

    //Sets what card it is and its order in the hand.
    //Uses the passed card to set sprite.
    public void setData(AbstractCard card, int num){

        thisCard = card;
        rendr = gameObject.GetComponent<SpriteRenderer>();
        rendr.size += new Vector2(10f, 10f);

        rendr.sortingOrder = num;
        originalOrder = rendr.sortingOrder;
        rendr.sprite = thisCard.IMAGE;
    }

    //Called when this card is the hoveredCard and the player clicks spacebar.
    //Calls the respective cards own use() method
    public void use(AbstractPlayer user){
        thisCard.use(user);
    }

    public override string ToString(){
        return thisCard.ToString();
    }

    public void selected(){
        gameObject.transform.position += new Vector3(0, 1, 0);
        rendr.sortingOrder = 100;

        if(thisCard is AbstractSkill && ((AbstractSkill) thisCard).TYPE.ToString().EndsWith("Defend")){
            DefenseManager.Instance.makeVisible(((AbstractSkill) thisCard).TYPE);
        }
    }

    public void deselected(){
        gameObject.transform.position -= new Vector3(0, 1, 0);
        rendr.sortingOrder = originalOrder;

         if(thisCard is AbstractSkill && ((AbstractSkill) thisCard).TYPE.ToString().EndsWith("Defend")){
            DefenseManager.Instance.makeInvisible(((AbstractSkill) thisCard).TYPE);
        }
    }

    /*Whenever the player hovers over the card, change location and set it to hoveredCard
    void OnMouseEnter(){
        EncounterControl.Instance.hoveredCard = this;
        gameObject.transform.position += new Vector3(0, 1, 0);
        rendr.sortingOrder = 100;

        //If the card is a defense, call makeVisible() with the defense size
        if(thisCard is AbstractSkill && ((AbstractSkill) thisCard).TYPE.ToString().EndsWith("Defend")){
            DefenseManager.Instance.makeVisible(((AbstractSkill) thisCard).TYPE);
        }
    }

    //Whenever the mouse exits the card, put the card back in place and set hoveredCard to null
    void OnMouseExit(){
        gameObject.transform.position -= new Vector3(0, 1, 0);
        rendr.sortingOrder = originalOrder;
        EncounterControl.Instance.hoveredCard = null;

        //If the card is a defense, call makeInvisible() with the defense size
        if(thisCard is AbstractSkill && ((AbstractSkill) thisCard).TYPE.ToString().EndsWith("Defend")){
            DefenseManager.Instance.makeInvisible(((AbstractSkill) thisCard).TYPE);
        }
    }
    */

}
