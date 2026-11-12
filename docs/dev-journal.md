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

## Week 5 - Lab B
### 12/11/2026

### Work Completed

- Created a greybox lane for the 2D gravity-reversal endless runner.
- Implemented a 120-second survival win condition.
- Implemented a lose condition when the player collides with an obstacle.
- Connected the win and lose conditions to `ResultScene`.
- Added a retry option to restart gameplay.
- Created `SceneLoader.cs` using Unity `Awaitable` for asynchronous scene loading.
- Added `LoadingCanvas` with a progress bar in `BootScene`.
- Added `MenuReady.cs` to measure time to interactive.
- Recorded Android cold-start, scene-loading, and APK-size measurements.

### Lane Definition

The game is a 2D gravity-reversal endless runner focused on avoiding obstacles and surviving for as long as possible.

The core action is dodging obstacles by reversing gravity between the floor and ceiling. Players can also collect coins to increase their coin count.

The objective of the current vertical slice is to survive for 120 seconds. Colliding with an obstacle causes the player to lose.

Both outcomes lead to a result screen where the player can retry.

### Playtest - 2 Minutes

**Confusion 1 - Controls:**

The tester did not immediately understand that tapping the screen reversed gravity. They initially hesitated and collided with an obstacle while learning the controls.

**Confusion 2 - Objective:**

The tester was unsure whether the main objective was collecting coins or surviving. The score and coin counter were visible, but the 120-second timer to finish (test win condition), survival objective was not clearly explained.

### Performance Results

| Metric | Result |
|--------|--------|
| Cold Start - Run 1 | 588 ms |
| Cold Start - Run 2 | 477 ms |
| Cold Start - Run 3 | 484 ms |
| Median Cold Start | 484 ms |
| Cold-Start Budget | Under 5,000 ms - Met |
| Time to Interactive - Run 1 | 2.33 s |
| Time to Interactive - Run 2 | 2.34 s |
| Time to Interactive - Run 3 | 2.32 s |
| Median Time to Interactive | 2.33 s |
| MenuScene Load Times | 170 ms, 170 ms, 151 ms |
| GameScene Load Times | 137 ms, 116 ms |
| ResultScene Load Time | 76 ms |
| APK Size | 57.44 MiB |

### Testing and Observations

- Tested Android cold start three times using ADB.
- All three launches reported `LaunchState: COLD`.
- Median cold-start time was 484 ms, below the 5-second budget.
- Median time to interactive was 2.33 seconds.
- Loading screen appeared during scene transitions.
- Scene-loading times were measured using `System.Diagnostics.Stopwatch`.

### First Planned Improvement

The first improvement will be adding a short instruction at the start of gameplay explaining how to reverse gravity.

I will also add a visible survival timer so players understand that they need to survive for 120 seconds.

### Reflection

The vertical slice now includes gravity reversal, obstacles, coin collection, scoring, win and lose conditions, and a retry option.

Android startup performance met the required budget, and asynchronous scene loading was implemented successfully.

The next priority is improving the clarity of the controls and survival objective for new players.