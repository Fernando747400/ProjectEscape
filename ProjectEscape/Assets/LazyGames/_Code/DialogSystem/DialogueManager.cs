using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

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

    public Image currentImage;

    void Start()
    {
        
        sentences = new Queue<string>();
        Boxtext.SetActive(false);
        buttonContinue.SetActive(false);
        

    }
    
   
    public void StartDialogue(Dialogue dialogue)
    {
        textIsPlaying = true;

        currentImage.sprite = dialogue.Sprite;
        currentImage.gameObject.SetActive(true);
        
        if (inputCanvas != null)
        {
            inputCanvas.SetActive(false);
        }
        Boxtext.SetActive(true);
        buttonContinue.SetActive(true);

        
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
        Debug.Log("Display next sentence");
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
        
        currentImage.gameObject.SetActive(false);
        currentImage = null;
        
        if (PlayerController.current != null)
        {
            if(PlayerController.current.GetPlayerState(PlayerStates.NoInteracting))
            {
                inputCanvas.gameObject.SetActive(true);
            }
        }
        
    }

    private void OnDisable()
    {
        //GameManager.current.TurnOnDialogueSystem -= HandleDialogueState;
    }
}

