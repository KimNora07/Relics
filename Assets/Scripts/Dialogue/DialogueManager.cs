using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;

    public Image characterIcon;
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI dialogueArea;

    private Queue<DialogueLine> lines;

    public bool isDialogueActive = false;
    public bool isTyping = false;
    public float typingSpeed = 0.2f;
    public Animator animator;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        lines = new Queue<DialogueLine>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        isDialogueActive = true;
        lines.Clear();
        foreach(DialogueLine dialogueLine in dialogue.dialogueLines)
        {
            lines.Enqueue(dialogueLine);
        }
        DisplayNextDialogue();
    }

    public void DisplayNextDialogue()
    {
        if(lines.Count == 0)
        {
            EndDialogue();
            return;
        }

        DialogueLine currentLine = lines.Dequeue();

        characterIcon.sprite = currentLine.character.icon;
        characterName.text = currentLine.character.name;

        StopAllCoroutines();
        StartCoroutine(TypeSentence(currentLine));
    }

    public IEnumerator TypeSentence(DialogueLine dialogueLine)
    {
        isTyping = true;
        dialogueArea.text = "";
        foreach(var line in dialogueLine.line.ToCharArray())
        {
            dialogueArea.text += line;
            yield return new WaitForSeconds(typingSpeed);
        }
         isTyping = false;
    }

    private void EndDialogue()
    {
        isDialogueActive = false;
    }
}
