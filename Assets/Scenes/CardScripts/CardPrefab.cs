using UnityEngine;

public class CardPrefab : MonoBehaviour 
{
    public AbstractCard thisCard;
    public SpriteRenderer rendr;

    private int originalOrder;


    public void setData(AbstractCard card, int num){

        thisCard = card;
        rendr = gameObject.GetComponent<SpriteRenderer>();
        rendr.size += new Vector2(10f, 10f);

        rendr.sortingOrder = num;
        originalOrder = rendr.sortingOrder;
        rendr.sprite = thisCard.IMAGE;
    }

    public override string ToString(){
        return thisCard.ToString();
    }

    void OnMouseEnter(){
        EncounterControl.Instance.hoveredCard = this;
        gameObject.transform.position += new Vector3(0, 1, 0);
        rendr.sortingOrder = 100;
    }

    void OnMouseExit(){
        gameObject.transform.position -= new Vector3(0, 1, 0);
        rendr.sortingOrder = originalOrder;
        EncounterControl.Instance.hoveredCard = null;
    }



}
