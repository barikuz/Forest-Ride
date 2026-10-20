using UnityEngine;
using TMPro;

public class TotalCoinsTextManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI totalCoinsText;
    
    public static TotalCoinsTextManager Instance;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateCoinUI();
    }

    public void UpdateCoinUI()
    {
        int totalCoins = PlayerPrefs.GetInt("TotalCoins", 0);
        if (totalCoinsText != null)
        {
            totalCoinsText.text = "Coins: " + totalCoins.ToString();
        }
    }

}
