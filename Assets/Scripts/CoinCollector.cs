using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    [SerializeField] private string coinID;
    SpriteRenderer spriteRenderer;
    int totalCoins;

    void Awake()
    {
        if (PlayerPrefs.GetInt(coinID, 0) == 1)
        {
            Destroy(gameObject); // Destroy the coin if it has already been collected
        }

        totalCoins = PlayerPrefs.GetInt("TotalCoins", 0); // Load total coins from PlayerPrefs
    }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        int layerIndex = LayerMask.NameToLayer("Player");

        if(collision.gameObject.layer == layerIndex)
        {
            CollectCoin(collision);
        }
        
    }

    void CollectCoin(Collider2D collision)
    {
        // 1.Save coin as collected in PlayerPrefs
        PlayerPrefs.SetInt(coinID, 1);
        PlayerPrefs.Save();

        // 2.Increase total coins and save to PlayerPrefs
        totalCoins++;
        PlayerPrefs.SetInt("TotalCoins", totalCoins);
        PlayerPrefs.Save();

        // 3.Destroy the coin object
        Destroy(gameObject);
    }
}
