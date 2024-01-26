using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class ChangesScreen : MonoBehaviour
{
    public GameObject OptionUI;
    public GameObject MainMenuUI;

    private void Start()
    {
        OptionUI.SetActive(false);
        MainMenuUI.SetActive(true);
    }
    public void GoOption()
    {
        MainMenuUI.SetActive(false);
        OptionUI.SetActive(true); 
    }
}
