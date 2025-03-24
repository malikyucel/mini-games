using UnityEngine;
using DG.Tweening;

public class TrueDoor : MonoBehaviour, IFunction
{
    public void Function()
    {
        RoadSpawnManager.Instance.CoinPlus();
        RoadSpawnManager.Instance.TrueSound();
        gameObject.transform.DORotate(transform.localRotation.eulerAngles + new Vector3(0,0,-180), 1f);
        gameObject.transform.DOScale(transform.localRotation.eulerAngles + new Vector3(0,0,0), 1f).SetEase(Ease.InOutBack);
    }
}
