# Economy Telemetry Event Map

**Project:** Gravity-Reversal Endless Runner  
**Module:** Mobile Game Development (A12581)  
**Milestone:** Week 6 Lab B — Economy Telemetry

| Event | Parameters (type) | Fires when | Question it answers |
|---|---|---|---|
| `session_start` | `app_version` (string), `device_model` (string), `android` (string) | Application launches in `Bootstrap.Awake()` | Which app version and Android device produced the data? |
| `level_start` | `level_id` (int), `attempt` (int), `coins` (int) | A new gameplay attempt begins | How often does the player retry, and how many coins do they start with? |
| `level_complete` | `level_id` (int), `time_s` (float), `coins_earned` (int), `score` (int) | Player completes the survival lane | How long did the successful run take, and how much currency was earned? |
| `level_fail` | `level_id` (int), `time_s` (float), `cause` (id), `coins_earned` (int) | Player collides with an obstacle | When and why did the player fail, and how many coins did they earn? |
| `upgrade_purchased` | `upgrade_id` (id), `level` (int), `cost` (int), `coins_left` (int) | `Wallet.TryUpgrade()` successfully purchases an upgrade | When are upgrades purchased, and how quickly is currency spent? |

### Data storage and privacy

Telemetry is written to the Unity Console/Android logcat and to `telemetry.log` in `Application.persistentDataPath`. The telemetry system uses local storage only and does not transmit gameplay events to an external analytics service.

The game's privacy statement (`docs/CA1/privacy-statement.md`) also documents this local telemetry storage.