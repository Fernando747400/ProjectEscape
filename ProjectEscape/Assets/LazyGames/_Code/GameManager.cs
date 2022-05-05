using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager current;
    public DialogueManager DialogueManager;

    public void Awake()
    {
        current = this;
        DontDestroyOnLoad(this.gameObject);
        Application.targetFrameRate = 30;
        DialogueManager.gameObject.transform.parent.gameObject.SetActive(false);
    }

    public event Action OpenShipDoor;
    public void openShipDoor() => OpenShipDoor?.Invoke();

    public event Action OpenSecondDoor;
    public void openSecondDooor() => OpenSecondDoor?.Invoke();


    public event Action FinishTutorial;
    public void finishTutorial() => FinishTutorial?.Invoke();


    public event Action ShowCardConsole;
    public void showCardConsole() => ShowCardConsole?.Invoke();

    public event Action SetPlayerState;
    public void setPlayerState() => SetPlayerState?.Invoke();

    public event Action ActivateInteracting;
    public void activateInteracting() => ActivateInteracting?.Invoke();

    public event Action TakeObject;
    public void takeObject() => TakeObject?.Invoke();

    public event Action PuzzleCrafteo;
    public void puzzleCrafteo() => PuzzleCrafteo?.Invoke();

    public event Action TurnOnDialogueSystem;
    public void turnOnDialogueSystem() => TurnOnDialogueSystem?.Invoke();
    
    


}
