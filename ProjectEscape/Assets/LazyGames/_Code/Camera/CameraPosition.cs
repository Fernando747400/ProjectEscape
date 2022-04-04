using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    
    [SerializeField] private Camera playerCamera;
    [SerializeField] private Camera puzzleCamera;
    
    public void SwitchCameras()
    {
        if (playerCamera.isActiveAndEnabled)
        {
            playerCamera.gameObject.SetActive(false);
            puzzleCamera.gameObject.SetActive(true);
        } else
        {
            playerCamera.gameObject.SetActive(true);
            puzzleCamera.gameObject.SetActive(false);
        }
    }
}
