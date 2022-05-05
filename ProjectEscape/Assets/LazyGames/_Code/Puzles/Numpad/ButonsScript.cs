using UnityEngine;
using UnityEngine.Events;

public class ButonsScript : MonoBehaviour
{
    public int numpadNumber;

    public UnityEvent KeypadCliked;

    public void ClickButton()
    {
        KeypadCliked.Invoke();
    }
}
