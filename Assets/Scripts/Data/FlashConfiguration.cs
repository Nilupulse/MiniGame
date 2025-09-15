using UnityEngine;

[CreateAssetMenu(fileName = "FlashConfiguration", menuName = "ScriptableObjects/FlashConfiguration", order = 0)]
public class FlashConfiguration : ScriptableObject
{
    public int numberOfFlashes;
    [Tooltip("Flash Speed: Higher values = slower flash, lower values = faster flash.")]
    [Range(3f, .1f)]
    public float flashSpeed;
    public Material displayMaterial;
    public bool isMainCube;
}
