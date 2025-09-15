using System;
using UnityEngine;

public class InputHandler : MonoBehaviour
{     
    [SerializeField] private Camera mainCamera;
    [SerializeField] private SnapCubes snapCubes;

    private bool canInteract;

    public event Action OnMainCubeRightClicked;

    private void Start()
    {
        mainCamera = Camera.main;
        canInteract = true;
        AddListeners();
    }

    private void AddListeners()
    {
        snapCubes.OnSnapAllCubesStart += DisableInteraction;
        snapCubes.OnCompleteUnsnapAllCubes += EnableInteraction;
    }

    private void OnDisable()
    {
        snapCubes.OnSnapAllCubesStart -= DisableInteraction;
        snapCubes.OnCompleteUnsnapAllCubes -= EnableInteraction;
    }

    private void EnableInteraction() => canInteract = true;   

    private void DisableInteraction() => canInteract = false;

    /// <summary>
    /// Frame input handling:
    /// - Detects a left/right mouse click
    /// - Finds the 2D object under the cursor
    /// - Left: flashes the clicked cube
    /// - Right: if the cube is the main cube, raises the right-click event
    /// Exits early if no click occurred or interaction is disabled.
    /// </summary>
    private void Update()
    {
        // Read click input once; skip work if no button was pressed this frame.
        MouseButton mouseButton = GetMouseInput();
        if (mouseButton == MouseButton.None) return;

        // Convert cursor position to world space and query what lies under it.
        Vector3 worldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos = new Vector2(worldPos.x, worldPos.y);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

        // Continue only if interaction is allowed and something was actually hit.
        if (canInteract && hit.collider != null)
        {
            ICube cube;

            // Try to get the ICube component from the hit object; bail if absent.
            if (!hit.collider.gameObject.TryGetComponent<ICube>(out cube)) return;

            // Left click: trigger the cube's flash effect.
            if (mouseButton == MouseButton.Left)
            {
                cube.FlashCube();
                return;
            }

            // Right click on the main cube: raise the right-click event.
            if (mouseButton == MouseButton.Right && IsClickOnMainCube(cube))
            {
                OnMainCubeRightClicked?.Invoke();
            }
        }   
    }

    /// <summary>
    /// Determines whether the specified cube is the main cube.
    /// </summary>
    /// <param name="cube"></param>
    /// <returns>true when right click on main else return false</returns>
    private bool IsClickOnMainCube(ICube cube)
    {
        return cube.GetFlashConfig().isMainCube;
    }

    /// <summary>
    /// Returns which mouse button was pressed during the current frame.
    /// </summary>
    /// <returns>MouseButton.Left or MouseButton.Right if pressed this frame
    /// otherwise MouseButton.None</returns>
    private MouseButton GetMouseInput()
    {
        if (Input.GetMouseButtonDown(0)) return MouseButton.Left;
        if (Input.GetMouseButtonDown(1)) return MouseButton.Right;
        return MouseButton.None;
    }
}
