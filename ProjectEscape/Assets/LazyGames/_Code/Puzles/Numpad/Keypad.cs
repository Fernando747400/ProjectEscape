using UnityEngine;
using TMPro;

public class Keypad : MonoBehaviour
{
    public string pasword = "";
    private string UserInput = "";
    public TextMeshPro ShowInput;

    private void Start()
    {
        ShowInput.text = "";
        UserInput = "";
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
        if(UserInput == pasword)
        {
            ShowInput.text = "great";
        }
        if(UserInput != pasword)
        {
            ShowInput.text = " bad ";
            UserInput = "";
        }
    }
}
