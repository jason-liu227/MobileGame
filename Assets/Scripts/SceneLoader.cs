using System;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
