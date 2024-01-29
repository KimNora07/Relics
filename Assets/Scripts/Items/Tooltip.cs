using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI atkText;
    public TextMeshProUGUI atkValueText;

    RectTransform rect;

    float halfwidth;

    public void SetupTooltip(string name, string des, int atk)
    {
        nameText.text = name;
        descriptionText.text = des;
        
        if(atk == 0)
        {
            atkText.gameObject.SetActive(false);
            atkValueText.gameObject.SetActive(false);
        }
        else
        {
            atkText.gameObject.SetActive(true);
            atkValueText.gameObject.SetActive(true);
            atkValueText.text = atk.ToString();
        }
    }

    private void Start()
    {
        halfwidth = GetComponentInParent<CanvasScaler>().referenceResolution.x * 0.5f;
        rect = GetComponent<RectTransform>();
    }

    private void Update()
    {
        transform.position = Input.mousePosition;

        if(rect.anchoredPosition.x + rect.sizeDelta.x > halfwidth)
        {
            rect.pivot = new Vector2(1, 1);
        }
        else
        {
            rect.pivot = new Vector2(0, 1);
        }
    }
}
