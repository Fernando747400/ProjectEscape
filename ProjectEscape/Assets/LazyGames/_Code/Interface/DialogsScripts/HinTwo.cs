using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HinTwo : MonoBehaviour
{ 

     public bool CanInteract { get => CanInteract; set => CanInteract = value; }

    [SerializeField] private GameObject dialogGO;
    [SerializeField] private DialogueTrigger HintDialogue;
    public IEnumerator ShowHintDialog()
    {
        yield return new WaitForSeconds(1);

        HintDialogue.TriggerDialogue();

    }

    /*
    public void Use()
    {
        Debug.Log("<color=#FFD433>Se llama al dialog hint</color>");
        StartCoroutine(ShowHintDialog());
    }
    */


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        StartCoroutine(ShowHintDialog());
    }
}
