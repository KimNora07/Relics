using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using static UnityEditor.Progress;
using TMPro;

public class GameManager : Singleton<GameManager>
{
    public float musicVolume;
    public float sfxVolume;
    public enum GAMESTATION : int{
        READY,
        PLAY = 20,
        STOP,
        OPTIONUI = 30,
        END
    }
    
    public GameObject talkPanel;
    public GameObject scanObject;
    public TMP_Text talkText;
    public Image portaritImg;
    public int talkIndex;
    public bool isAction;

    public GAMESTATION gameStation;

    void OnEnable(){
        musicVolume = 1.0f;
        sfxVolume = 1.0f;
    }

    public void Action(GameObject scanObj){
        scanObject = scanObj;
        talkText.text = scanObject.name;
    }
}
