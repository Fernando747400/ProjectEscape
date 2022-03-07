using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum TutorialAction { MousePress, MouseDrag, MousePosition}

public abstract class TutorialInputManager : MonoBehaviour
{
    public PlayerInput playerInput;

    protected virtual void Awake()
    {
        //playerInput.SwitchCurrentActionMap("TutorialInput");

        playerInput.actions[TutorialAction.MousePress.ToString()].performed += MousePress;
        playerInput.actions[TutorialAction.MouseDrag.ToString()].performed += MouseDrag;
        playerInput.actions[TutorialAction.MousePosition.ToString()].performed += MousePosition;
    }

    private void OnDisable()
    {
        playerInput?.SwitchCurrentActionMap(playerInput.defaultActionMap);
    }

    protected abstract void MousePress(InputAction.CallbackContext value);
    protected abstract void MouseDrag(InputAction.CallbackContext value);
    protected abstract void MousePosition(InputAction.CallbackContext value);
}
