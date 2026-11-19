# Final-sprint targets (set Wed 11 Nov 2026)

**Project:** Dashline — Unity 6.6 Android  
**Primary test device:** Samsung Galaxy S25 FE (SM-S731B), Android 16  
**Evidence base:** Week 7 thermal soak, Week 8 resilience tests, Week 9 device profiling.

## Thermals

**Target:** Balanced mode holds **≤ 17.1 ms at the 99th percentile at minute 10** of a ten-minute soak on the Samsung Galaxy S25 FE.

**Baseline:** The Week 7 soak recorded p99 **17.08 ms** near minute 10 (16.90 ms before the soak), with no thermal throttling reported. The recorded mean frame time was approximately 16.67 ms. This target maintains the observed result rather than claiming an improvement not yet measured.

**Method:** Repeat the ten-minute test with consistent brightness, mode, scene and capture conditions. If Adaptive Performance reports `ThrottlingImminent`, test a render-scale downshift or Adaptive Resolution scaler, then compare the p99 before and after. Do not claim a thermal fix until measured.

## Resilience

**Target:** All **6 of 6** existing Android test-plan scenarios pass on the Samsung Galaxy S25 FE **and on one peer Android phone**.

**Baseline:** Week 8 recorded **6/6** passing scenarios on the Galaxy S25 FE and **10/10** successful Home-and-return cycles. Equivalent peer-phone results have not yet been recorded.

**Resilience:** All six Android test-plan scenarios passed across three repetitions (18/18 tests) on the Samsung Galaxy S25 FE. No crashes were observed. Crash-free sessions: 3/3, assuming each repetition was a separately launched session. Peer-device verification remains pending.

**Method:** Run the same six-scenario checklist on both phones, collect Android logcat, and document pass/fail outcomes and counted sessions.

## Store assets (awareness only)

**Target:** Prepare **4** annotated store screenshots, a **512 × 512** icon, a **1024 × 500** feature graphic, a short description (≤ 80 characters), a long description (≤ 4,000 characters), and a privacy statement consistent with local-only telemetry. Review the pack in the Week 10 Lab B critique.

**Evidence and scope:** Four screenshots meet the lab's requested 4–6 screenshot plan. This is a preparation target, not a claim that the assets are complete or published. Nothing is uploaded to a store.

**Method:** Create a 6–9-reference icon moodboard, a four-shot annotated screenshot plan, the descriptions, and a comparison of 2–3 similar games. Present them in `docs/CA3/store/pack2-store-presence.pdf`.
