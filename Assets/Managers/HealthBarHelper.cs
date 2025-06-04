using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class HealthBarHelper : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TextMeshProUGUI text;
    public void OnPointerEnter(PointerEventData eventData)
    {
        text.enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        text.enabled = false;
    }

    public void Update(){
        text.text = (gameObject.name == "PlayerSlider")? (Demo.player.health + " / " + Demo.player.maxHealth):
                                                        (EncounterControl.Instance.currEnemy.health + " / " + EncounterControl.Instance.currEnemy.maxHealth);
    }
}
