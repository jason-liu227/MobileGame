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

## Week 6 Lab A — Economy Pacing

### Economy settings
- Coins earned per pickup before tuning: 10
- Coins earned per pickup after tuning: 5
- Upgrade costs: 100, 150, 225, 337, 506 ...

### Pacing results
- Time of first upgrade: [30s]
- Coins remaining after 3 minutes: [392]
- Upgrades purchased after 3 minutes: [3-4]
- First upgrade within 2 minutes: [Yes]

### Upgrade impact
Each purchased upgrade increases obstacle and coin movement speed by 0.5 units per second and increases score earned per second by 10%. Players feel the upgrade through faster-moving obstacles, which demand quicker gravity reversals, while the increased score rate rewards the additional difficulty.

### Reflection
The inital 10 coins per pickup was too fast for the game. The first ugrade was purchasable within 15 seconds of the game and 4-5 upgrades can be unlocked before 3 minutes of gameplay.

After tuning the coin gain to 5 per pickup, the first upgrade is purchasable approximately after 20-30 seconds.

For and endless runner the tuning was required as the game would become too difficult at an unreasonable pace. Lowering the gain would allow the player to get used to the difficulty increase and be prepared for an increased dificulty.

## Week 6 Lab B — Telemetry, Persistence and Async Pack 1

### Telemetry Events

Implemented five telemetry events in *Endless Runner – Dashline*:

1. `session_start` — Records the application version and device information when the game launches.
2. `level_start` — Records the level ID, attempt number and starting coins.
3. `level_complete` — Records completion time, coins earned and final score.
4. `level_fail` — Records survival time, failure cause and coins earned.
5. `upgrade_purchased` — Records the upgrade purchased, its cost and remaining coins.

Telemetry is recorded in Android logcat and stored locally in `telemetry.log`.

### Android Save and Resume Testing

| Test | Result |
|---|---|
| Home button → resume game | PASS |
| Force-stop → relaunch game | PASS |
| Background process kill → relaunch | PASS |
| Wallet coins and upgrade level persist | PASS |
| Telemetry log persists after relaunch | PASS |

**Telemetry evidence:** `docs/CA2/telemetry/telemetry.log`

### Async Pack 1 — Monetisation Models & Ethics

**Due date:** Sunday 1 November 2026.

Completed a reflection covering the game's earn–spend–upgrade economy, proposed free-to-play monetisation model, and five dark-pattern risks with ethical guardrails.

The current game uses a simulated purchase provider, with no real-money IAP SDK implemented.

## Week 7 — Adaptive Performance and Thermal Soak Testing

### Lab A — Adaptive Performance and Frame-Rate Toggle

This week, I integrated Unity's Adaptive Performance package and Android Provider into Dashline. I created an `AdaptiveBootstrap` script to monitor thermal warnings and performance bottlenecks through Android logcat.

I also implemented two selectable performance modes:

- **Balanced:** 60 FPS target with URP render scale 1.0.
- **High FPS:** 120 FPS target with URP render scale 0.8.

I added a High FPS toggle to the game's settings menu and confirmed that switching modes updated the frame-rate target and render scale. Android logcat showed the mode changes and Adaptive Performance bottleneck events.

I also added an in-game FPS overlay to monitor frame time and performance during gameplay.

### Lab B — 10-Minute Thermal Soak

I created a thermal overlay displaying frame time, thermal warning level, normalized temperature level and temperature trend.

I then ran a 10-minute thermal soak on my Samsung phone in Balanced mode, capturing screenshots at minutes 0, 5 and 10.

| Measurement | Result |
|---|---|
| Starting battery temperature | 25.9°C |
| Ending battery temperature | 23.4°C |
| Temperature change | −2.5°C |
| Thermal level at 0 / 5 / 10 minutes | 0.38 / 0.36 / 0.35 |
| Thermal warnings | `NoWarning` at all three checkpoints |
| Average frame time before / after | 16.67 / 16.67 ms |
| Selected p99 before / near end | 16.90 / 17.08 ms |

The results showed that Dashline maintained approximately 60 FPS during the test. No thermal throttling was observed in the recorded thermal events. The battery temperature decreased during the test, which was unexpected, so I recorded the measured values without assuming a cause.

### Sustained Performance Budget

My Samsung sustained Dashline's **60 FPS Balanced-mode target**, equivalent to approximately **16.67 ms per frame**, throughout the 10-minute thermal soak, without observed thermal throttling.

### Reading Week Improvement

Based on these results, I will focus on reducing occasional frame-time spikes and improving the HUD layout, particularly the overlapping pause button, performance information and upgrade controls, while maintaining the 60 FPS target.

### Reflection

Lab A demonstrated how frame-rate targets and rendering quality can be adjusted for different devices. Lab B showed why sustained testing is important: a game must maintain consistent performance over time, not just immediately after launch.

The thermal overlay, logcat recordings and Profiler captures provided evidence of how Dashline performed on a real Android device.

### Reading Week and CA2 Reminders

