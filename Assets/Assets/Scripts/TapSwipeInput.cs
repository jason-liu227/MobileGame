using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

public class TapSwipeInput : MonoBehaviour
{
    public float swipeDp = 50f;
    public float tapMax = 0.3f;

    private PlayerGravity player;

    void Awake()
    {
        player = FindFirstObjectByType<PlayerGravity>();

        if (player == null)
        {
            Debug.LogError("Could not find PlayerGravity!");
        }
    }

    void OnEnable()
    {
        EnhancedTouchSupport.Enable();
    }

    void OnDisable()
    {
        EnhancedTouchSupport.Disable();
    }

    void Update()
    {
        if (LifecycleGuard.IsPaused)
    return;
        foreach (var t in Touch.activeTouches)
        {
            if (t.phase != TouchPhase.Ended)
                continue;

            float px = swipeDp * Mathf.Max(Screen.dpi, 160f) / 160f;
            Vector2 d = t.screenPosition - t.startScreenPosition;

            if (d.magnitude >= px)
            {
                Debug.Log("Swipe " + d.normalized);
            }
            else if (t.time - t.startTime < tapMax)
            {
                Debug.Log("Tap");

                if (player != null)
                {
                    player.FlipGravity();
                }
            }
        }
    }
}
