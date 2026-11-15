# Week 8 Lab B — Resilience Test Plan

## Test Information

| Field | Value |
|---|---|
| Game | Endless Runner — Dashline |
| Test date | 15/11/2026 |
| Game version | 0.8.0 |
| Build ID | cb6ecb43 |
| Device | Samsung Galaxy S25 FE |
| Android version | 16 |
| Package name | `com.jason.mobilegame` |
| Unity version | 6.6 |
| Logcat evidence | `docs/CA3/qa/logcat-w08-testplan.txt` |

## Six-Scenario Test Plan

| # | Scenario | Trigger / Test Procedure | Expected Result | Pass / Fail | Evidence |
|---|---|---|---|---|---|
| 1 | Resume / Background | Start gameplay, press Home, wait 30 seconds, return to Dashline. Repeat 10 times. Then force-stop and relaunch. | Game resumes without freezing or a black screen; audio behaves correctly; saved progress survives force-stop. | Pass | No freezing or black screen observed. Logcat: L13696, L22182, L24600 |
| 2 | No Network | Enable airplane mode before launching Dashline. Play the game, then repeat by enabling airplane mode during gameplay. | Game remains playable; no hang, crash or unhandled exception. | Pass | No hanging observed. Logcat: L201614, L202128 |
| 3 | Rotation | Rotate the phone during gameplay, or verify that the game remains locked to its intended orientation. | UI remains correctly positioned; no stretching, unexpected restart or broken safe area. | Pass | No observed breaking. Logcat: L13736, L14204, L16915 |
| 4 | Battery Saver | Enable Android Battery Saver and play for 2 minutes. | Game remains playable; frame rate and UI remain acceptable. | Pass | Game is playable and UI remains usable. Logcat: L275316, L275318 |
| 5 | Low RAM | Run the Android memory-trim command, background Dashline, open other memory-intensive apps for 1 minute, then return. | No black screen or crash; game resumes or restores saved progress if Android terminates it. | Pass | No black screen etc. Logcat: L37442, L37444 |
| 6 | Cold / Warm Start | Force-stop and launch Dashline, then test Home-and-return startup. | App starts without hanging and returns to gameplay or the menu correctly. | Pass | Cold: 374 ms; HOT resume: 45 ms. Logcat: L325435, L326063, L337707 |

## Scenario 1 — Resume / Background

**Procedure:**

1. Launch Dashline and start playing.
2. Press Home.
3. Wait 30 seconds.
4. Return to Dashline.
5. Check gameplay, audio and screen rendering.
6. Repeat 10 times.
7. Force-stop Dashline and relaunch.
8. Verify saved progress.

**Results:**

- Successful resume cycles: 10/ 10
- Audio paused correctly: Yes
- No black screen or freeze: Yes
- Saved progress survived force-stop: Yes
- Overall result: **Pass**
- Evidence: `logcat-w08-testplan.txt`

**Logcat Evidence:**

- `logcat-w08-testplan.txt:L13696` — `scheduleTopResumedActivityChanged, onTop=true` confirms Dashline entered the foreground.
- `logcat-w08-testplan.txt:L14720` — `Finish starting ActivityRecord ... first real window is shown` confirms the game window appeared.
- `logcat-w08-testplan.txt:L22182` — `scheduleTopResumedActivityChanged, onTop=false` confirms Dashline left the foreground.
- `logcat-w08-testplan.txt:L24600` — `destroySurfaces: appStopped=true` confirms Android stopped the activity's visible surfaces.

These entries support the background/foreground lifecycle test. Successful recovery, audio behaviour and saved progress were verified during manual testing.

## Scenario 2 — No Network

**Procedure:**

1. Enable airplane mode.
2. Launch Dashline and play.
3. Disable airplane mode.
4. While playing, enable airplane mode again.
5. Check for freezes, crashes or exceptions.

**Results:**

- Offline launch: Passed
- Mid-game network loss: Passed
- Overall result: **Pass**
- Evidence: docs/CA3/qa/logcat-w08-testplan.txt

**Logcat Evidence:**

