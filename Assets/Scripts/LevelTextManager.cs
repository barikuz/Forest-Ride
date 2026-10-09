using System.Collections;
using UnityEngine;

public class LevelTextManager : MonoBehaviour
{
    [Header("Bileşenler")]
    [SerializeField] private CanvasGroup canvasGroup;

    [Header("Zamanlama Ayarları")]
    [SerializeField] private float visibleDuration = 3f; // Ekranda tam opak kalacağı süre (saniye)
    [SerializeField] private float fadeDuration = 0.75f;   // Yavaşça kaybolma süresi (saniye)

    private void Start()
    {
        // Eğer Canvas Group atanmadıysa otomatik almaya çalışır
        if (canvasGroup == null)
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }

        // Efekti başlat
        StartCoroutine(FadeOutRoutine());
    }

    private IEnumerator FadeOutRoutine()
    {
        yield return new WaitForSeconds(visibleDuration);

        // 2. Yavaşça alpha değerini 1'den 0'a düşür
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            yield return null; // Bir sonraki kareye geç
        }

        canvasGroup.alpha = 0f;

    }

}

