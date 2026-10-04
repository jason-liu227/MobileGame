# MobileGame - Dashline

Model: Smamsung S25 FE  
Android Ver.: Version 16

## Build step used:  
``.\adb.exe devices``

``.\adb.exe install -r Builds/Mobilegame-dev.apk``  

``.\adb.exe shell monkey -p com.jason.mobilegame 1``  
``.\adb.exe logcat -s Unity``


## Bootstrap
[Boot] samsung SM-S731B | Android OS 16 / API-36 (BP2A.250605.031.A3/S731BXXS6AZCH) | Vulkan | 1080x2340 @ 450 dpi

## Game Option
Game Option: Endless Runner

## Keystore
Keystore location: "C:\dashline-release.keystore"
Validity: 50 Years  
Alias: dashline

## Build Profiles:

Android Dev: 
- For development and testing
- Allows easier debugging based on development build

Android Release:
- Release version/ distribution based on complete features.
- Usually no debugging and not development build
- Optimised for performance


# Release Step
## Build

1. Clone the repository and open the project in **Unity 6.6**.
2. Open **File → Build Profiles** and select **Android**.
3. In **Player Settings → Android → Other Settings**, verify:

   * Scripting Backend: **IL2CPP**
   * Target Architectures: **ARM64**
   * Package Name: **`com.jason.mobilegame`**
   * Version: **0.2.0**
   * Bundle Version Code: **2**
4. Use the Android Build Profile for the build.
5. For the final APK, ensure:

   * **Development Build: Off**
   * **Build App Bundle: Off**
6. Build the APK to:
   `releases/MyGame-0.2.0-arm64.apk`
7. With the Android device connected and USB debugging enabled, install with:

   ```powershell
   adb install -r releases/MyGame-0.2.0-arm64.apk
   ```
8. Verify the installed package reports **versionName 0.2.0** and **versionCode 2**.

## Device targets

* Minimum Android API: **26**
* Target architecture: **ARM64**
* Tested devices:

  * **<Samsung 26 FE>**
  * **Samsung Galaxy A55**

