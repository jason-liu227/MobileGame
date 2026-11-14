using UnityEngine;

public class AboutPanelController : MonoBehaviour
{
    [SerializeField] private GameObject aboutButton;
    [SerializeField] private GameObject aboutPanel;

    public void OpenAbout()
    {
        aboutButton.SetActive(false);
        aboutPanel.SetActive(true);
    }

    public void CloseAbout()
    {
        aboutPanel.SetActive(false);
        aboutButton.SetActive(true);
    }

    private void Update()
    {
        if (aboutPanel != null &&
            aboutPanel.activeSelf &&
            Input.GetKeyDown(KeyCode.Escape))
        {
            CloseAbout();
        }
    }
}
