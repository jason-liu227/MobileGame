# Week 7 Lab A — Performance Modes Baseline

**Game:** Endless Runner – Dashline  
**Test device:** Samsung SM-S731B  

## Performance Results

| Mode | targetFrameRate | Render scale | Frame time avg (ms) | 99th (ms) | Bottleneck | Panel Hz |
|---|---|---|---|---|---|---|
| Balanced (default) | 60 | 1.0 | 16.69 ms | 16.81 ms | TargetFrameRate | 60 or 120* |
| High FPS | 120 | 0.8 | 8.34 ms | 16.83 ms | TargetFrameRate / Unknown | 60 or 120* |

## Adaptive Performance Verification

The Android Adaptive Performance provider was confirmed active on the Samsung SM-S731B.

Observed events included:

- Thermal warning: `NoWarning`
- Thermal level: 0.20–0.27
- Bottleneck: `TargetFrameRate`, occasionally `Unknown`

## Test Procedure

1. Installed the latest Android APK.
2. Tested Balanced mode for 30 seconds.
3. Tested High FPS mode for 30 seconds.
4. Recorded FPS and frame-time measurements.
5. Captured screenshots of both modes.
6. Checked Android logcat for `perf_mode=` and `[AP]` events.

## Evidence

- [Balanced screenshot](perf-modes/balanced.png)
- [High FPS screenshot](perf-modes/high-fps.png)
- [Android Adaptive Performance logcat](logcat-ap-events.txt)

