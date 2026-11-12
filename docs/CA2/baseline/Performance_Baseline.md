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