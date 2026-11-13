# Privacy Statement

## Data collected

This game does not intentionally collect personal data from players.

No player names, email addresses, contact information, location data, photographs, or other personal information are collected by the game.

No analytics or advertising functionality is included in the project this semester.

## Data stored on the device

The game uses Unity `PlayerPrefs` for local settings.

The following settings are stored on the device:

- `haptics` — stores whether haptic feedback is enabled.
- `textScale` — stores the selected text-size setting.

These settings are stored locally by the application and are not intended to be transmitted to a server.

No player account or online profile is created.

If local game data needs to be removed, uninstalling the game removes the application's locally stored data.

Any Week 6 telemetry logging is intended to remain local to the device and is not uploaded to a remote server.

## Network activity

The installed APK requests the Android `INTERNET` permission.

However, the application scripts checked for this CA1 privacy review contain no application-level use of `UnityWebRequest`, analytics, advertising, or other identified network communication.

Therefore, no intentional application-level transmission of player data has been identified in the current project.

The presence of the `INTERNET` permission is nevertheless recorded here because it is present in the installed APK.

## Third-party SDKs

No third-party advertising, analytics, or user-data collection SDKs are intentionally included in the project this semester.

The game uses Unity and its standard Android/Unity functionality.

## Permissions requested

The installed APK reports the following requested permissions:

```text
com.jason.mobilegame.DYNAMIC_RECEIVER_NOT_EXPORTED_PERMISSION
android.permission.INTERNET
android.permission.VIBRATE
```

### `com.jason.mobilegame.DYNAMIC_RECEIVER_NOT_EXPORTED_PERMISSION`

This is an application-specific Android permission associated with the Android/Unity application configuration. It is not used by the game to collect personal information.

### `android.permission.INTERNET`

The APK declares Internet access. No intentional application-level network requests were identified in the project scripts checked for this review, and no player data is intentionally transmitted to a server.

### `android.permission.VIBRATE`

This permission is used for the game's haptic feedback. The game calls Unity's `Handheld.Vibrate()` when haptic feedback is enabled.

## How this would be declared on Google Play

The information in this statement would be used when completing the Google Play Data Safety form.

Data collection and security practices

The game does not intentionally collect personal player data. Local settings such as haptic-feedback and text-size preferences are stored on the device.

## Data sharing

No player data is intentionally shared with third parties or transmitted to an external service by the game.

## Privacy policy

If the application is released through a Google Play track that requires a privacy policy, the appropriate privacy policy URL would need to be supplied in the Play Console and the declarations would need to match the final released APK.

The Play Console requirements should be checked again at the time of submission because requirements can change. The Data Safety form must be completed for the applicable release tracks; the internal testing track has the exemption noted in the CA1 requirements.

# Verification

This statement was checked against the installed Android build.

The installed package reported:

com.jason.mobilegame.DYNAMIC_RECEIVER_NOT_EXPORTED_PERMISSION
android.permission.INTERNET
android.permission.VIBRATE

The project-script search found no application-level references to:

UnityWebRequest
persistentDataPath
Analytics
Ads

No intentional network endpoint or third-party advertising/analytics service was identified during this review.

## Local Game Progress Storage

The game stores the player's coin balance and purchased upgrade level locally on their device using Unity PlayerPrefs. This information is used to restore gameplay progress when the game is reopened.

The simulated in-app purchase feature does not process real payments or collect payment information. No real store integration is included.

## Local Gameplay Telemetry

The game records local gameplay events, including session starts, level starts, level completions, level failures, and upgrade purchases.

These records include gameplay statistics, application version, device model, and Android operating system information. Events are stored in a local file named `telemetry.log` within the application's persistent data directory and are also written to Android's diagnostic log.

No third-party analytics SDK is used, and the game does not automatically transmit telemetry to an external server. Telemetry files may be retrieved manually during development and testing for gameplay balancing.

The telemetry log may grow over time and is removed when the application's local data is cleared.