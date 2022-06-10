using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameObject LaserOne;
    public GameObject LaserTwo;
    public GameObject LaserThree;

    public DialogueTrigger dialogue;
    [SerializeField] private GameObject dialogueSystemG0;


    bool hasCallLastDialog;

    private bool One, Two, Three;

    private void Start()
    {
        hasCallLastDialog = false;
    }
    private void Update()
    {
        One = LaserOne.GetComponent<Laser>().End;
        Two = LaserTwo.GetComponent<LaserTwo>().End;
        Three = LaserThree.GetComponent<Cube_Rotation>().End;

        if(One && Two && Three && !hasCallLastDialog)
        {
            Debug.Log("Se acabo el juego");
            StartCoroutine(CallLastDialog());
        }
    }

    IEnumerator CallLastDialog()
    {
        dialogueSystemG0.SetActive(true);
        dialogue.TriggerDialogue();
        hasCallLastDialog = true;
        yield return null;

    }

}
