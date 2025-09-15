using System;
using UnityEngine;
using System.Collections;

public class ColorFlashHandler : MonoBehaviour
{   
    private bool isFlashing = false;

    public event Action OnColorFlashFinished;

    private IEnumerator FlashColour(FlashConfiguration flashConfig)
    {
        Material displayMaterial = flashConfig.displayMaterial;
        Color originalColour = displayMaterial.color;
        int numberOfFlashes = flashConfig.numberOfFlashes;
        float flashSpeed = flashConfig.flashSpeed;


        if (!isFlashing || !flashConfig.isMainCube)
        {
            isFlashing = true;
            

            for (int i = 0; i <= numberOfFlashes; i++)
            {
                displayMaterial.SetColor("_Color", displayMaterial.color * 1.5f);
                yield return new WaitForSeconds(flashSpeed);
                displayMaterial.SetColor("_Color", originalColour);
                yield return new WaitForSeconds(flashSpeed);
            }

            displayMaterial.SetColor("_Color", originalColour);
            isFlashing = false;

            OnColorFlashFinished?.Invoke();

            yield return null;
        }    
       
    }

    public void ShowFlash(FlashConfiguration flashConfig)
    {
        StartCoroutine(FlashColour(flashConfig));
    }

    public bool CanCubeFlash() 
    {  
        return !isFlashing; 
    }
}
