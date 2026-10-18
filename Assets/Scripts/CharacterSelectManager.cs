using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectManager : MonoBehaviour
{
    [SerializeField] GameObject scoreCanvas;
    [SerializeField] GameObject yellowBike;
    [SerializeField] GameObject redBike;

    [SerializeField] private Button redBikeButton;

    [SerializeField] private int requiredCoins = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 0f;
        CheckBikeUnlockStatus();
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

    private void CheckBikeUnlockStatus()
    {
        
        int totalCoins = PlayerPrefs.GetInt("TotalCoins", 0);

        if (totalCoins >= requiredCoins)
        {
            redBikeButton.interactable = true;
        }
        else
        {
            redBikeButton.interactable = false;
        }
    }
}
