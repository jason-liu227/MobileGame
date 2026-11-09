# CA2 Week 3 — Bottleneck 01

## What

The gravity-reversal endless runner's primary performance bottleneck has not yet been confirmed by the available Android profiling measurements.

## Where

The tallest CPU Profiler marker in the selected worst frame was `PlayerLoop`. The largest recorded Self ms entry was `WaitForTargetFPS` (11.44 ms), which is frame pacing/waiting rather than active gameplay work. In the Unity Frame Debugger, `Canvas.RenderOverlays` contains two `Draw Mesh` events using the `UI/Default` shader; this is a draw-count observation, **not** proof of a GPU bottleneck.

## Numbers

| Measurement | Result |
|---|---|
| Previously observed CPU Usage frame time | **16.55 ms** (not confirmed as worst frame) |
| Worst-frame main-thread time | **17.05 ms** |
| Tallest marker | `PlayerLoop` (parent marker) |
| Top three CPU markers by Self ms | `WaitForTargetFPS`: **11.44 ms**; `PrepareSceneNodes`: **0.08 ms**; `PostLateUpdate.FinishFrameRendering`: **0.07 ms** |
| SetPass Calls | **5** |
| GC Allocated in Frame | **99B** |
| `GC.Collect` observed | **No** |
| Full render scale (1.0) frame time | **16.60 ms** |
| Half render scale (0.5) frame time | **16.99 ms** |
| Full-scale `Gfx.WaitForPresentOnGfxThread` | **6.64 ms** |
| Half-scale `Gfx.WaitForPresentOnGfxThread` | **0.09 ms** |

Frame Debugger observations: five rendering events were shown; `Canvas.RenderOverlays` contains two UI mesh draws; the selected event was `Event #4 Draw Mesh`, using `UI/Default`, with a 2340 × 1080 render target. The capture target (AndroidPlayer versus Editor) has **not yet been confirmed**. Frame Debugger does not provide per-pass GPU execution timings.

## Verdict

**Inconclusive — CPU-bound versus GPU-bound cannot yet be determined.** The selected worst frame took 17.05 ms on the main thread, slightly above the 16.67 ms budget for 60 FPS. `WaitForTargetFPS` accounted for about 67.1% of that time (11.44 ms), indicating substantial frame-pacing wait rather than a demonstrated active CPU bottleneck. `GC.Collect` did not occur in this frame. These findings do not establish which subsystem is limiting performance. Compare equivalent gameplay windows at render scales 1.0 and 0.5, including frame time and graphics-wait markers, before making a CPU/GPU verdict. A frame-rate cap or `WaitForTargetFPS` can mask improvements.

## Fix to try

Trial a URP render scale of 0.75 and compare frame times under the same obstacle load; retain the change only if GPU performance improves without unacceptable visual loss.

**Evidence**

- [Worst-frame screenshot](w03-bad-frame.png)
- [Frame Debugger screenshot](w03-gpu-pass.png)
- [Unity Profiler capture](w03-profile.data)
