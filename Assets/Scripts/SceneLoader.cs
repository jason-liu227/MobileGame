using System;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Stopwatch = System.Diagnostics.Stopwatch;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance { get; private set; }

    [SerializeField] private Slider bar;
    [SerializeField] private GameObject loadingScreen;

    private bool isLoading;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        loadingScreen.SetActive(false);
    }

    public async Awaitable Load(string scene, CancellationToken ct)
    {
        if (isLoading)
            return;

        Stopwatch sw = Stopwatch.StartNew();
        isLoading = true;
        loadingScreen.SetActive(true);
        bar.value = 0f;

        try
        {
            AsyncOperation op = SceneManager.LoadSceneAsync(scene);

            if (op == null)
            {
                Debug.LogError($"Could not load scene: {scene}");
                return;
            }

            op.allowSceneActivation = false;

            // Progress stops at 0.9 while activation is disabled.
            while (op.progress < 0.9f)
            {
                bar.value = op.progress / 0.9f;
                await Awaitable.NextFrameAsync(ct);
            }

            bar.value = 1f;

            // Important: activate BEFORE awaiting completion.
            op.allowSceneActivation = true;
            await op;

            sw.Stop();
            UnityEngine.Debug.Log(
                $"[perf] scene {scene} loaded in {sw.ElapsedMilliseconds} ms"
            );
        }
        catch (OperationCanceledException)
        {
            Debug.Log("Scene loading cancelled.");
        }
        finally
        {
            loadingScreen.SetActive(false);
            isLoading = false;
        }
    }
}