- Reading Week: 26–30 October 2026.
- Async Pack 1 — Monetisation Models & Ethics: due 1 November 2026.
- Week 8 Lab A — Peer distribution and release build: 2 November 2026.
- CA2 Playable Vertical Slice: due 15 November 2026 at 23:59.

## Week 8 — Lab A: Android Build and Performance Baseline

**Date:** 15/11/2026  
**Project:** Endless Runner — Dashline  
**Game version:** 0.8.0  
**Build ID:** `cb6ecb43`  
**Device:** Samsung Galaxy S25 FE (Android 16)  
**Unity:** 6.6  
**Package:** `com.jason.mobilegame`

### Work Completed

- Prepared and tested the Android build of Dashline on a physical Samsung Galaxy S25 FE.
- Updated the Week 8 performance baseline documentation in `docs/CA2/baseline/Performance_Baseline.md` and `docs/CA2/baseline/baseline-sheet.md`.
- Collected Android memory measurements and startup timing samples using ADB.
- Retained the 60 FPS Balanced-mode target from the earlier performance work.

### Measurements

| Metric | Week 8 result |
|---|---|
| Android TOTAL PSS | 345,835 KB (approximately 337.7 MiB) |
| Android RSS | 407,392 KB (approximately 397.8 MiB) |
| Cold launch (`LaunchState: COLD`) | 374 ms — one recorded sample |
| Home-and-return (`LaunchState: HOT`) | 45 ms — one recorded sample |
| Warm launch | Not measured |

The cold and HOT launch measurements are individual ADB samples, not medians. FPS, GC allocation, geometry, APK size, thermal behaviour, and time to interactive were not remeasured as part of these Week 8 figures. Peer-distribution outcomes have not been confirmed in these notes.

### Reflection

Testing the build on a physical Android device provided concrete startup and memory measurements. The results give me an updated baseline for Dashline, while the missing metrics identify what should be captured in a future performance comparison.

## Week 8 — Lab B: Android Resilience Testing

**Date:** 15/11/2026  
**Project:** Endless Runner — Dashline  
**Build ID:** `cb6ecb43`  
**Device:** Samsung Galaxy S25 FE (Android 16)

### Work Completed

- Created `docs/CA3/qa/test-plan.md` for six Android resilience scenarios.
- Tested background/resume, Airplane Mode, rotation/orientation, Battery Saver, low-memory handling, and cold-start/Home-and-return behaviour.
- Recorded Android logcat evidence in `docs/CA3/qa/logcat-w08-testplan.txt`.
- Checked the log for selected crash and error signatures.

### Resilience Test Results

| # | Scenario | Result | Logcat evidence (original line number) |
|---|---|---|---|
| 1 | Resume / Background | PASS | L13696 (foreground), L22182 (background) |
| 2 | No Network / Airplane Mode | PASS | L201614 (Airplane Mode enabled; cellular data not registered) |
| 3 | Rotation / Orientation | PASS | L13736 (fixed rotation applied to Dashline) |
| 4 | Battery Saver | PASS | L275316 (Battery Saver enabled) |
| 5 | Low RAM | PASS | L37442 (Unity handled `APP_CMD_LOW_MEMORY`) |
| 6 | Cold Start / Home / Return | PASS | L337707 (existing activity returned to foreground) |

### Test Observations

**Resume / Background:** Completed 10 out of 10 Home-and-return cycles without a freeze or black screen. Audio paused correctly, and saved progress survived a force-stop and relaunch.

**No Network:** Enabled Airplane Mode before launch and during gameplay. Dashline remained playable without a hang. The logcat confirms Airplane Mode and lack of cellular registration; it does not independently prove Wi-Fi was disabled.

**Rotation:** Verified that the game maintained the intended landscape orientation and the UI remained usable within the safe area. Android logged the rotation and display configuration.

**Battery Saver:** Played for two minutes with Battery Saver enabled. Gameplay and UI remained usable. The test plan records 60 FPS / Balanced mode, but no separate frame-time distribution was captured here.

**Low RAM:** Ran `adb shell am send-trim-memory com.jason.mobilegame RUNNING_CRITICAL`, backgrounded the game, opened Camera and Chrome, and returned. Dashline recovered without a black screen or crash. Unity logged low-memory handling, although the individual log entry cannot be conclusively attributed to the exact trim command.

**Cold Start / Home / Return:** Recorded a cold-launch sample of 374 ms and a HOT-return sample of 45 ms. Android also logged the activity being displayed and subsequently returned to the foreground. The activity-display log timing is distinct from the ADB launch measurements.

### Logcat Review

The full recording was 115,526,366 bytes (approximately 110.2 MiB). Searches for `ANR in com.jason.mobilegame`, `NullReferenceException`, `FATAL EXCEPTION`, `Fatal signal`, and `com.jason.mobilegame.*has died` returned no matches. No crashes, freezes, or ANRs were observed during the six manual tests. This finding is limited to the searched patterns and observed test period.

