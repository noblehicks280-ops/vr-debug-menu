# Quick Reference Card

## Controller Cheat Sheet

```
┌─────────────────────────────────────────┐
│         RIGHT CONTROLLER                │
├─────────────────────────────────────────┤
│  INDEX TRIGGER (Top button)             │
│  └─ HOLD = Open/Close Debug Menu        │
│                                         │
│  THUMBSTICK (Stick)                     │
│  └─ Forward/Back/Left/Right = Fly       │
│                                         │
│  GRIP TRIGGER (Side squeeze)            │
│  └─ HOLD = Fly UP                       │
└─────────────────────────────────────────┘

┌─────────────────────────────────────────┐
│         LEFT CONTROLLER                 │
├─────────────────────────────────────────┤
│  GRIP TRIGGER (Side squeeze)            │
│  └─ HOLD = Fly DOWN                     │
└─────────────────────────────────────────┘
```

---

## Testing Sequence

### Starting Fresh
1. Launch app from "Unknown Sources" section
2. HOLD RIGHT TRIGGER → Menu pops up
3. Release trigger → Menu fades away
4. Ready to test!

### Testing Fly Mode
```
1. HOLD RIGHT TRIGGER
   ↓
2. TAP "FLY: OFF" BUTTON → Changes to "FLY: ON"
   ↓
3. RELEASE RIGHT TRIGGER
   ↓
4. Move RIGHT THUMBSTICK forward/back/left/right
   ↓
5. Hold RIGHT GRIP to fly UP
   ↓
6. Hold LEFT GRIP to fly DOWN
```

### Testing Noclip Mode
```
1. HOLD RIGHT TRIGGER
   ↓
2. TAP "NOCLIP: OFF" BUTTON → Changes to "NOCLIP: ON"
   ↓
3. RELEASE RIGHT TRIGGER
   ↓
4. Walk normally (no collision)
   ↓
5. Walk through walls/floors/objects freely
```

### Testing Both Together
```
1. HOLD TRIGGER → Enable both FLY and NOCLIP
2. RELEASE TRIGGER
3. Fly through geometry freely
4. Perfect for level geometry testing
```

### Disabling Features
```
Same process, but tap the button again:
HOLD TRIGGER → TAP "FLY: ON" → Changes to "FLY: OFF" → RELEASE
```

---

## Common Issues & Quick Fixes

| Problem | Solution |
|---------|----------|
| Menu won't appear | Make sure you're holding RIGHT trigger (not left) |
| Fly doesn't work | Check thumbstick responds in system menu first |
| Can't move up/down while flying | Use GRIP triggers, not regular buttons |
| App crashes on launch | Check Console for errors in Unity |
| APK won't install | Enable USB Debugging in Quest Developer settings |
| Button clicks don't register | Make sure Canvas is assigned in script Inspector |

---

## Build & Deploy Checklist

Before building APK:
- [ ] Script attached to GameObject
- [ ] Canvas assigned in Inspector
- [ ] Buttons connected to ToggleFly() and ToggleNoclip()
- [ ] XR Plugin enabled (OpenXR)
- [ ] Android platform selected
- [ ] Package name set (com.yourname.debugmenu)

Before installing APK:
- [ ] USB Debugging enabled on Quest
- [ ] USB cable connected to PC
- [ ] APK file ready in your Builds folder

Installation methods (pick one):
- [ ] Method 1: `adb install DebugMenu.apk`
- [ ] Method 2: Use SideQuest (GUI)
- [ ] Method 3: Copy to Quest via USB & tap

---

## Performance Tips

**Fly Speed Too Slow?**
```csharp
// In VRDebugMenu.cs, find this line:
private float flySpeed = 5f;

// Change to:
private float flySpeed = 10f;  // Faster
```

**Menu Takes Too Long to Appear?**
```csharp
// Find this line:
StartCoroutine(FadeCanvas(menuCanvasGroup, 0f, 1f, 0.2f));

// Change 0.2f to 0.1f for instant, or keep 0.2f for smooth
```

**Want Menu at Different Position?**
- Select DebugMenuCanvas in hierarchy
- In Inspector, adjust Rect Transform position/size
- Move it to corners or edges as needed

---

## File Structure

```
your-project/
├── VRDebugMenu.cs          ← Main script
├── Canvas                  ← UI element (in scene)
│   ├── Fly Button          ← Calls ToggleFly()
│   ├── Noclip Button       ← Calls ToggleNoclip()
│   └── Close Button        ← Optional
├── DebugMenuManager        ← Empty GameObject with script
└── Builds/
    └── DebugMenu.apk       ← Built game (install this)
```

---

## Testing Workflow

### Each Time You Update Code:
```
1. Save VRDebugMenu.cs in Unity
2. File → Build Settings → Build
3. Click same location, rebuild APK
4. adb install -r DebugMenu.apk    (the -r means "replace")
5. App auto-restarts with new code
6. Test changes
```

### Creating Different Builds:
```
Build 1: FlyTest.apk       (test fly only)
Build 2: NoclipTest.apk    (test noclip only)
Build 3: FullTest.apk      (test both)

You can have multiple builds installed at once!
```

---

## Debug Console Output

When testing, watch Unity Console for these messages:

```
✓ "Fly Mode: ENABLED"     = Fly turned on
✓ "Fly Mode: DISABLED"    = Fly turned off
✓ "Noclip Mode: ENABLED"  = Noclip turned on
✓ "Noclip Mode: DISABLED" = Noclip turned off
✗ Any error              = Check the error message
```

To view console from Quest:
1. Connect Quest to PC
2. Open Android Logcat in Unity: Window → TextMesh Pro → Import Logcat
3. Filter for your app name
4. Watch real-time debug messages

---

## Advanced Tweaks

### Add More Features
You can easily add buttons for:
- Teleport to spawn
- Toggle gravity
- Speed multiplier
- Time scale (slow-mo)
- Screenshot function

All follow the same pattern:
```csharp
public void ToggleFeature()
{
    featureEnabled = !featureEnabled;
    Debug.Log("Feature: " + (featureEnabled ? "ENABLED" : "DISABLED"));
}
```

### Customize Menu Layout
- Add sliders for values (speed, scale)
- Add text displays (FPS counter, position)
- Add color coding (red = off, green = on)
- Add toggle icons instead of text buttons

### Keyboard Testing (Editor Only)
Add this in Update() to test in editor without VR:
```csharp
if (Input.GetKeyDown(KeyCode.F))
{
    OpenMenu();
}
if (Input.GetKeyUp(KeyCode.F))
{
    CloseMenu();
}
```

---

## Frequently Asked Questions

**Q: Can I use this in my final game?**
A: No, this is debug-only. Remove it before shipping.

**Q: Will it work on other Quest versions?**
A: Yes, works on Quest 2, 3, Pro - anything with Meta XR plugin.

**Q: Can I add voice controls?**
A: Yes, integrate speech-to-text to call button functions.

**Q: Does it slow down my game?**
A: Only when the menu is open. Negligible impact when closed.

**Q: Can multiple people test at once?**
A: Each Quest runs independently, so yes - each person gets their own menu.

---

## Next Steps

After you get this working:
1. Add more debug features (teleport, spawn testing, etc.)
2. Create level-specific debug modes
3. Add network debugging for multiplayer
4. Integrate screenshot/video capture
5. Create preset test scenes

Good luck! 🚀
