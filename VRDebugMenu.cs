using UnityEngine;
using OVR;

public class VRDebugMenu : MonoBehaviour
{
    [SerializeField] private OVRInput.Controller rightController = OVRInput.Controller.RTouch;
    [SerializeField] private Canvas debugMenuCanvas;
    [SerializeField] private CanvasGroup menuCanvasGroup;
    
    private bool menuActive = false;
    private bool flyEnabled = false;
    private bool noclipEnabled = false;
    private CharacterController characterController;
    private Vector3 flyVelocity = Vector3.zero;
    private float flySpeed = 5f;
    
    void Start()
    {
        // Get or create canvas for menu
        if (debugMenuCanvas == null)
        {
            debugMenuCanvas = GetComponentInChildren<Canvas>();
        }
        
        // Get canvas group for fade in/out
        if (menuCanvasGroup == null)
        {
            menuCanvasGroup = debugMenuCanvas.GetComponent<CanvasGroup>();
            if (menuCanvasGroup == null)
            {
                menuCanvasGroup = debugMenuCanvas.gameObject.AddComponent<CanvasGroup>();
            }
        }
        
        // Get character controller for noclip
        characterController = GetComponent<CharacterController>();
        
        // Start with menu invisible
        menuCanvasGroup.alpha = 0f;
        debugMenuCanvas.enabled = false;
    }
    
    void Update()
    {
        HandleMenuToggle();
        
        if (menuActive)
        {
            UpdateMenuUI();
        }
        
        if (flyEnabled)
        {
            HandleFlyMovement();
        }
    }
    
    void HandleMenuToggle()
    {
        // Check if right trigger is pressed
        bool triggerPressed = OVRInput.Get(OVRInput.Button.RIndexTrigger, rightController);
        
        if (triggerPressed && !menuActive)
        {
            OpenMenu();
        }
        else if (!triggerPressed && menuActive)
        {
            CloseMenu();
        }
    }
    
    void OpenMenu()
    {
        menuActive = true;
        debugMenuCanvas.enabled = true;
        StartCoroutine(FadeCanvas(menuCanvasGroup, 0f, 1f, 0.2f));
    }
    
    void CloseMenu()
    {
        menuActive = false;
        StartCoroutine(FadeCanvasAndDisable(menuCanvasGroup, 1f, 0f, 0.2f));
    }
    
    void UpdateMenuUI()
    {
        // These methods are called by UI buttons
        // Fly and Noclip toggle buttons will call these
    }
    
    public void ToggleFly()
    {
        flyEnabled = !flyEnabled;
        
        if (flyEnabled)
        {
            Debug.Log("Fly Mode: ENABLED");
            if (characterController != null)
            {
                characterController.enabled = false;
            }
            flyVelocity = Vector3.zero;
        }
        else
        {
            Debug.Log("Fly Mode: DISABLED");
            if (characterController != null)
            {
                characterController.enabled = true;
            }
        }
    }
    
    public void ToggleNoclip()
    {
        noclipEnabled = !noclipEnabled;
        
        if (noclipEnabled)
        {
            Debug.Log("Noclip Mode: ENABLED");
            if (characterController != null)
            {
                characterController.enabled = false;
            }
        }
        else
        {
            Debug.Log("Noclip Mode: DISABLED");
            if (characterController != null)
            {
                characterController.enabled = true;
            }
        }
    }
    
    void HandleFlyMovement()
    {
        // Get thumbstick input for movement direction
        Vector2 thumbstick = OVRInput.Get(OVRInput.Axis2D.RThumbstick, rightController);
        
        // Get head forward direction for forward/backward movement
        Vector3 headForward = Camera.main.transform.forward;
        Vector3 headRight = Camera.main.transform.right;
        Vector3 headUp = Vector3.up; // Keep up as world up, not head up
        
        // Calculate movement direction
        Vector3 moveDirection = (headForward * thumbstick.y + headRight * thumbstick.x).normalized;
        
        // Apply movement
        if (moveDirection.magnitude > 0.1f)
        {
            flyVelocity = moveDirection * flySpeed;
            transform.position += flyVelocity * Time.deltaTime;
        }
        else
        {
            flyVelocity = Vector3.zero;
        }
        
        // Up/Down movement with grip buttons
        if (OVRInput.Get(OVRInput.Button.RHandTrigger, rightController))
        {
            transform.position += Vector3.up * flySpeed * Time.deltaTime;
        }
        if (OVRInput.Get(OVRInput.Button.LHandTrigger, rightController))
        {
            transform.position -= Vector3.up * flySpeed * Time.deltaTime;
        }
    }
    
    System.Collections.IEnumerator FadeCanvas(CanvasGroup canvasGroup, float startAlpha, float endAlpha, float duration)
    {
        float elapsed = 0f;
        canvasGroup.alpha = startAlpha;
        
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, elapsed / duration);
            yield return null;
        }
        
        canvasGroup.alpha = endAlpha;
    }
    
    System.Collections.IEnumerator FadeCanvasAndDisable(CanvasGroup canvasGroup, float startAlpha, float endAlpha, float duration)
    {
        float elapsed = 0f;
        canvasGroup.alpha = startAlpha;
        
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, elapsed / duration);
            yield return null;
        }
        
        canvasGroup.alpha = endAlpha;
        debugMenuCanvas.enabled = false;
    }
}
