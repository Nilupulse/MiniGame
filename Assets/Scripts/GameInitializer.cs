using DG.Tweening;
using System.Collections;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    [SerializeField] private GameObject mainCube;
    [SerializeField] private GameObject subCube1;
    [SerializeField] private GameObject subCube2;
    [SerializeField] private GameObject subCube3;
    [SerializeField] private GameObject subCube4;
    [SerializeField] private GameObject tokidosLogo;

    private float waitTime = 2f;

    void Start()
    {
        tokidosLogo.transform.DOShakeRotation(1f, 20f);
        StartCoroutine(StartGame());        
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(waitTime);
        EnableCubes();
    }
    private void EnableCubes()
    {
        mainCube.SetActive(true);
        subCube1.SetActive(true);
        subCube2.SetActive(true);
        subCube3.SetActive(true);
        subCube4.SetActive(true);
        tokidosLogo.SetActive(false);
    }
}
