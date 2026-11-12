using UnityEngine;

public class MenuReady : MonoBehaviour
{
    private bool logged;

    private void Update()
    {
        if (logged)
            return;

        logged = true;

        Debug.Log(
            $"[perf] interactive {Time.realtimeSinceStartup:F2}s"
        );

        enabled = false;
    }
}
