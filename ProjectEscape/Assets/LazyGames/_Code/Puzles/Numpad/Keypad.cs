using UnityEngine;
using TMPro;
using System.Collections;

public class Keypad : MonoBehaviour
{
    public string pasword = "";
    private string UserInput = "";
    public TextMeshPro ShowInput;
    private bool DontRepeat = false;
    public int cameraPlaceArray = 3;

    public string stinger;

    private void Start()
    {
        ShowInput.text = "";
        UserInput = "";
        ShowInput.text = "";
    }

    public void ButtonCliked(string number)
    {
        if(UserInput.Length <= 4)
        {
            UserInput += number;
            Debug.Log(UserInput);
            ShowInput.text = UserInput;
        }
        else if(UserInput.Length > 4)
        {
            CheckPasword();
        }
    }

    public void ClearAll()
    {
        UserInput = "";
        ShowInput.text = "";
    }

    public void CheckPasword()
    {
        if(UserInput == pasword && DontRepeat == false)
        {
            ShowInput.text = "great";
            if (stinger != null || stinger != "") PlaySound(stinger);
            StartCoroutine(WaitOpenDoor());
            DontRepeat = true;
        }
        if(UserInput != pasword)
        {
            ShowInput.text = " bad ";
            UserInput = "";
        }
    }

    
    IEnumerator WaitOpenDoor()
    {
        PlayerController.current.DeactivateInteracting();
        CameraHandler.current.SelectCamera(cameraPlaceArray);
        PlayerController.current.SetPlayerInCinematic();
        yield return new WaitForSeconds(1);
        GameManager.current.openThirdDooor();
        yield return new WaitForSeconds(5);
        CameraHandler.current.SwitchToPlayerCamera();
        PlayerController.current.UnSetPlayerCinematic();

       
    }

    public void PlaySound(string _sound)
    {
        AudioManager.instance.Play(_sound);
    }

}
