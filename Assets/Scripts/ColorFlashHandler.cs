using System;
using System.Collections;
using UnityEngine;

public class ColorFlashHandler : MonoBehaviour
{
    public event Action OnColorFlashFinished;

    bool isFlashing = false;

    public void ShowFlash(FlashConfiguration flashConfig)
    {
        StartCoroutine(FlashColour(flashConfig));
    }


    IEnumerator FlashColour(FlashConfiguration flashConfig)
    {
        Material displayMaterial = flashConfig.displayMaterial;
        Color originalColour = displayMaterial.color;
        int numberOfFlashes = flashConfig.numberOfFlashes;
        float flashSpeed = flashConfig.flashSpeed;


        if (!isFlashing || !flashConfig.isMainCube)
        {
            isFlashing = true;
            displayMaterial.SetColor("_Color", displayMaterial.color * 3.0f);


            for (int i = 0; i <= numberOfFlashes; i++)
            {
                displayMaterial.SetFloat("_GlowAmountIntensity", 3);
                yield return new WaitForSeconds(flashSpeed);
                displayMaterial.SetFloat("_GlowAmountIntensity", 1);
                yield return new WaitForSeconds(flashSpeed);
            }

            displayMaterial.SetColor("_Color", originalColour);
            isFlashing = false;

            OnColorFlashFinished?.Invoke();

            yield return null;
        }    
       
    }

    public bool CanCubeFlash() 
    {  
        return !isFlashing; 
    }
}
