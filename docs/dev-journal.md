The option I am shortlisting is an endless runner focused on fast, continuous movement through an increasingly challenging environment. Its core verb is dodge: the player repeatedly moves, jumps, or slides to avoid obstacles while trying to survive for as long as possible. If time ran out, the first thing I would cut would be power-ups and special abilities, keeping the basic running-and-dodging loop intact as the minimum viable experience.

## Headline Numbers:
CPU Main Thread: 16.12ms
SetPass Calls: 3
GC allocated: 4.0mb

## Testing Pause	

| Test | Result |
| -------- | -------- |
| Press Home → wait 10 sec → return | Paused, panel visible, progress saved |
| Pull notification shade down/up | Paused |
| Receive a call → hang up | Paused, return to game with resume |
| Screen off → turn screen back on | Paused |
| Force stop → relaunch | Progress saved |

## Week 3 -Lab A
## CPU capture of worst case
 Worst-frame main-thread ms: 17.05 ms  
 The tallest marker name: PlayerLoop  
 Top three hierarchy entries:
 - WaitForTargetFPS - 11.44 Self ms 
 - PrepareSceneNodes - 0.08 Self ms
 - PostLateUpdate.FinishFrameRendering - 0.07 Self ms  

 GC.Collect: No

## Week 4 - Lab B
### Work Completed

- Configured a 60 FPS target for Android.
- Added `FrameTimeSampler.cs` to measure average and p99 frame times.
- Tested menu, steady gameplay, and worst-case gameplay.
- Used the Unity Profiler to investigate GC allocations and memory usage.
- Used ADB to measure Android memory consumption.
- Created `docs/CA2/baseline/baseline-sheet.md`.

### Performance Results

| Test | Average Frame Time | p99 Frame Time |
|------|-------------------|----------------|
| Menu | 16.67 ms | 16.78 ms |
| Steady Gameplay | 16.67 ms | 16.81 ms |
| Worst Case | 16.69 ms | 16.89 ms |

The game maintained frame times close to the 60 FPS target. The worst-case p99 was 16.89 ms, slightly above the 16.67 ms frame budget.

### Garbage Collection

- GC allocated in selected frame: **99 B**
- Allocating marker: `GC.Alloc` under `Inl_Record Render Graph` (48 B)
- Remaining 51 B not yet identified.
- `GC.Collect` frequency: Not measured.
- Target: 0 B allocated per steady gameplay frame.

### Memory and Rendering

- Peak Unity Total Allocated: **0.61 GB**
- Android TOTAL PSS: **383,300 KB (374.3 MiB)**
- Batches in selected frame: **5**
- Triangles in selected frame: **45**
- Peak Total Reserved: Not available in current Profiler view.
- Worst-case SetPass Calls: Not yet confirmed.

## Week 5 - Lab A
### 9/11/2026

No .cs files contains IEnumerator or StartCoroutine