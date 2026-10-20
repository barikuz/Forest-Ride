using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    [SerializeField] private string coinID;
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        if (PlayerPrefs.GetInt(coinID, 0) == 1)
        {
            Destroy(gameObject); // Destroy the coin if it has already been collected
        }
    }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        int layerIndex = LayerMask.NameToLayer("Player");

        if(collision.gameObject.layer == layerIndex && spriteRenderer.enabled)
        {
            CollectCoin();
        }
        
    }

    void CollectCoin()
    {
        // 1.Save coin as collected in PlayerPrefs
        PlayerPrefs.SetInt(coinID, 1);
        PlayerPrefs.Save();

        // 2.Increase total coins and save to PlayerPrefs
        int totalCoins = PlayerPrefs.GetInt("TotalCoins", 0);
        totalCoins++;

        PlayerPrefs.SetInt("TotalCoins", totalCoins);
        PlayerPrefs.Save();

        TotalCoinsTextManager.Instance.UpdateCoinUI(); // Update the UI to reflect the new total coins
        
        // 3.Destroy the coin object
        spriteRenderer.enabled = false; // Hide the coin visually
    }
}
