using UnityEngine;

public class CardPrefab : MonoBehaviour 
{
    public AbstractCard thisCard;
    public SpriteRenderer rendr;

    public void setData(AbstractCard card){
        thisCard = card;

        rendr = gameObject.GetComponent<SpriteRenderer>();
    }

    public override string ToString(){
        return thisCard.ToString();
    }


}
