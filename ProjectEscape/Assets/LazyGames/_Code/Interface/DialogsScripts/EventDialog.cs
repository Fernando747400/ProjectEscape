using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDialog : MonoBehaviour
{
    public DialogueTrigger[] dialogs;
    public DialogueTrigger currentDialog;
    [SerializeField] private GameObject dialogueSystemG0;

    private void Start()
    {
        dialogueSystemG0.SetActive(true);
        StartDialogues();
    }

    public void StartDialogues()
    {
        dialogs[0].TriggerDialogue();
        currentDialog = dialogs[0];

        // foreach (DialogueTrigger dialogueTrigger in dialogs)
        // {
        //     currentDialog = dialogueTrigger;
        //     dialogueTrigger.TriggerDialogue();
        // }



    }
    public void CallNextDialog()
    {
        
    }

    private void Update()
    {
        
    }
}
