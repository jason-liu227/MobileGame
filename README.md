# MobileGame — Dashline

**Game:** Dashline — 2D Gravity-Reversal Endless Runner  
**Engine:** Unity 6.6  
**Platform:** Android  
**Current documented version:** 0.8.0  
**Package name:** `com.jason.mobilegame`

## Game Overview

Dashline is a 2D endless runner where the player avoids obstacles by reversing gravity between the floor and ceiling.

The objective is to survive for 120 seconds while collecting coins and earning points. Coins can be spent on upgrades that increase movement speed and score rewards.

The game includes a main menu, gameplay scene, result screen, pause/resume functionality, local save data, and selectable performance settings.

## Controls

| Action | Control |
|---|---|
| Reverse gravity | Tap the screen during gameplay |
| Pause / resume | Use the on-screen pause and resume controls |
| Restart a run | Select Retry on the result screen |
| Change performance settings | Use the Settings menu |
| Select device quality | Choose Auto, Low, Mid or High |

## Device Targets

| Setting | Value |
|---|---|
| Primary test device | Samsung Galaxy S25 FE (SM-S731B) |
| Android version | Android 16 (API 36) |
| Processor | Exynos 2400 |
| GPU | Xclipse 940 |
| Graphics API | Vulkan |
| Target architecture | ARM64 |
| Package name | `com.jason.mobilegame` |
| Default performance target | 60 FPS |
| Minimum Android API | 26 (previously documented; verify in Player Settings) |

The game has primarily been tested on the Samsung Galaxy S25 FE. Compatibility with other Android devices is not fully verified.

### Android Bootstrap Information

```text
[Boot] samsung SM-S731B | Android OS 16 / API-36
(BP2A.250605.031.A3/S731BXXS6AZCH)
Vulkan | 1080x2340 @ 450 dpi
```

## Build Profiles

The Unity project uses Android build profiles for development and release testing.

**Android Development**

- Used for debugging and profiling.
- Development Build and profiler connection can be enabled.
- Used to collect Unity Profiler and Android logcat measurements.

**Android Release**

- Used for the final CA2 APK.
- Development Build disabled.
- IL2CPP scripting backend.
- ARM64 architecture.
- APK output rather than Android App Bundle.
- Release signing enabled.

## Android Release Build Steps

### 1. Open the Unity Project

1. Clone the repository.
2. Open the project using Unity Hub.
3. Select Unity 6.6.
4. Allow Unity to import the project and resolve its packages.

### 2. Select the Android Build Profile

1. Open **File → Build Profiles**.
2. Select the Android Release profile.
3. Switch the active platform to Android if necessary.
4. Verify that the required scenes are included and enabled in the build.

### 3. Verify Android Player Settings

Open **Edit → Project Settings → Player → Android**.

Under **Other Settings**, confirm:

| Setting | Required value |
|---|---|
| Scripting Backend | IL2CPP |
| Target Architectures | ARM64 |
| Package Name | `com.jason.mobilegame` |
| Version | `0.9.0` |
| Bundle Version Code | `9` |
| Minimum API Level | Verify against the project configuration |

The version and version code above reflect the documented Week 8 release. Confirm that they still match the final CA2 build before packaging.

### 4. Configure Release Signing

Open **Player Settings → Publishing Settings**.

The project uses a release keystore stored locally at:

```text
C:\dashline-release.keystore
```

Keystore details:

- Alias: `dashline`
- Validity: 50 years

Enable custom keystore signing, select the correct keystore and alias, and enter the required passwords.

**Security:** Do not commit the keystore file or its passwords to Git. The keystore must be available locally when producing the signed APK.

### 5. Configure the Final Build

In the Android Release Build Profile, verify:

- Development Build: **Off**
- Autoconnect Profiler: **Off**
- Script Debugging: **Off**
- Build App Bundle (Google Play): **Off**
- Architecture: **ARM64**
- Signing: **Release keystore**