- `logcat-w08-testplan.txt:L200761` — `airplaneMode = true` confirms Airplane Mode was enabled.
- `logcat-w08-testplan.txt:L200813` — `mSetting.getValue() 1` confirms the Airplane Mode setting was active.
- `logcat-w08-testplan.txt:L201614` — `airplaneMode = true` and `getMobileDataRegState() = false` confirm Airplane Mode was enabled and cellular data was not registered.
- `logcat-w08-testplan.txt:L202128` — `handleUpdateState: value = true, state = 2` confirms the Airplane Mode tile was enabled.
- `logcat-w08-testplan.txt:L218418` — `airplaneMode = true` confirms Airplane Mode remained active later in the recording.

These entries establish the Airplane Mode condition. Continued gameplay without hanging was verified manually. Airplane Mode alone does not prove Wi-Fi was disabled.

## Scenario 3 — Rotation

**Procedure:**

1. Launch Dashline.
2. Rotate the phone or verify orientation lock.
3. Check UI layout, safe areas and gameplay.
4. Restore the normal device orientation.

**Results:**

- Orientation behavior: Passed
- UI layout correct: Passed
- Unexpected restart or freeze: Passed
- Overall result: **Pass**
- Evidence: docs/CA3/qa/logcat-w08-testplan.txt

**Logcat Evidence:**

- `logcat-w08-testplan.txt:L13700` — `rotationForOrientation` identifies Dashline as the activity whose orientation Android evaluated.
- `logcat-w08-testplan.txt:L13736` — `setFixedRotationLaunchingAppUnchecked, rotation=3` confirms a fixed rotation was applied to Dashline.
- `logcat-w08-testplan.txt:L14204` — `mDisplayFrame=Rect(0, 0 - 2340, 1080)` records the landscape display frame and display-cutout insets.
- `logcat-w08-testplan.txt:L16685` — `because seamless rotating` shows Android handling a seamless rotation transition.
- `logcat-w08-testplan.txt:L16915` — `Display{#0 state=ON size=2340x1080 ROTATION_270}` confirms the display orientation.

These entries support the orientation test. Correct UI positioning and safe-area behaviour were verified visually.

## Scenario 4 — Battery Saver

**Procedure:**

1. Enable Battery Saver.
2. Launch Dashline.
3. Play for 2 minutes.
4. Observe responsiveness, frame rate and UI.
5. Disable Battery Saver.

**Results:**

- Battery Saver enabled: Yes
- Test duration: 2 minutes
- Gameplay remained playable: Pass
- Frame rate / responsiveness: 60 FPS, Balanced / Pass
- Crash or freeze observed: No
- Overall result: **Pass**
- Evidence: docs/CA3/qa/logcat-w08-testplan.txt

**Logcat Evidence:**

- `logcat-w08-testplan.txt:L275316` — `enableBatterySaver: true(8)` confirms Battery Saver was enabled.
- `logcat-w08-testplan.txt:L275318` — `send ACTION_POWER_SAVE_MODE_CHANGED` confirms Android broadcast the power-saving state change.
- `logcat-w08-testplan.txt:L275383` — `ServiceType: BATTERY_STATS: true` confirms a Battery Saver policy was active.
- `logcat-w08-testplan.txt:L275390` — `ServiceType: FORCE_ALL_APPS_STANDBY: true` confirms a standby restriction was enabled.
- `logcat-w08-testplan.txt:L275395` — `ServiceType: QUICK_DOZE: true` confirms a power-saving policy was enabled.
- `logcat-w08-testplan.txt:L275400` — `flags=low_power_mode` confirms the display was operating in low-power mode.

These entries confirm Battery Saver activation. Continued playability and responsiveness were verified manually.

## Scenario 5 — Low RAM

**Procedure:**

1. Launch Dashline.
2. Run:

   `adb shell am send-trim-memory com.jason.mobilegame RUNNING_CRITICAL`

3. Press Home.
4. Open Camera or a browser for approximately 1 minute.
5. Return to Dashline.
6. Check whether the game resumes or restores saved progress.

**Results:**

- Memory trim command executed: Yes
- Backgrounded for 1 minute: Yes
- Game resumed normally: Yes
- Black screen or crash: No
- Saved progress restored if needed: Passed
- Overall result: **Pass**
- Evidence: docs/CA3/qa/logcat-w08-testplan.txt

**Logcat Evidence:**

