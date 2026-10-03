# Check and Finding/ Fix

| Test | Result |
| -------- | -------- |
| One-handed reach: every control reachable with the thumb | Game playable with one thumb/hand |
| Smallest button at least 48 dp including padding (measure against a 48 dp reference square in the Device Simulator) | Smallest button is at least 48 dp or greater than 48 dp |
| Android Settings > Display > Display size and text at maximum: HUD still inside the safe area | Text within safe area, with max text size |
| Developer options > Simulate colour space > Monochromacy: every game state still readable | Game is currently grey boxes, readable with monochromancy |
| Volume at zero: the game still tells you what happened | Audio/volume controls are not implemented yet. Fix: Add audio feedback/volume control if time permits. Status: Cuts list. |
| Text contrast 4.5:1 (use any online contrast checker with your colours) | Text still visible with contrast at 4.5:1 |
| Motion or screen shake behind a toggle (add the toggle now even if it only stores a value) | Status: Cuts list. |
| No timed tap without an alternative or a slower mode | No timed taps required with an unnecessarily short time limit |
| Haptics off: nothing is lost | With haptics off, game is still playable with nothing lost |
| 60 seconds of silent observation: write down the first thing your neighbour got wrong. | Game is still not complete, no "incorrect" movements |
