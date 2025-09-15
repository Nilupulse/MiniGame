using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SnapCubes))]
public class SnapCubeCustomEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        SnapCubes snapCubes = (SnapCubes)target;

        GUILayout.Label("Snap Control Buttons");

        if (GUILayout.Button("Snap All Cubes"))
        {
            snapCubes.SnapAllCube();
        }

        if (GUILayout.Button("Unsnap All Cubes"))
        {
            snapCubes.UnsnapAllCubes();
        }

    }
}
