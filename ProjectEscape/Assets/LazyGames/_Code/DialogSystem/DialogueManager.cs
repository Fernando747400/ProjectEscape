using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameCharacter;
    public TextMeshProUGUI dialoguueText;
    private Queue<string> sentences;
    public GameObject Boxtext;

    void Start()
    {
        sentences = new Queue<string>();
        Boxtext.SetActive(false);
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Boxtext.SetActive(true);
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
    }
}
