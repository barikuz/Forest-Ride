using UnityEngine;

public class CharacterSelectManager : MonoBehaviour
{
    [SerializeField] GameObject scoreCanvas;
    [SerializeField] GameObject yellowBike;
    [SerializeField] GameObject redBike;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 0f;
    }

    void BeginGame()
    {
        Time.timeScale = 1f;
        scoreCanvas.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ChooseYellow()
    {
        yellowBike.SetActive(true);
        redBike.SetActive(false);
        BeginGame();
    }

    public void ChooseRed()
    {
        redBike.SetActive(true);
        yellowBike.SetActive(false);
        BeginGame();
    }
}
