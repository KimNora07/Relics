using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickScript : MonoBehaviour
{
    public float ClickdelayInSeconds = 3.0f;
    public Button myButton;

    private void Start()
    {
        StartCoroutine(EnableClickAfterDelay());
        DisableButton();
    }

    private void OnEnable()
    {
        StartCoroutine(EnableClickAfterDelay());
        DisableButton();
    }

    public void DisableButton()
    {
        myButton.enabled = false;
    }

    public void EnableButton()
    {
        myButton.enabled = true;
    }
    private IEnumerator EnableClickAfterDelay()
    {
        yield return new WaitForSeconds(ClickdelayInSeconds);
        EnableButton();
    }
}
