using UnityEngine;
using TMPro;

public class TotalCoinsTextManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI totalCoinsText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int totalCoins = PlayerPrefs.GetInt("TotalCoins", 0);
        if (totalCoinsText != null)
        {
            totalCoinsText.text = "Coins: " + totalCoins.ToString();
        }
    }

}
