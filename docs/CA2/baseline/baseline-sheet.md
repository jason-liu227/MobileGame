| Field | Row 1 |
|-------|-------|
| Date, commit, versionName / versionCode, Release or Dev, Unity version | 09/11/2026 · Commit: Pending · Version: 0.1.1 (verify) · Android Release · Unity 6.6 |
| Device model, Android version, SoC / GPU, graphics API, refresh rate | Samsung Galaxy S25 FE · Android version: Pending · Exynos 2400 · GPU: Xclipse 940 (verify) · Graphics API: Vulkan (from Lab A capture; verify Release) · Refresh rate: 120 Hz maximum (verify active setting) |
| Target fps | 60 FPS |
| Menu: avg ms / p99 ms | 16.67 ms / 16.78 ms|
| Steady gameplay: avg ms / p99 ms | 16.67ms / 16.81 ms |
| Worst case: avg ms / p99 ms | 16.69 ms / 16.89 ms |
| GC allocated per frame (bytes), allocating markers | GC allocated per frame (bytes), allocating markers **99 B** (selected frame); `GC.Alloc` under `Inl_Record Render Graph` (48 B); remaining 51 B not identified |
| Peak Total Reserved (MB) / TOTAL PSS (MB) | Not available; peak Total Allocated ≈ 625 MB / Total PSS = 374.3 MB|
| Worst case: SetPass / batches / triangles | 6 / 5 / 45 |
| Cold start ms (median of 3), first interactive s | 484 ms median (588, 477, 484 ms; all LaunchState: COLD) · 2.33 s median to interactive (2.33, 2.34, 2.32 s)|
| APK size (MB) | 57.44 MiB (60,229,720 bytes; Mobilegame-0.3.0-arm64.apk) |
| Thermal delta, throttling (Week 7) | |
| Load time (Week 5) | MenuScene: 170, 170, 151 ms (median 170 ms) · GameScene: 137, 116 ms · ResultScene: 76 ms |