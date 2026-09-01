# VR Debug Menu - Setup & Installation Guide

## Part 1: Unity Setup

### Step 1: Create the Canvas UI
1. In your Unity scene, create a new **Canvas** (Right-click > UI > Canvas)
2. Rename it to `DebugMenuCanvas`
3. Set the Canvas to **Screen Space - Overlay** (so it renders on top)
4. Make it smaller (scale down or adjust Rect Transform) so it doesn't take up the whole screen

### Step 2: Add Menu Buttons
Inside the Canvas, create these buttons:
- **Fly Button** - Text: "FLY: OFF"
- **Noclip Button** - Text: "NOCLIP: OFF"
- **Close Button** - Text: "X" (optional)

For each button:
1. Right-click Canvas > UI > Button - TextMeshPro
2. Rename to appropriate name
3. Adjust positioning and size in Rect Transform

### Step 3: Attach the Script
1. Create an empty GameObject and name it `DebugMenuManager`
2. Drag the `VRDebugMenu.cs` script onto it
3. In the Inspector:
   - Drag `DebugMenuCanvas` into the "Debug Menu Canvas" field
   - The script will auto-find the CanvasGroup

### Step 4: Connect Buttons
1. Select your **Fly Button**
2. In the Inspector, find the **Button** component
3. Under **On Click ()**, click the **+** button
4. Drag `DebugMenuManager` into the object field
5. From the dropdown, select `VRDebugMenu > ToggleFly()`
6. Repeat for **Noclip Button** with `ToggleNoclip()`

---

## Part 2: How It Works

### Right Trigger Controls
- **Hold Right Trigger**: Menu appears and stays visible
- **Release Right Trigger**: Menu fades out and disappears
- The menu uses smooth fade animation (0.2 seconds)

### Fly Mode
- **Enabled/Disabled**: Toggle with the Fly button
- **Movement**: Use right thumbstick to move forward/back/left/right
- **Up/Down**: Use left and right grip buttons (LH trigger = down, RH trigger = up)
- **Speed**: Currently set to 5 units/second (adjustable in script)
- **Camera-relative**: Movement follows your head direction

### Noclip Mode
- **Enabled/Disabled**: Toggle with the Noclip button
- **Effect**: Disables the character controller so you pass through walls
- **Works with**: Fly mode or regular movement

---

## Part 3: Building & Installing APK

### Step 1: Configure Build Settings
1. Go to **File > Build Settings**
2. Switch platform to **Android**
3. Click **Player Settings**
4. Under **Other Settings**:
   - Set **Package Name**: `com.yourname.debugmenu`
   - Set **Minimum API Level**: 29 (Meta Quest requirement)
   - Enable **Vulkan** graphics API
   - Set **Target API Level**: 33 or higher

### Step 2: Configure VR Settings
1. In Player Settings, find **XR Plug-in Management**
2. Enable **OpenXR**
3. Add **Meta Quest** as a supported device

### Step 3: Build APK
1. **File > Build Settings**
2. Click **Build**
3. Choose a folder (e.g., `Builds/`)
4. Name it `DebugMenu.apk`
5. Wait for build to complete

---

## Part 4: Installing on Meta Quest

### Method 1: Using Android SDK Platform Tools (Easiest)

**What you need:**
- Android SDK Platform Tools (adb)
- USB cable
- Meta Quest headset

**Installation:**
1. Download [Android SDK Platform Tools](https://developer.android.com/studio/releases/platform-tools)
2. Extract it to a folder
3. On your Quest:
   - Enable **Developer Mode**: Settings > About > Tap "Build Number" 7 times
   - Enable **USB Debugging**: Settings > Developer > USB Debugging ON
4. Connect Quest to PC via USB cable
5. Accept "Allow USB Debugging" prompt on headset
6. Open Command Prompt/Terminal in the Platform Tools folder
7. Run:
   ```
   adb install path/to/DebugMenu.apk
   ```
8. Wait for installation to complete
9. App appears in your Quest app library under "Unknown Sources"

### Method 2: Using SideQuest (Even Easier GUI)

1. Download [SideQuest](https://sidequestvr.com/)
2. Enable Developer Mode on Quest (same as above)
3. Connect Quest via USB
4. Open SideQuest
5. Click **"Install APK file from folder"**
6. Select your `DebugMenu.apk`
7. Wait for installation

### Method 3: Using Package Installer (What you mentioned)

1. Copy APK to your Quest storage via USB
2. On Quest, open **Astro's File Explorer** or **Files** app
3. Navigate to Downloads folder
4. Find your APK file
5. Tap it → Select "Package Installer"
6. Follow prompts to install

---

## Part 5: Launching the Debug Menu

1. On your Quest, go to **Library**
2. Filter to **Unknown Sources** (dropdown)
3. Find your app and tap to launch
4. **Hold down Right Trigger** to open the menu
5. **Tap Fly or Noclip buttons** to toggle features
6. **Release Right Trigger** to close the menu

---

## Part 6: Adjusting Settings

### Change Fly Speed
In `VRDebugMenu.cs`, find this line:
```csharp
private float flySpeed = 5f;
```
Change `5f` to a higher/lower number (higher = faster)

### Change Menu Fade Speed
Find this line:
```csharp
StartCoroutine(FadeCanvas(menuCanvasGroup, 0f, 1f, 0.2f));
```
Change `0.2f` to a different time in seconds (0.2f = 200ms)

### Customize Button Text
On each button's TextMeshPro component, change the text in the Inspector

---

## Troubleshooting

**"APK won't install"**
- Make sure USB Debugging is ON
- Try using SideQuest instead
- Verify minimum API level is 29+

**"App crashes on launch"**
- Check Console for errors
- Make sure OVRInput is imported
- Verify XR Plugin is enabled

**"Menu doesn't appear"**
- Check that Canvas is assigned in Inspector
- Make sure Right Trigger input is working (test in other apps)
- Verify buttons are connected to correct functions

**"Fly mode doesn't work"**
- Make sure Character Controller exists in scene
- Check thumbstick is responding (test in system menu)
- Verify script has access to Camera.main

---

## Next Steps

- Add more toggles (Teleport, Speed multiplier, etc.)
- Create proper UI with sliders
- Add keyboard shortcuts for testing in editor
- Create a separate debug build configuration
