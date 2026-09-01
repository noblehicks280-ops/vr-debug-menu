# How It All Works - Simple Breakdown

## The Menu System (Trigger-Based)

### What Happens When You Hold Right Trigger:
1. **VRDebugMenu script detects** your right index trigger is pressed
2. **Canvas appears** with a smooth fade-in animation (200ms)
3. **Menu stays visible** as long as you're holding the trigger
4. You can tap the Fly or Noclip buttons while holding it

### What Happens When You Release Right Trigger:
1. **Script detects** trigger was released
2. **Menu fades out** smoothly (200ms)
3. **Canvas disappears** completely
4. You're back to normal gameplay

---

## Fly Mode Explained

### When You Enable Fly:
```
1. Character Controller gets DISABLED
   → This turns off gravity and collision
   → You're now "flying" freely

2. Script waits for your thumbstick input
   → Right thumbstick on your controller
   
3. You move the thumbstick:
   → Forward/Backward = Move relative to your head direction
   → Left/Right = Strafe left/right
   
4. Grip buttons control height:
   → Left Grip (L trigger) = Move DOWN
   → Right Grip (R trigger) = Move UP
```

### The Code Behind It:
- Gets your head position (where you're looking)
- Gets thumbstick direction (where you're aiming)
- Combines them to move you smoothly
- Speed is set to 5 units per second (adjustable)

---

## Noclip Mode Explained

### What Noclip Does:
```
Disables the Character Controller
↓
Removes all collision detection
↓
You can walk through walls, floors, and objects
↓
Useful for testing level geometry without obstacles
```

### Can You Use Fly + Noclip Together?
**YES!** Both can be enabled at the same time:
- Fly gives you free movement in all directions
- Noclip removes collision so you pass through geometry
- Combined = Ultimate testing mode

---

## The APK & Installation Process

### What is an APK?
APK = **Android Package Kit**
- It's like a .exe file for Android/Meta Quest
- Contains your entire game + all scripts + assets
- Ready to install on your headset

### Why You Need Platform Tools or SideQuest:
The Quest can't install APKs directly from the internet for security reasons. You need a "bridge" to transfer it:

**Option A: adb (Android Debug Bridge)**
```
Your PC → USB Cable → Quest
adb install MyGame.apk → Game installed!
```

**Option B: SideQuest**
```
SideQuest (GUI tool) → USB Cable → Quest
Click "Install APK" → Game installed!
```

**Option C: Manual (What you mentioned)**
```
Copy APK to Quest via USB → File Manager → Tap APK → Package Installer
```

All three methods do the same thing, just different interfaces.

---

## Building the APK Step-by-Step

### In Unity:
```
1. File > Build Settings
2. Switch to Android platform
3. File > Build
4. Choose folder, name it "DebugMenu.apk"
5. Wait 5-15 minutes (depends on project size)
6. You get a DebugMenu.apk file
```

### On Your PC:
```
You now have: DebugMenu.apk (ready to install)
```

### On Your Quest:
```
Either:
  - Use adb command (requires Platform Tools)
  - Use SideQuest (easiest, no command line)
  - Copy to Quest and tap it (slowest)
```

---

## Input Mapping (Controller Buttons)

```
RIGHT CONTROLLER:
├─ INDEX TRIGGER (Right Trigger)
│  └─ HOLD = Open/Close menu
│
├─ RIGHT THUMBSTICK
│  └─ Fly forward/back/strafe when flying
│
├─ GRIP TRIGGER (Squeeze side)
│  └─ Hold = Fly UP
│
LEFT CONTROLLER:
└─ GRIP TRIGGER (Squeeze side)
   └─ Hold = Fly DOWN
```

---

## What the Script Actually Does (Behind the Scenes)

### Update Loop (Every Frame):
```csharp
1. Check if right trigger is held
   ├─ YES → Open menu (if not already open)
   └─ NO → Close menu (if currently open)

2. If menu is open:
   └─ Display canvas with buttons

3. If fly is enabled:
   ├─ Read thumbstick position
   ├─ Get your head's forward direction
   ├─ Calculate movement direction
   ├─ Check grip buttons for up/down
   └─ Move your position smoothly
```

### When You Click a Button:
```
Button OnClick Event
↓
Calls ToggleFly() or ToggleNoclip()
↓
Disables/Enables Character Controller
↓
Logs to Console (you see "Fly Mode: ENABLED" etc.)
↓
You're now in the selected mode
```

---

## Smooth Animations

The menu doesn't just pop in/out - it **fades**:

```
Release Trigger:
  Alpha: 1.0 (fully visible)
     ↓ (over 0.2 seconds)
  Alpha: 0.5 (half visible)
     ↓ (over 0.2 seconds)
  Alpha: 0.0 (invisible)
     ↓
  Canvas Disabled (stops rendering)
```

Same thing in reverse when opening.

---

## Example Workflow

### Testing Your Game:
```
1. Launch app on Quest
2. HOLD RIGHT TRIGGER → Menu appears
3. TAP "FLY" BUTTON → Fly mode enabled
4. RELEASE TRIGGER → Menu disappears
5. Use thumbstick to fly around your level
6. HOLD TRIGGER AGAIN → Menu reappears
7. TAP "FLY" BUTTON → Fly mode disabled
8. RELEASE TRIGGER → Back to normal gameplay
```

### Testing a Specific Area:
```
1. HOLD TRIGGER → Open menu
2. Enable FLY → Release trigger
3. Fly to the area you want to test
4. Enable NOCLIP (hold trigger, tap button, release)
5. Walk through objects to test geometry
6. Toggle features as needed
```

---

## Key Differences: Script vs. Built Game

### In Editor (Before Building APK):
- You can use keyboard to test
- No VR controllers
- Physics work normally
- Fast iteration

### On Quest (After APK Install):
- Uses actual VR controllers
- Full 3D VR experience
- All your game logic works
- Tests real performance on hardware

---

## Why This Setup is Good for Debugging

✅ Quick access (just hold trigger)
✅ Non-intrusive (disappears when released)
✅ Multiple test modes (fly + noclip)
✅ Real hardware testing
✅ Easy to modify/add features
✅ Can test geometry without collision

---

## Next Time You Build

After you make changes to your script:
```
1. Save in Unity
2. File > Build Settings > Build
3. Choose same APK file (it overwrites)
4. Uninstall old app from Quest
5. Install new APK
6. Test new features
```

That's it! Your debug menu is now ready to go! 🎮
