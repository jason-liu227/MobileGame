## Week 5 Lab A — Object Pooling Performance

**Device:** Samsung Galaxy S25 FE  
**Build:** Android Development Build with Profiler
**Date** 11 November 2026

| Metric | Result |
|---|---|
| Selected frame | 688 |
| CPU frame time | 17.26 ms |
| Total GC Alloc per frame | 99 B |
| PlayerLoop GC Alloc | 99 B |
| FinishFrameRendering GC Alloc | 48 B |
| NewInputUpdate GC Alloc | 17 B per occurrence |
| Total Used Memory | 200.4 MB |
| ObstacleSpawner GC Alloc | 0B |
| CoinPool GC Alloc | 0B |
| Runtime Instantiate calls | 0 |
| Average frame time during spawning | 16.68 ms |
| 99th percentile frame time | 16.95 ms |

**Optimisation:** Implemented object pooling for obstacles and coins, allowing objects to be reused instead of repeatedly instantiated and destroyed.

**Observation:** The selected spawning frame showed 0 B GC Alloc. This suggests the pooling system is avoiding managed allocations during the measured frame.

## Week 5 Lab B — Android Loading Performance

**Device:** Samsung Galaxy S25 FE  
**Build:** Android Development Build  
**Date:** 12 November 2026

| Metric | Result |
|---|---|
| Cold start — Run 1 | 588 ms |
| Cold start — Run 2 | 477 ms |
| Cold start — Run 3 | 484 ms |
| Median cold start | 484 ms |
| Cold-start budget | Under 5,000 ms — Met |
| Time to interactive — Run 1 | 2.33 s |
| Time to interactive — Run 2 | 2.34 s |
| Time to interactive — Run 3 | 2.32 s |
| Median time to interactive | 2.33 s |
| MenuScene load time | 170 ms, 170 ms, 151 ms |
| GameScene load time | 137 ms, 116 ms |
| ResultScene load time | 76 ms |
| APK size | 57.44 MiB (60,229,720 bytes) |

**Implementation:** Implemented a persistent `SceneLoader` using Unity `Awaitable`, with a loading screen and progress bar tracking `AsyncOperation.progress`. Added `MenuReady.cs` to measure time to interactive and a `Stopwatch` to record scene-loading times.

**Testing:** Performed three Android cold starts using ADB, force-stopping the application before each launch. All three launches reported `LaunchState: COLD`.

**Observation:** The median Android cold-start time was 484 ms, below the 5,000 ms budget. The median time to interactive was 2.33 seconds. Scene loading completed successfully, with `MenuScene` loading in 151–170 ms, `GameScene` in 116–137 ms, and `ResultScene` in 76 ms.

## Week 7 Lab B - Thermals

**Test:** 0, 5, 10-minute thermal soak on Android  
**Performance mode:** Balanced (60 FPS target, URP render scale 1.0)  

| Field | Value |
| :--- | :--- |
| Build ID and mode | v0.7.1 (95147e6), Balanced |
| Start temperature (°C) | **25.9°C** |
| End temperature (°C) and 10-minute delta | **23.4°C**, delta **−2.5°C** |
| Overlay level at minute 0 / 5 / 10 | 0.38 / 0.36 / 0.35 (all NoWarning) |
| First `ThrottlingImminent` (minute, logcat time) | Not observed |
| `Throttling` observed (yes/no, minute) | No throttling observed |
| Frame time before: mean / 99th (ms) | **16.67 ms / 16.90 ms** |
| Frame time after: mean / 99th (ms) | **16.67 ms / 17.08 ms** (17:59:13 logcat interval) |
| Conditions | Unplugged, brightness ~50%, case off, ambient temperature about 22 C |

### Findings

During the thermal soak, Dashline maintained an average frame time of approximately **16.67 ms**, consistent with the Balanced-mode 60 FPS target.

The selected near-end 99th-percentile frame time was **17.08 ms**, compared with **16.90 ms** before the soak, an increase of **0.18 ms**.

The supplied Adaptive Performance thermal events reported `NoWarning`, with normalized thermal levels between **0.35 and 0.38**. No thermal throttling was observed in those entries.

The battery temperature decreased from **25.9°C to 23.4°C**. This unexpected decrease is recorded as measured and should not be interpreted as proof that the device cooled under sustained load.

**Measurement note:** Frame-time values were obtained from the game's `[Baseline]` logcat output. The selected after value is a near-end interval measurement, not a separately calculated percentile across the entire 60-second after-Profiler capture.

### Evidence

- [Before Profiler capture](thermal-soak/before.data)
- [After Profiler capture](thermal-soak/after.data)
- [Thermal soak logcat](thermal-soak/logcat-soak.txt)
- [Minute 0 screenshot](thermal-soak/minute-00.png)
- [Minute 5 screenshot](thermal-soak/minute-05.png)
- [Minute 10 screenshot](thermal-soak/minute-10.png)


## Week 8 Lab B — Android Startup and Memory

**Date:** 15 November 2026  
**Game:** Dashline  
**Package:** `com.jason.mobilegame`  
**Version:** 0.8.0  
**Build ID:** cb6ecb43

| Metric | Result | Method |
|---|---|---|
| Cold-start time | 374 ms | `adb shell am force-stop`, then `am start -W` |
| Home-and-return time (HOT) | 45 ms | Home for 10 seconds, then `am start -W` |
| Total PSS memory | 345,835 KB (337.7 MiB) | `adb shell dumpsys meminfo` during gameplay |
| Total RSS memory | 407,392 KB (397.8 MiB) | `adb shell dumpsys meminfo` |

**Observations:** Android reported a successful cold launch and a HOT resume. Total PSS was approximately 337.7 MiB during the memory test. No conclusion about memory leaks can be drawn from this single measurement.