- `logcat-w08-testplan.txt:L24548` — `Unity (30859): Handle cmd APP_CMD_LOW_MEMORY(10)` confirms Unity handled a low-memory notification.
- `logcat-w08-testplan.txt:L37442` — `Unity (30859): Handle cmd APP_CMD_LOW_MEMORY(10)` confirms another low-memory notification was handled.
- `logcat-w08-testplan.txt:L37444` — `HWUI (30859): CacheManager::trimMemory(20)` confirms graphics cache trimming in the game process.
- `logcat-w08-testplan.txt:L44217` — `Unity (30859): Handle cmd APP_CMD_LOW_MEMORY(10)` confirms further low-memory handling.
- `logcat-w08-testplan.txt:L51127` — `Unity (30859): Handle cmd APP_CMD_LOW_MEMORY(10)` confirms another low-memory event.
- `logcat-w08-testplan.txt:L57939` — `Unity (30859): Handle cmd APP_CMD_LOW_MEMORY(10)` confirms continued low-memory event handling.

These entries demonstrate that Unity received low-memory notifications. They do not independently establish that a specific entry was caused by the `RUNNING_CRITICAL` command. Successful game recovery was verified manually.

## Scenario 6 — Cold / Warm Start

**Procedure:**

1. Force-stop Dashline.
2. Launch using `adb shell am start -W`.
3. Record `LaunchState` and `TotalTime`.
4. Press Home and return to Dashline.
5. Check that startup completes without hanging.

**Measurements already collected:**

- Cold start: **374 ms** (`LaunchState: COLD`)
- Home-and-return: **45 ms** (`LaunchState: HOT`)
- Note: The second measurement is a HOT resume, not a WARM launch.

**Results:**

- Startup hang observed: No
- Overall result: **Passed**
- Evidence: `logcat-w08-testplan.txt`

**Logcat Evidence:**

- `logcat-w08-testplan.txt:L325435` — `START u0 ... cmp=com.jason.mobilegame/... result code=0` confirms an activity launch request.
- `logcat-w08-testplan.txt:L325831` — `scheduleTopResumedActivityChanged, onTop=true` confirms Dashline entered the foreground.
- `logcat-w08-testplan.txt:L326063` — `Displayed com.jason.mobilegame/...: +156ms` records Android's activity-display time.
- `logcat-w08-testplan.txt:L330168` — `scheduleTopResumedActivityChanged, onTop=false` confirms Dashline left the foreground.
- `logcat-w08-testplan.txt:L337664` — `START u0 ... result code=2` records another launch request for Dashline.
- `logcat-w08-testplan.txt:L337707` — `scheduleTopResumedActivityChanged, onTop=true` confirms the existing Dashline activity returned to the foreground.

The `+156ms` Android activity-display timing is separate from the recorded `374 ms` cold-start and `45 ms` HOT-resume measurements.

## Logcat Evidence

Full logcat recording:
`docs/CA3/qa/logcat-w08-testplan.txt`

Log file size: 115,526,366 bytes (110.2 MiB).

**Scenario Evidence Index:**

| Scenario | Result | Primary logcat evidence |
|---|---|---|
| 1 — Resume / Background | Pass | `logcat-w08-testplan.txt:L13696,L22182` |
| 2 — No Network | Pass | `logcat-w08-testplan.txt:L201614` |
| 3 — Rotation | Pass | `logcat-w08-testplan.txt:L13736` |
| 4 — Battery Saver | Pass | `logcat-w08-testplan.txt:L275316` |
| 5 — Low RAM | Pass | `logcat-w08-testplan.txt:L37442` |
| 6 — Cold / Warm Start | Pass | `logcat-w08-testplan.txt:L337707` |

### Error Search

Searched for:
- `ANR in com.jason.mobilegame`
- `NullReferenceException`
- `FATAL EXCEPTION`
- `Fatal signal`
- `com.jason.mobilegame.*has died`

**Result:** No matches found for these patterns.

No crashes, freezes or ANRs were observed during the six
resilience tests.

**Logcat review:** PASS (for the searched error patterns).

## Known Issues and Fixes

| Issue | Reproduction Steps | Expected vs Actual | Fix / Action | Retest |
|---|---|---|---|---|
| None recorded yet | N/a | N/a | N/a | N/a |

## Final Summary

- Tests passed: 6 / 6
- Tests failed: 0 / 6
- Tests pending: 0 / 6
- Most serious issue: N/a
- Fix applied or issue filed: N/a
- Final build ID: cb6ecb43