Build the APK using **Build**, not Build And Run, so the output file can be retained for submission.

Save the resulting APK in the CA2 submission's `APK/` folder.

Example:

```text
MobileGame-Ca2/APK/Mobilegame-0.9.0-arm64.apk
```

This is a suggested output filename; use the actual name of the APK you build.

### 6. Install and Test on Android

Connect the Samsung phone using USB and enable USB debugging.

Open PowerShell in the directory containing Android SDK platform tools, or use `adb` if it is already available on your PATH.

Check that the device is detected:

```powershell
.\adb.exe devices
```

Install the release APK:

```powershell
.\adb.exe install -r "C:\path\to\Mobilegame-0.9.0-arm64.apk"
```

Launch the game:

```powershell
.\adb.exe shell monkey -p com.jason.mobilegame 1
```

View Unity logcat output:

```powershell
.\adb.exe logcat -s Unity
```

Replace the example APK path with the location of the actual release build.

### 7. Verify the Release

Confirm that:

- The APK installs and launches successfully.
- The game reaches the main menu.
- A complete gameplay run can be played.
- Pause and resume work.
- Saved progress survives a relaunch.
- Settings and performance-tier selection work.
- No blocking crashes occur.

The CA2 submission must include a release-signed APK that can be installed without requiring ADB.

## Performance and Quality Settings

Dashline supports three device-quality tiers.

| Setting | Low | Mid | High |
|---|---|---|---|
| Render scale | 0.75 | 0.9 | 1.0 |
| MSAA | Off | 2× | 4× |
| Shadows | Off | 20 m / 1024 | 40 m / 2048 |
| Target FPS | 30 | 60 | 60 |

The `DeviceTier` system automatically selects a tier using device memory and CPU core count. Players can select Auto, Low, Mid or High from the settings menu.

On the Samsung Galaxy S25 FE, automatic selection was verified as **Mid** in Android logcat.

## Performance Evidence

Android testing includes:

- Frame-time measurements and Unity Profiler captures.
- Object pooling measurements.
- Android startup and loading times.
- Memory Profiler measurements and memory budgets.
- Adaptive Performance and thermal-soak testing.
- Android pause/resume and resilience testing.

Detailed results are recorded in:

- `docs/CA2/baseline/Performance_Baseline.md`
- `docs/CA2/baseline/baseline-sheet.md`
- `docs/CA2/baseline/bottleneck-01.md`
- `docs/CA2/baseline/perf-modes.md`

## Data Storage and Telemetry

Dashline stores gameplay progress locally.

The economy includes coin collection, spending and upgrades.

Gameplay telemetry records events such as:

- `session_start`
- `level_start`
- `level_complete`
- `level_fail`
- `upgrade_purchased`

Telemetry is recorded locally through Unity logs and `telemetry.log`. No third-party analytics service is required.

The event definitions are documented in `docs/CA2/Economy_Telemetry_Map.md`.

## Known Issues

No gameplay-blocking bugs or crashes were identified during the completed Android testing.

Testing limitations and remaining verification items are documented in [KnownIssues.md](KnownIssues.md).

## CA2 Submission

The final Moodle submission contains:

```text
CA2_Submission/
├── APK/
│   └── [Release-signed APK]
├── Video/
│   └── [3–5 minute gameplay recording]
├── Docs/
│   ├── Performance_Baseline.md
│   ├── Economy_Telemetry_Map.md
│   └── Reflective_Journal.md
├── README.md
├── KnownIssues.md
└── LINKS.txt
```

`LINKS.txt` contains the repository URL and the Git release tag corresponding to the submitted build.

## AI Assistance

ChatGPT was used to assist with Unity development troubleshooting, performance measurement interpretation, and the drafting and formatting of technical documentation.

Generated suggestions and documentation were reviewed against the project's implementation, Android test results and Unity Profiler measurements. Final responsibility for the implementation, verification and submitted work remains with the developer.