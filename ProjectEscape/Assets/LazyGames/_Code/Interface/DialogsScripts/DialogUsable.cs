using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogUsable : MonoBehaviour, IUsable
{
    public bool CanInteract { get => CanInteract; set => CanInteract = value; }
    public float delay;
    [SerializeField] private GameObject dialogGO;
    [SerializeField] private DialogueTrigger DialogueToTrigger;
    IEnumerator ShowHintDialog()
    {
        yield return new WaitForSeconds(delay);
        dialogGO.SetActive(true);
        DialogueToTrigger.TriggerDialogue();


    }
    public void Use()
    {
        if (delay != 0)
        {
            StartCoroutine(ShowHintDialog());
        }
        else
        {
            dialogGO.SetActive(true);
            DialogueToTrigger.TriggerDialogue();
        }
    }
}
