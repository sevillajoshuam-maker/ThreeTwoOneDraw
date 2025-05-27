using UnityEngine;

public class CardPrefab : MonoBehaviour 
{
    public AbstractCard thisCard;
    public SpriteRenderer rendr;

    private int originalOrder;


    public void setData(AbstractCard card){

        thisCard = card;
        rendr = gameObject.GetComponent<SpriteRenderer>();
        rendr.size += new Vector2(10f, 10f);

        originalOrder = rendr.sortingOrder;
        rendr.sprite = thisCard.IMAGE;
    }

    public override string ToString(){
        return thisCard.ToString();
    }

    void OnMouseEnter(){
        gameObject.transform.position += new Vector3(0, 2, 0);
        rendr.sortingOrder = 10;
    }

    void OnMouseExit(){
        gameObject.transform.position -= new Vector3(0, 2, 0);
        rendr.sortingOrder = originalOrder;
    }


}
