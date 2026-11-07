using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] Toggle hapticsToggle;

    void Start()
    {
        hapticsToggle.isOn = Haptics.Enabled;
        hapticsToggle.onValueChanged.AddListener(SetHaptics);
    }

    void OnDestroy()
    {
        hapticsToggle.onValueChanged.RemoveListener(SetHaptics);
    }

    void SetHaptics(bool enabled)
    {
        Haptics.Enabled = enabled;
    }
}