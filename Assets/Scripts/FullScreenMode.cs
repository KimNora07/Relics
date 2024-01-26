using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullScreenMode : MonoBehaviour
{
    public Sprite[] NoCheckImg;
    private bool isClick = false;
    public void FullScreenModes()
    {
        isClick = !isClick;
        Screen.fullScreen = !Screen.fullScreen;
        if (isClick)
        {
            GameObject.Find("CheckBox").GetComponent<Image>().sprite = NoCheckImg[0];
        }
        else
        {
            GameObject.Find("CheckBox").GetComponent<Image>().sprite = NoCheckImg[1];
        }
    }
}
