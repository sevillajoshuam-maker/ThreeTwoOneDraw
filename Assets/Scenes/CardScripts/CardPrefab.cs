using UnityEngine;

public class CardPrefab : MonoBehaviour 
{
    public AbstractCard thisCard;
    public SpriteRenderer rendr;

    public void setData(AbstractCard card){
        thisCard = card;
        rendr = gameObject.GetComponent<SpriteRenderer>();
        rendr.sprite = ImageLibrary.take_aim_concept_art;
    }

    public override string ToString(){
        return thisCard.ToString();
    }


}
