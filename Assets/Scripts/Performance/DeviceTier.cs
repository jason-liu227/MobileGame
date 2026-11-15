using UnityEngine;
using TMPro;

public class DeviceTier : MonoBehaviour
{
    const int Low = 0, Mid = 1, High = 2;

    [SerializeField] private TMP_Dropdown tierDropdown;

    void Start()
    {
        InitializeTierDropdown(tierDropdown);
    }

    void Awake()
    {
        int tier = PlayerPrefs.GetInt("tier_override", Detect());

        QualitySettings.SetQualityLevel(tier, true);
        Application.targetFrameRate = tier == Low ? 30 : 60;

        Debug.Log($"tier={QualitySettings.names[tier]}");
    }

    static int Detect()
    {
        int ram = SystemInfo.systemMemorySize;
        int cores = SystemInfo.processorCount;

        if (ram >= 8192 && cores >= 8)
            return High;

        if (ram >= 4096 && cores >= 6)
            return Mid;

        return Low;
    }

    public void SetTierOverride(int option)
    {
        Debug.Log("Dropdown selected index = " + option);
        // 0 = Auto, 1 = Low, 2 = Mid, 3 = High
        if (option == 0)
            PlayerPrefs.DeleteKey("tier_override");
        else
            PlayerPrefs.SetInt("tier_override", option - 1);

        PlayerPrefs.Save();
        Debug.Log("Saved tier_override = " +
        PlayerPrefs.GetInt("tier_override", -1));

        Debug.Log("Tier override saved. Restart game to apply.");
    }

    public void SetTierFromDropdown(TMP_Dropdown dropdown)
    {
        SetTierOverride(dropdown.value);
    }

    public int GetSavedTierDropdownValue()
    {
        return PlayerPrefs.GetInt("tier_override", -1) + 1;
    }

    public void InitializeTierDropdown(TMP_Dropdown dropdown)
    {
        if (dropdown == null) return;

        dropdown.SetValueWithoutNotify(GetSavedTierDropdownValue());
        dropdown.RefreshShownValue();
    }
}
