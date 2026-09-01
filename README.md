# VR Debug Menu for Meta Quest

A complete debugging system for Meta Quest VR games built in Unity. Hold your right trigger to open/close a debug menu with fly mode and noclip features for testing.

## Features

✨ **Trigger-Activated Menu**
- Hold right index trigger to open
- Release to close with smooth fade animation
- Non-intrusive, stays out of the way

🛸 **Fly Mode**
- Full 6-DOF movement (up/down/forward/back/strafe)
- Camera-relative controls using right thumbstick
- Grip buttons for vertical movement
- Adjustable flight speed

🔓 **Noclip Mode**
- Walk through walls and geometry
- Perfect for testing level design without collision
- Works independently or combined with fly mode

🎮 **VR-Native Controls**
- Full Meta Quest controller support
- No keyboard required
- Designed for VR workflow

📦 **Easy Deployment**
- Builds to APK for Meta Quest installation
- Works with adb, SideQuest, or manual installation
- Debug-only (remove before shipping)

---

## Quick Start

### 1. Add to Your Project
```
1. Copy VRDebugMenu.cs to your Assets folder
2. Create a Canvas in your scene
3. Add buttons for Fly and Noclip
4. Attach VRDebugMenu script to an empty GameObject
5. Wire up the buttons in the Inspector
```

### 2. Build & Deploy
```
1. File > Build Settings > Switch to Android
2. File > Build > Generate APK
3. Install via adb: adb install DebugMenu.apk
   OR use SideQuest for easier GUI installation
```

### 3. Test
```
1. Launch on your Quest headset
2. Hold RIGHT TRIGGER to open menu
3. Tap buttons to toggle features
4. Release trigger to close menu
```

---

## Documentation

- **[SETUP_GUIDE.md](SETUP_GUIDE.md)** - Step-by-step Unity setup and APK installation
- **[HOW_IT_WORKS.md](HOW_IT_WORKS.md)** - Detailed explanation of all systems
- **[QUICK_REFERENCE.md](QUICK_REFERENCE.md)** - Cheat sheet and testing workflow

---

## Controller Layout

```
RIGHT CONTROLLER:
  Index Trigger     → Hold to open/close menu
  Thumbstick        → Fly direction (forward/back/strafe)
  Grip Trigger      → Fly UP

LEFT CONTROLLER:
  Grip Trigger      → Fly DOWN
```

---

## Requirements

- Unity 2020.3+ (with OVR Plugin)
- Meta Quest 2 or newer
- Android SDK (for building APK)
- USB cable (for installation)

---

## Installation Methods

### Method 1: Using adb (Command Line)
```bash
# Download Android SDK Platform Tools
# Connect Quest via USB and enable USB Debugging
adb install DebugMenu.apk
```

### Method 2: Using SideQuest (GUI - Easiest)
```
1. Download SideQuest
2. Connect Quest via USB
3. Click "Install APK file from folder"
4. Select DebugMenu.apk
5. Done!
```

### Method 3: Manual (On-Headset)
```
1. Copy APK to Quest via USB
2. Open File Manager on Quest
3. Find APK and tap it
4. Select "Package Installer"
5. Confirm installation
```

---

## How It Works

### Menu System
The debug menu uses VR trigger input to toggle visibility:
- **Hold** right index trigger → Menu appears with fade-in
- **Release** trigger → Menu fades out
- Menu stays responsive while held
- Smooth 200ms animations

### Fly Mode
Disables the character controller and enables 6-DOF movement:
- Right thumbstick controls horizontal direction (relative to head)
- Left/Right grip buttons control vertical movement
- Movement speed is 5 units/second (adjustable)
- Works with noclip for complete freedom

### Noclip Mode
Disables collision detection:
- Character controller is disabled
- Walk through any geometry
- Useful for testing level layouts
- Can be combined with fly mode

---

## Customization

### Change Fly Speed
Edit `VRDebugMenu.cs`:
```csharp
private float flySpeed = 5f;  // Change this value
```

### Change Menu Fade Speed
```csharp
StartCoroutine(FadeCanvas(menuCanvasGroup, 0f, 1f, 0.2f));
//                                                    ^^^
//                                    Change this time in seconds
```

### Add More Features
Create new public methods following this pattern:
```csharp
public void ToggleMyFeature()
{
    featureEnabled = !featureEnabled;
    Debug.Log("Feature: " + (featureEnabled ? "ENABLED" : "DISABLED"));
}
```

Then connect them to new buttons in the Canvas.

---

## Troubleshooting

**Menu won't appear**
- Make sure you're holding the RIGHT trigger (not left)
- Verify Canvas is assigned in the Inspector
- Check that the script is attached to a GameObject in the scene

**Fly doesn't work**
- Verify thumbstick responds in Quest system menu
- Make sure Character Controller exists in your scene
- Check that fly mode is actually enabled (button should show "FLY: ON")

**APK won't install**
- Enable USB Debugging on Quest: Settings > Developer > USB Debugging
- Use SideQuest instead if adb isn't working
- Make sure minimum API level is 29+

**App crashes on startup**
- Check Unity Console for error messages
- Verify XR Plugin Management is enabled
- Make sure OVRInput namespace is available

---

## Performance

- Menu system: Negligible impact (only renders when open)
- Fly mode: Very lightweight (simple position updates)
- Noclip mode: Zero overhead (just disables a component)
- Recommended to remove before shipping game

---

## Development Workflow

### Iterating Locally
```
1. Make changes to VRDebugMenu.cs
2. Save in Unity
3. File > Build Settings > Build
4. Click same location to rebuild APK
5. adb install -r DebugMenu.apk    (-r = replace existing)
6. Test on Quest
```

### Creating Test Builds
Keep multiple APK versions:
- `DebugMenu_FlyTest.apk`
- `DebugMenu_NoclipTest.apk`
- `DebugMenu_Combined.apk`

Each can be installed simultaneously for comparison testing.

---

## Advanced Usage

### Keyboard Testing (Editor Only)
Add this to `Update()` to test in the editor:
```csharp
if (Input.GetKeyDown(KeyCode.F))
    OpenMenu();
if (Input.GetKeyUp(KeyCode.F))
    CloseMenu();
```

### Adding Teleportation
```csharp
public void TeleportToSpawn()
{
    transform.position = spawnPoint.position;
}
```

### Adding FPS Counter
```csharp
private Text fpsText;

void Update()
{
    fpsText.text = "FPS: " + (1f / Time.deltaTime).ToString("F0");
}
```

---

## File Structure

```
your-project/
├── Assets/
│   └── VRDebugMenu.cs          ← Main controller script
├── Scenes/
│   └── YourScene.unity          ← Your scene with Canvas
├── Builds/
│   └── DebugMenu.apk            ← Built for Quest
├── README.md
├── SETUP_GUIDE.md
├── HOW_IT_WORKS.md
└── QUICK_REFERENCE.md
```

---

## Removing Before Shipping

Before releasing your game:
1. Delete or disable the Canvas
2. Remove VRDebugMenu.cs from project
3. Remove any debug scene references
4. Build fresh APK without debug code
5. Test on actual Quest hardware

---

## Next Steps

- Add more debug features (teleport, spawn testing, time scale)
- Create level-specific debug modes
- Integrate screenshot/video capture
- Add network debugging for multiplayer
- Create custom debug hotspots

---

## License

Free to use and modify for your projects.

---

## Support

For detailed setup instructions, see **SETUP_GUIDE.md**
For technical explanations, see **HOW_IT_WORKS.md**
For quick testing, see **QUICK_REFERENCE.md**

Happy debugging! 🎮✨
