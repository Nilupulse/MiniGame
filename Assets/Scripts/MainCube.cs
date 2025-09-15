
using System.Linq;
using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;

public class MainCube : CubeBase, ICube
{
    private List<SubCube> subCubes;

    private void Start()
    {
        subCubes = new List<SubCube>();
        subCubes.AddRange(FindObjectsByType<SubCube>(FindObjectsSortMode.None).ToList());

        SetUpColour();
        AddListeners();
    }

    private void AddListeners()
    {     
        flashHandler.OnColorFlashFinished += ResetDisplay;
        snapCubes.OnCompleteUnsnapAllCubes += ResetDisplay;
        inputHandler.OnMainCubeRightClicked += ActivateSubCubeFlash;
        snapCubes.OnSnapAllCubesStart += ChangeSubCubesDisplayColor;

        foreach (SubCube subCube in subCubes)
        {
            subCube.OnSubClicked += SetupCubeFlashConfig;
        }
    }

    private void OnDisable()
    {       
        flashHandler.OnColorFlashFinished -= ResetDisplay;
        snapCubes.OnCompleteUnsnapAllCubes -= ResetDisplay;
        inputHandler.OnMainCubeRightClicked -= ActivateSubCubeFlash;
        snapCubes.OnSnapAllCubesStart -= ChangeSubCubesDisplayColor;

        foreach (SubCube subCube in subCubes)
        {
            subCube.OnSubClicked -= SetupCubeFlashConfig;
        }
    }

    /// <summary>
    /// Shake and Rotate the main Cube.
    /// </summary>
    private void ShakeAndRotate()
    {
        transform.DOShakeRotation(flashConfig.numberOfFlashes, 20, 10);
    }

    /// <summary>
    /// Triggers the cube’s flash effect if flashing is currently allowed.
    /// </summary>
    public void FlashCube()
    {
        if (flashHandler.CanCubeFlash())
        {
            flashHandler.ShowFlash(flashConfig);
        }        
    }

    /// <summary>
    /// Sets the display material color used for the flash effect, then immediately
    /// triggers a flash using the updated configuration.
    /// </summary>
    /// <param name="subCubeColor">The color to apply to flashConfig.displayMaterial</param>
    public void SetupCubeFlashConfig(Color subCubeColor)
    {
        flashConfig.displayMaterial.color = subCubeColor;
        FlashCube();
    }

    /// <summary>
    /// Triggers a flash on all sub-cubes using the main cube’s display colour,
    /// then applies the shake-and-rotate effect.
    /// </summary>
    public void ActivateSubCubeFlash()
    {
        foreach (SubCube subCube in subCubes)
        {
            subCube.FlashMainCubeColor(displayColour);
        }

        ShakeAndRotate();
    }

    /// <summary>
    /// Updates the display colour of all sub-cubes to the main displayColour
    /// </summary>
    public void ChangeSubCubesDisplayColor()
    {
        foreach (SubCube subCube in subCubes)
        {
            subCube.ChangeDisplayColor(displayColour);
        }
    }    

    public FlashConfiguration GetFlashConfig()
    {
        return flashConfig;
    }
}
