## Week 5 — Object Pooling Performance

**Device:** Samsung Galaxy S25 FE  
**Build:** Android Development Build with Profiler

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