using UnityEngine;

public abstract class CubeBase : MonoBehaviour
{
    [Header("Display Materials")]
    [SerializeField] protected Material displayMaterial;
    [SerializeField] protected Material letterMaterial;
    [Header("Display Colors")]
    [SerializeField] protected Color letterColour;
    [SerializeField] protected Color displayColour;
    [Header("Flash Configuration")]
    [SerializeField] protected FlashConfiguration flashConfig;
    [Header("Handlers")]
    [SerializeField] protected SnapCubes snapCubes;
    [SerializeField] protected InputHandler inputHandler;
    [SerializeField] protected ColorFlashHandler flashHandler;

    public void ResetDisplay()
    {
        displayMaterial.color = displayColour;
    }

    public void SetUpColour()
    {
        letterMaterial.color = letterColour;
        displayMaterial.color = displayColour;        
    }
}
