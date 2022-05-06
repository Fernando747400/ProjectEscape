using System.Collections;
using System.Collections.Generic;
using Lean.Touch;
using UnityEngine;

public class FirstDialogue : MonoBehaviour
{
    [SerializeField] private GameObject dialogueSystemG0;
    [SerializeField] private DialogueTrigger IntroDialogue;
    IEnumerator ShowFirstDialogue()
    {
        yield return new WaitForSeconds(3f);
        dialogueSystemG0.SetActive(true);
       IntroDialogue.TriggerDialogue();
        
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowFirstDialogue());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
