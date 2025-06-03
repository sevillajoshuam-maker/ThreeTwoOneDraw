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
        text.text = (gameObject.name == "PlayerSlider")? (Player.health + " / " + Player.maxHealth):
                                                        (EncounterControl.Instance.currEncounter.enemy.health + " / " + EncounterControl.Instance.currEncounter.enemy.maxHealth);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        text.enabled = false;
    }
}
