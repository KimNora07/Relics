using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackGroundFadeScript : MonoBehaviour
{
    public Image Img;
    Color col;
    public float FadedelayInSeconds = 0.0f;


    void Start()
    {
        col = Img.color;
        col.a = 0;
        Img.color = col;
    }

    private void OnEnable()
    {
        col = Img.color;
        col.a = 0;
        Img.color = col;
    }

    void Update()
    {
        Invoke("MyDelayedFunction", FadedelayInSeconds);
    }

    private void MyDelayedFunction()
    {
        if (col.a < 256)
        {
            col.a += Time.deltaTime;
            Img.color = col;
        }
    }
}