The logcat exceeds GitHub's standard 100 MB file limit; Git LFS is suitable for storing the complete file while preserving original evidence line numbers.

### Final Result and Reflection

**6 / 6 scenarios passed; 0 failed; 0 pending.** No issues or fixes were recorded for this test run.

This lab helped me check how Dashline behaves under common Android interruptions and device conditions, rather than relying only on normal gameplay tests. Pairing manual observations with logcat entries made the results easier to verify and document. The next improvement is to keep evidence captures concise while retaining the full original log when needed.

## Week 9 — Lab A: Android Quality Tiers and Asset Budgets

**Date:** 15/11/2026  
**Project:** Endless Runner — Dashline  
**Device:** Samsung Galaxy S25 FE (Android 16)  
**Unity:** 6.6

### Work Completed

- Created three Android quality tiers: Low, Mid and High.
- Configured separate URP quality settings for render scale, MSAA, shadows, mipmaps, texture filtering and post-processing.
- Created `DeviceTier.cs` to automatically select a quality tier using device RAM and processor-core count.
- Added a TextMeshPro dropdown with Auto, Low, Mid and High options.
- Used `PlayerPrefs` to save the selected override and restore the dropdown selection when the game restarts.
- Applied a minimalist geometric colour palette to the player, obstacles, floor, ceiling and background.
- Captured Android Memory Profiler measurements for textures, audio and managed memory.
- Recorded Android frame-time and rendering measurements.
- Established provisional memory budgets and checked the results against them.

### Quality Tier Configuration

| Setting | Low | Mid | High |
|---|---|---|---|
| URP render scale | 0.75 | 0.9 | 1.0 |
| MSAA | Disabled | 2× | 4× |
| Shadows | Off | On, 20 m / 1024 | On, 40 m / 2048 |
| Mipmap limit | 1 | 0 | 0 |
| Mipmap streaming | On | On | On |
| Anisotropic filtering | Off | Per Texture | Forced On |
| Post-processing | Off | Bloom only | On |
| Target frame rate | 30 FPS | 60 FPS | 60 FPS |

Android logcat confirmed that automatic device-tier selection chose `tier=Mid` on two launches. The settings dropdown was configured to save and restore manual selections. A forced Low-tier launch was not independently confirmed in the supplied Android logcat evidence.

### Art Pass

I applied a minimalist geometric colour scheme to the existing 2D lane:

| Element | Colour |
|---|---|
| Player | Cyan `#21C7C7` |
| Obstacles | Coral `#FF5C5C` |
| Floor and ceiling | Slate blue `#455A75` |

The lane continues to use simple Sprite Renderer shapes. No imported sprite atlas was created during this pass.

### Memory Budgets and Results

| Category | Provisional budget | Measured | Result |
|---|---:|---:|---|
| Textures (Texture2D) | 32 MB | 5.1 MB | Within budget |
| Audio (AudioClip) | 8 MB | 34.5 KB | Within budget |
| Managed memory | 32 MB | 3.2 MB | Within budget |
| Android Total PSS | 400 MiB | 388.6 MiB | Within budget |

The budgets were established as provisional Week 9 project targets because no explicit peak-memory budget was identified in the available Week 3 documentation.

The first Android PSS measurement was approximately 469.9 MiB. After disconnecting the Unity Profiler and relaunching the game, the retest reported 388.6 MiB, approximately 11.4 MiB below the 400 MiB budget.

The difference between the two readings may reflect profiling overhead or different runtime conditions. It does not establish a memory leak.

### Android Performance Results

| Metric | Week 9 result |
|---|---|
| Automatically selected tier | Mid |
| Target frame rate | 60 FPS |
| Mean frame time | 16.68 ms |
| Highest reported window p99 | 16.88 ms |
| Measurement duration | Approximately 3 minutes 30 seconds |
| Reporting windows | 22 |
| Batches in selected frames | 365–387 |
| SetPass calls | 6 |
| Triangles in selected frames | 707–735 |
| Separate draw-call count | Not independently confirmed |

The frame-time measurements remained close to the 60 FPS target. Week 7 Balanced mode had a mean frame time of approximately 16.67 ms, so the Week 9 mean was similar.

Week 3's bottleneck investigation recorded 5 SetPass calls, compared with 6 in the selected Week 9 captures. Because the captures may differ in scene content and profiling conditions, this does not establish a rendering regression.

The 16.88 ms p99 result is the highest reported percentile from individual logging windows, not a percentile calculated across the complete recording.

### Reflection

This lab helped me understand how to configure rendering quality for Android devices with different hardware capabilities. The automatic device-tier system provides a starting quality level, while the settings dropdown allows the player to choose an override.

The memory measurements showed that textures, audio and managed memory were below the provisional category budgets. The non-profiled Android PSS retest also met the total-memory target, although the remaining headroom was relatively small.

Dashline maintained frame times close to the 60 FPS target on the Mid tier. The next priorities are verifying the manual Low-tier override on Android, confirming any remaining art and import-setting requirements, and completing the final CA2 evidence and commit checks.