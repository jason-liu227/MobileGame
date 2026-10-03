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