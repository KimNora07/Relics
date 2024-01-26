using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    public float SliderdelayInSeconds = 3.0f;
    public GameObject mySlider;

    private void Start()
    {
        StartCoroutine(EnableClickAfterDelay());
        DisableSlider();
    }

    private void OnEnable()
    {
        StartCoroutine(EnableClickAfterDelay());
        DisableSlider();
    }

    public void DisableSlider()
    {
        mySlider.SetActive(false);
    }

    public void EnableButton()
    {
        mySlider.SetActive(true);
    }
    private IEnumerator EnableClickAfterDelay()
    {
        yield return new WaitForSeconds(SliderdelayInSeconds);
        EnableButton();
    }
}
