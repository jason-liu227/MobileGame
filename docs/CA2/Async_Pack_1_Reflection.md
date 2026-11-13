# Async Pack 1 — Monetisation Models & Ethics

**Module:** Mobile Game Development 
**Game:** Endless Runner - Dashline
**Due Date:** 1 November 2026

## Task 1 — My Game's Economy Loop

**Earn:** Players collect coins while surviving obstacles and reversing gravity, earning 10 coins for each pickup.

**Spend:** Players use their earned coins to purchase upgrades, with the cost increasing after each purchase.

**Upgrade:** Each upgrade increases the movement speed of obstacles and coins and improves the player's score multiplier, creating a more challenging but potentially more rewarding gameplay loop.

## Task 2 — My Proposed Monetisation Model

If I published my game, I would choose a **free-to-play model with optional consumable coin purchases**.

Players would still earn coins through normal gameplay and purchase upgrades without spending real money. Optional coin packs would provide an alternative way to obtain currency, but they would not unlock exclusive gameplay advantages unavailable to free players.

This model suits an endless runner because the game has a repeatable earn–spend–upgrade loop. It also matches the simulated purchase provider implemented in Week 6 Lab A, which currently awards coins without processing real payments.

I would clearly display the real-money price of each coin pack, avoid misleading currency bundles, and ensure that free progression remains reasonable. I would also avoid paid randomised rewards, as the Moodle reading explains that loot boxes introduce additional transparency, consumer-protection, and age-rating concerns.

## Task 3 — Five Dark-Pattern Risks and Guardrails

- **Grinding and pay-to-skip:** Increasing upgrade costs could make progression excessively slow to encourage coin purchases. **Guardrail:** Balance coin rewards and upgrade costs so players can progress through normal gameplay without unreasonable repetition.

- **Purchase prompts after failure:** The Result screen could pressure players into buying coins immediately after losing. **Guardrail:** Keep purchases optional and accessible through a clearly labelled button, without automatic pop-ups or repeated prompts.

- **Artificial scarcity and countdown timers:** Limited-time coin offers could create pressure to spend quickly. **Guardrail:** Avoid fake countdowns, resetting offers, and misleading claims that digital items are running out.

- **Loot boxes and random rewards:** The coin shop could introduce paid mystery rewards with uncertain value. **Guardrail:** Offer fixed, clearly described purchases instead of paid randomised rewards.

- **Currency obfuscation:** Coin packs and upgrade prices could make it difficult to understand real-money costs. **Guardrail:** Show real-money prices clearly, avoid deliberately mismatched currency bundles, and make purchase costs understandable before confirmation.

## Conclusion

The reading highlights how monetisation can become unethical through time pressure, misleading prices, and deliberately frustrating progression. My aim is to create an economy that encourages replayability while keeping purchases optional, transparent, and fair.

The telemetry events implemented in Week 6 will help me evaluate whether players earn enough coins and whether upgrade costs need adjusting. I would use this information to improve game balance rather than pressure players into spending money.

**Implementation note:** The current project uses a simulated purchase provider. No real-money billing or IAP SDK is implemented.