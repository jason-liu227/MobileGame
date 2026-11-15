| Field | Row 1 — Week 7 baseline | Row 2 — Week 8 release | Row 3 — Week 9 Lab A |
|---|---|---|---|
| Date, versionName / versionCode, Release or Dev, Unity version | 09/11/2026 · Version: 0.7.1 · Android Release · Unity 6.6 | 15/11/2026 · Version: 0.8.0 · Android Release · Unity 6.6 · Build ID: cb6ecb43 · versionCode: 8 | 15/11/2026 · Android Development Build with Profiler · Unity 6.6 · Version 0.8.1, 93959de9 |
| Device model, Android version, SoC / GPU, graphics API, refresh rate | Samsung Galaxy S25 FE · Android 16 · Exynos 2400 · Xclipse 940 · Vulkan · 60 Hz Balanced, 120 Hz maximum | Samsung Galaxy S25 FE · Android 16 · Exynos 2400 · Xclipse 940 · Vulkan · 60 Hz Balanced, 120 Hz maximum | Samsung Galaxy S25 FE · Android 16 · Exynos 2400 · Xclipse 940 · Vulkan · Refresh rate not separately verified |
| Target fps | 60 FPS | 60 FPS | 60 FPS · Auto-selected Mid tier |
| Menu: avg ms / p99 ms | 16.67 ms / 16.78 ms | Not measured | Not measured |
| Steady gameplay: avg ms / p99 ms | 16.67 ms / 16.81 ms | Not measured | 16.68 ms mean / 16.88 ms highest reported window p99 |
| Worst case: avg ms / p99 ms | 16.69 ms / 16.89 ms | Not measured | Not separately measured |
| GC allocated per frame (bytes), allocating markers | 99 B (selected frame); `GC.Alloc` under `Inl_Record Render Graph` (48 B); remaining 51 B not identified | Not measured | 455–479 B in selected Profiler frames; allocating markers not fully investigated |
| Peak Total Reserved (MB) / TOTAL PSS (MB) | Not available; peak Total Allocated ≈ 625 MB / Total PSS = 374.3 MiB | Peak Total Reserved: Not measured / Total PSS: 337.7 MiB (345,835 KB) | Peak Total Reserved: Not measured / Total PSS: 388.6 MiB (397,908 KB), Profiler disconnected; initial measurement with Profiler connected: 469.9 MiB |
| Worst case: SetPass / batches / triangles | 6 / 5 / 45 | Not measured | Selected frames: 6 SetPass / 365–387 batches / 707–735 triangles; worst-case frame not independently established |
| Cold start ms (median of 3), first interactive s | 484 ms median (588, 477, 484 ms; all COLD) · 2.33 s median to interactive | 374 ms (1 cold-start run, not median) · First interactive: Not measured | Not remeasured |
| APK size (MB) | 57.44 MiB (60,229,720 bytes; Mobilegame-0.3.0-arm64.apk) | Not measured | Not measured |
| Thermal delta, throttling (Week 7) | −2.5°C, No throttling observed | Not measured | Not measured |
| Load time (Week 5) | MenuScene: 170, 170, 151 ms (median 170 ms) · GameScene: 137, 116 ms · ResultScene: 76 ms | Not measured | Not measured |
| Home-and-return startup (additional Week 8 metric) | Not measured | 45 ms (LaunchState: HOT; 1 run) | Not remeasured |

**Week 9 measurement notes:**

- Frame-time results came from 22 `[Baseline]` reporting windows over approximately 3 minutes 30 seconds. The 16.88 ms value is the highest reported window p99, not a percentile recalculated across the complete recording.
- The 365–387 batch range and 707–735 triangle range came from selected Unity Profiler frames, not a full-session worst-case analysis.
- The separate draw-call count was not independently confirmed.
- The non-profiled Week 9 PSS measurement was approximately 11.4 MiB below the provisional 400 MiB budget.
- Week 3 `bottleneck-01.md` records 5 SetPass calls, whereas the earlier baseline sheet records 6. These values may refer to different captures and have not been reconciled.