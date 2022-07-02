using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

public class UnitaskDotween : MonoBehaviour
{
    async UniTask Start()
    {
       await this.transform.DOLocalJump(new Vector3(0,3f,0),1,1,1f).SetEase(Ease.Linear).AsyncWaitForCompletion();
        this.transform.DOLocalRotate(new Vector3(180, 45, -100), 1);
    }
}







