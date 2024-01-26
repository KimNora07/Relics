using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Progress;

public class TestSceneChanger : MonoBehaviour
{
    public GameObject OptionUI;
    public GameObject MainMenuUI;

    private void Start()
    {
        OptionUI.SetActive(true);
        MainMenuUI.SetActive(false);
    }
    public void GoMain()
    {
        OptionUI.SetActive(false);
        MainMenuUI.SetActive(true);
    }
}
