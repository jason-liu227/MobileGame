using UnityEngine;

public class FeedbackButton : MonoBehaviour
{
    [SerializeField]
    private string feedbackUrl = "";

    public void OpenFeedback()
    {
        if (string.IsNullOrWhiteSpace(feedbackUrl))
        {
            Debug.LogWarning("Feedback URL is not set.");
            return;
        }

        Application.OpenURL(feedbackUrl);
    }
}

