using UnityEngine;
using UnityEngine.UI;

public class PerformanceToggleUI : MonoBehaviour
{
    [SerializeField] private Toggle highFpsToggle;

    private void OnEnable()
    {
        if (highFpsToggle == null)
            return;

        bool high = PlayerPrefs.GetInt("perf_mode", 0) == 1;

        highFpsToggle.SetIsOnWithoutNotify(high);
    }

    public void OnHighFpsChanged(bool on)
    {
        PerformanceMode performanceMode =
            FindFirstObjectByType<PerformanceMode>();

        if (performanceMode != null)
        {
            performanceMode.SetHighFps(on);
        }
        else
        {
            Debug.LogWarning("[Perf] PerformanceMode not found");
        }
    }
}

