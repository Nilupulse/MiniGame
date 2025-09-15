using System;
using UnityEngine;

public class SubCube : CubeBase, ICube
{
    public event Action<Color> OnSubClicked;
    
    private void Awake()
    {
        SetUpColour();
        AddListeners();
    }

    private void AddListeners()
    {
        flashHandler.OnColorFlashFinished += ResetDisplay;
        snapCubes.OnCompleteUnsnapAllCubes += ResetDisplay;
    }

    private void OnDisable()
    {
        flashHandler.OnColorFlashFinished -= ResetDisplay;
        snapCubes.OnCompleteUnsnapAllCubes -= ResetDisplay;
    }

    /// <summary>
    /// Triggers the cube’s flash effect if flashing is currently allowed.
    /// </summary>
    public void FlashCube()
    {
        if (flashHandler.CanCubeFlash())
        {
            OnSubClicked?.Invoke(displayColour);
        }        
    }

    /// <summary>
    /// Triggers the cube’s flash effect if flashing is currently allowed
    /// with the main cube color.
    /// </summary>
    public void FlashMainCubeColor(Color mainCubeColor)
    {

        ChangeDisplayColor(mainCubeColor);
        flashHandler.ShowFlash(flashConfig);
    }

    /// <summary>
    /// Change the display color to the main cube display color.
    /// </summary>
    /// <param name="mainCubeColor"></param>
    public void ChangeDisplayColor(Color mainCubeColor)
    {
        displayMaterial.color = mainCubeColor;
    }

    public FlashConfiguration GetFlashConfig()
    {
        return flashConfig;
    }
}
