using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogUsable : MonoBehaviour, IUsable
{
    public bool CanInteract { get => CanInteract; set => CanInteract = value; }
    [SerializeField] private GameObject dialogGO;
    [SerializeField] private DialogueTrigger DialogueToTrigger;
    IEnumerator ShowHintDialog()
    {
        yield return new WaitForSeconds(1);
        dialogGO.SetActive(true);
        DialogueToTrigger.TriggerDialogue();

    }
    public void Use()
    {
       
        StartCoroutine(ShowHintDialog());
    }
}
