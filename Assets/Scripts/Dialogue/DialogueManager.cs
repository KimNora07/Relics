using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using KoreanTyper;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;

    public Image characterIcon;
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI dialogueArea;

    private List<DialogueLine> lines;
    private int currentIndex = 0;

    public bool isDialogueActive = false;
    public bool isTyping = false;
    public float typingSpeed = 0.05f;
    public Animator animator;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        lines = new List<DialogueLine>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        isDialogueActive = true;
        lines.Clear();
        lines.AddRange(dialogue.dialogueLines);
        currentIndex = 0;
        DisplayNextDialogue();
    }

    public void DisplayNextDialogue()
    {
        if(currentIndex >= lines.Count)
        {
            EndDialogue();
            return;
        }

        DialogueLine currentLine = lines[currentIndex];

        characterIcon.sprite = currentLine.character.icon;
        characterName.text = currentLine.character.name;

        StopAllCoroutines();
        StartCoroutine(TypeSentence(currentLine));
        currentIndex++;
    }

    public IEnumerator TypeSentence(DialogueLine dialogueLine)
    {
        isTyping = true;
        dialogueArea.text = "";

        int lineLength = dialogueLine.line.Length;

        for(int i = 0; i < lineLength; i++)
        {
            dialogueArea.text += dialogueLine.line[i];
            yield return new WaitForSeconds(typingSpeed);
        }
        isTyping = false;
    }

    private void EndDialogue()
    {
        isDialogueActive = false;
    }
}
