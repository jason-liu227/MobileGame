using UnityEngine;
using TMPro;

public class FPSOverlay : MonoBehaviour
{
    [SerializeField] private TMP_Text fpsText;

    private float elapsed;
    private int frames;

    void Update()
    {
        elapsed += Time.unscaledDeltaTime;
        frames++;

        if (elapsed >= 0.5f)
        {
            float fps = frames / elapsed;
            float frameTime = 1000f / fps;

            string mode = PlayerPrefs.GetInt("perf_mode", 0) == 1
                ? "High FPS"
                : "Balanced";

            if (fpsText != null)
            {
                fpsText.text =
                    $"Mode: {mode}\n" +
                    $"FPS: {fps:0.0}\n" +
                    $"Frame: {frameTime:0.00} ms";
            }

            elapsed = 0f;
            frames = 0;
        }
    }
}

