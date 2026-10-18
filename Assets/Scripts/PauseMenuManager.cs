using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenuCanvas;
    [SerializeField] GameObject charecterSelectCanvas;
    [SerializeField] GameObject scoreCanvas;

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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        if(SceneManager.GetActiveScene().buildIndex > 0)
        {
            Time.timeScale = 1f;
        }    
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

    public void passLevel1(){
        SceneManager.LoadScene(0);
        Time.timeScale = 1f; 
    }

    public void passLevel2(){
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

    public void openBikeSelect(){
        scoreCanvas.SetActive(false);
        charecterSelectCanvas.SetActive(true);
        pauseMenuCanvas.SetActive(false);
    }
}
