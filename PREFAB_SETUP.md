# VR Debug Menu - Pre-Built Prefab Setup

## What You Get

This prefab includes EVERYTHING pre-configured:
- ✅ Canvas already created and styled
- ✅ Fly button ready to go
- ✅ Noclip button ready to go
- ✅ Close button
- ✅ Script already attached
- ✅ Buttons already connected
- ✅ Text colors and styling done

**You literally just drag it into your scene and it works.**

---

## How to Use the Prefab

### Step 1: Download/Copy the Prefab
The prefab files are in this repo:
- `DebugMenuPrefab.prefab` - The complete pre-built menu
- `VRDebugMenuUI.cs` - The script (already in prefab)

### Step 2: Drag Into Your Scene
1. In Unity, go to your project folder
2. Navigate to `Assets/Prefabs/` (or wherever you put it)
3. Find `DebugMenuPrefab`
4. Drag it into your scene hierarchy
5. Done! 🎉

### Step 3: Verify It Works
1. Press Play in editor
2. Simulate trigger press (or use keyboard 'F' key in editor)
3. You should see the menu appear with buttons
4. Click the buttons to test fly/noclip

---

## What's Already Connected

```
DebugMenuPrefab (GameObject)
├── Script: VRDebugMenuUI (already attached)
├── Canvas
│   ├── Fly Button
│   │   └── Text: "FLY: OFF"
│   │   └── OnClick → VRDebugMenuUI.ToggleFly()
│   ├── Noclip Button
│   │   └── Text: "NOCLIP: OFF"
│   │   └── OnClick → VRDebugMenuUI.ToggleNoclip()
│   └── Close Button (X)
│       └── Optional visual button
└── CanvasGroup (for fade effects)
```

---

## First-Time Setup Checklist

After dragging the prefab into your scene:

- [ ] **Verify Canvas is visible** - You should see it in the scene view
- [ ] **Check Character Controller** - Make sure your player has a CharacterController component
- [ ] **Test in Play mode** - Press Play and try opening the menu
- [ ] **Adjust menu position** - If it's in the wrong spot, select the Canvas in hierarchy and drag it in the scene view

---

## Customizing the Pre-Built Menu

### Change Button Text Color
1. Select `DebugMenuPrefab` in hierarchy
2. Expand it to find `Fly Button`
3. Select the Text component
4. In Inspector, change the color under TextMeshProUGUI > Color

### Change Menu Size
1. Select the Canvas (inside the prefab)
2. In Inspector, find Rect Transform
3. Adjust Width and Height

### Change Menu Position
1. Select the Canvas
2. Click and drag in the Scene view to reposition
3. Or use Rect Transform to set exact position

### Change Fly Speed
1. Select `DebugMenuPrefab`
2. In Inspector, find `VRDebugMenuUI` script component
3. Change `Fly Speed` value (default is 5)

---

## File Structure (What You Need)

```
Your Project/
├── Assets/
│   ├── Prefabs/
│   │   └── DebugMenuPrefab.prefab    ← Drag this into your scene
│   ├── Scripts/
│   │   └── VRDebugMenuUI.cs          ← Already in prefab
│   └── Scenes/
│       └── YourGameScene.unity        ← Where you drag the prefab
```

---

## If Something Doesn't Work

### Menu won't appear when trigger is held
- Make sure the Canvas is part of the prefab
- Check that `menuCanvasGroup` is assigned in Inspector
- Verify VRDebugMenuUI script is on the root prefab object

### Buttons don't respond
- The prefab has them pre-connected, but verify:
  - Select Fly Button → Check Button component → On Click event should show `ToggleFly()`
  - Select Noclip Button → Check Button component → On Click event should show `ToggleNoclip()`

### Fly mode doesn't work
- Character Controller must exist in your scene
- Script tries to find it automatically, but make sure it's there

### Text doesn't update
- Make sure the Text objects have TextMeshProUGUI components
- They're already configured in the prefab, but double-check if you edit it

---

## Building the APK With Prefab

The process is exactly the same:

1. Make sure prefab is in your scene
2. File > Build Settings > Switch to Android
3. Add your scene to Build Scenes
4. File > Build
5. Wait for APK to build
6. Install on Quest using adb or SideQuest

The prefab automatically works on Quest - no changes needed!

---

## Advanced: Modifying the Prefab

If you want to customize the prefab permanently:

1. Select `DebugMenuPrefab` in your scene
2. Make changes to the UI (colors, size, text, etc.)
3. Right-click prefab in Project folder
4. Select "Overwrite" to save changes
5. All future instances will use the new design

---

## Key Differences: Prefab vs Manual Setup

| Task | Manual | Prefab |
|------|--------|--------|
| Create Canvas | You | Already done ✓ |
| Add Buttons | You | Already done ✓ |
| Style UI | You | Already done ✓ |
| Attach Script | You | Already done ✓ |
| Connect Buttons | You | Already done ✓ |
| Test | 15 min | Instant ✓ |

**TL;DR: Prefab saves you like 15 minutes of setup. Just drag and play!**

---

## Next Steps After Setup

Once it's working in your scene:

1. **Test fly mode** - Hold trigger, tap Fly button, move thumbstick
2. **Test noclip mode** - Hold trigger, tap Noclip button, walk through walls
3. **Build to APK** - Follow the build steps in SETUP_GUIDE.md
4. **Install on Quest** - Use adb or SideQuest
5. **Debug your game** - Use the menu while testing!

---

## Tips

- You can have the prefab in multiple scenes - just drag it to each one
- The prefab works in VR and in editor (editor uses keyboard 'F' key)
- Remove the prefab before shipping your game
- Make a backup copy if you're going to heavily modify it

---

That's it! The prefab is literally plug-and-play. 🎮✨
