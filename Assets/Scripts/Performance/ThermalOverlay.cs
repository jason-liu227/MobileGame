using UnityEngine;
using UnityEngine.AdaptivePerformance;
using TMPro;

public class ThermalOverlay : MonoBehaviour
{
    [SerializeField] private TMP_Text label;

    private IAdaptivePerformance ap;

    void Start()
    {
        ap = Holder.Instance;
    }

    void Update()
    {
        if (label == null)
            return;

        float frameMs = Time.unscaledDeltaTime * 1000f;

        if (ap == null || !ap.Active)
        {
            label.text = $"{frameMs:0.0} ms (AP inactive)";
            return;
        }

        ThermalMetrics m = ap.ThermalStatus.ThermalMetrics;

        label.text =
            $"{frameMs:0.0} ms {m.WarningLevel}\n" +
            $"temp {m.TemperatureLevel:0.00} " +
            $"trend {m.TemperatureTrend:0.00}";
    }
}
