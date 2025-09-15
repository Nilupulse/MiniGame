using System;
using DG.Tweening;
using UnityEngine;

public class SnapCubes : MonoBehaviour
{
    [SerializeField] Transform MainCube;
    [SerializeField] Transform SubCube1;
    [SerializeField] Transform SubCube2;
    [SerializeField] Transform SubCube3;
    [SerializeField] Transform SubCube4;

    public event Action OnSnapAllCubesStart;
    public event Action OnCompleteUnsnapAllCubes;

    public void SnapAllCube()
    {
        OnSnapAllCubesStart?.Invoke();

        MainCube.transform.DOMove(new Vector3(-4, 0, 0), 2f).SetEase(Ease.OutSine);
        SubCube1.transform.DOMove(new Vector3(-2, 0, 0), 2f).SetEase(Ease.OutSine);
        SubCube2.transform.DOMove(new Vector3(0, 0, 0), 2f).SetEase(Ease.OutSine);
        SubCube3.transform.DOMove(new Vector3(2, 0, 0), 2f).SetEase(Ease.OutSine);
        SubCube4.transform.DOMove(new Vector3(4, 0, 0), 2f).SetEase(Ease.OutSine);
    }

    public void UnsnapAllCubes()
    {
        MainCube.transform.DOMove(new Vector3(0, 0, 0), 2f).SetEase(Ease.OutSine);
        SubCube1.transform.DOMove(new Vector3(-5, 3, 0), 2f).SetEase(Ease.OutSine);
        SubCube2.transform.DOMove(new Vector3(-5, -3, 0), 2f).SetEase(Ease.OutSine);
        SubCube3.transform.DOMove(new Vector3(5, 3, 0), 2f).SetEase(Ease.OutSine);
        SubCube4.transform.DOMove(new Vector3(5, -3, 0), 2f).SetEase(Ease.OutSine);

        OnCompleteUnsnapAllCubes?.Invoke();
    }
}
