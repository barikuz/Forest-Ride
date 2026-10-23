using UnityEngine;

public class MobileUIHandler : MonoBehaviour
{
    [Header("Test Option for Editor")]
    [SerializeField] private bool showInEditor = true;

    void Awake()
    {
        // If the application is running on a mobile platform or if it's in the editor and showInEditor is true, 
        if (Application.isMobilePlatform || (Application.isEditor && showInEditor))
        {
            gameObject.SetActive(true); // keep the canvas active. 
        }
        else
        {
            gameObject.SetActive(false); // Otherwise, deactivate it for PC builds.
        }
    }
}