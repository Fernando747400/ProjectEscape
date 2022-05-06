using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager current;
    public GameObject inputCanvas;
    public GameObject buttonContinue;
    
    public GameObject dialogueSystemGO;
    public bool textIsPlaying;
    public TextMeshProUGUI nameCharacter;
    public TextMeshProUGUI dialoguueText;
    private Queue<string> sentences;
    public GameObject Boxtext;

    void Start()
    {
       // GameManager.current.TurnOnDialogueSystem += HandleDialogueState;
        
        sentences = new Queue<string>();
        Boxtext.SetActive(false);
        buttonContinue.SetActive(false);

    }
    

    void HandleDialogueState()
    {
        if (!dialogueSystemGO.activeSelf)
        {
            dialogueSystemGO.SetActive(true);
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
       // HandleDialogueState();
        textIsPlaying = true;
        inputCanvas.SetActive(false);
        Boxtext.SetActive(true);
        buttonContinue.SetActive(true);



        Debug.Log("Starting conversation with: " + dialogue.character);

        nameCharacter.text = dialogue.character;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentences(sentence));
    }

    IEnumerator TypeSentences(string sentence)
    {
        
        dialoguueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialoguueText.text += letter;
            yield return null;
        }
        
    }

    void EndDialogue()
    {
        Boxtext.SetActive(false);
        buttonContinue.SetActive(false);
        textIsPlaying = false;
        inputCanvas.gameObject.SetActive(true);
       // dialogueSystemGO.SetActive(false);

    }

    private void OnDisable()
    {
        //GameManager.current.TurnOnDialogueSystem -= HandleDialogueState;
    }
}
