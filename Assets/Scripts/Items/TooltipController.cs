using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Tooltip tooltip;
    public void OnPointerEnter(PointerEventData eventData)
    {
        ItemData itemData = GetComponent<ItemData>();

        if(itemData != null)
        {
            tooltip.gameObject.SetActive(true);
            tooltip.SetupTooltip(itemData.name, itemData.description, itemData.atk);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.gameObject.SetActive(false);
    }

}
