using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HammerController : MonoBehaviour
{


     void Start()
    {
        HammerDown();
    }
    void HammerDown()
    {
        transform.DORotate(new Vector3(0,0,90), 0.5f).SetEase(Ease.Linear).OnComplete(()=>HammerUp());
    }

    void HammerUp()
    {
        transform.DORotate(new Vector3(0, 0, 0), 1.5f).SetEase(Ease.Linear).OnComplete(() => HammerDown());
    }
}
