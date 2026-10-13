using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenuCanvas;
    [SerializeField] GameObject charecterSelectCanvas;
    [SerializeField] GameObject levelSelectLayout;
    [SerializeField] GameObject mainLayout;

    private bool isPaused = false;
    

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        CloseLevelSelect();
        pauseMenuCanvas.SetActive(false);
        if(charecterSelectCanvas.activeSelf == false)
        {
            Time.timeScale = 1f;
        } 
        isPaused = false;
    }

    public void Pause()
    {
        pauseMenuCanvas.SetActive(true);
        Time.timeScale = 0f; // Oyunu tamamen durdur
        isPaused = true;
    }
    
    public void Restart()
    { 
        // Oyunu tekrar başlat
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex );    
    }

    public void OpenLevelSelect()
    {
        levelSelectLayout.SetActive(true);
        mainLayout.SetActive(false); 
    }
    
    public void CloseLevelSelect()
    {
        levelSelectLayout.SetActive(false);
        mainLayout.SetActive(true); 
    }
}
