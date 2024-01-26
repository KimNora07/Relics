using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FadeScript : MonoBehaviour
{
    public TMP_Text tex;
    Color col;
    public float FadedelayInSeconds = 1.0f; // ���ϴ� ��� �ð� (��)

    void Start()
    {
        col = tex.color;
        col.a = 0;
        tex.color = col;
    }

    private void OnEnable()
    {
        col = tex.color;
        col.a = 0;
        tex.color = col;
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
            tex.color = col;
        }
    }
}
