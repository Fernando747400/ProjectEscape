using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintTwo: MonoBehaviour, IUsable
{
    public bool CanInteract { get => CanInteract; set => CanInteract = value; }
    [SerializeField] private GameObject dialogGO;
    [SerializeField] private DialogueTrigger HintDialogue;
    IEnumerator ShowHintDialog()
    {
        yield return new WaitForSeconds(1);
        dialogGO.SetActive(true);
        HintDialogue.TriggerDialogue();

    }
    public void Use()
    {
       
        StartCoroutine(ShowHintDialog());
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
           
    }
}
