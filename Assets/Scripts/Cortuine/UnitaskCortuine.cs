using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;
using DG.Tweening;

public class UnitaskCortuine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CoroutineTest(10,this.gameObject.GetCancellationTokenOnDestroy());
    }

    //コールチンを定義する
    async UniTask CoroutineTest(int time,CancellationToken _cancellation)
    {
        Debug.Log("コルーチンスタート");

        
        await Task.Delay(TimeSpan.FromSeconds(time),_cancellation);

        //処理終了
        Debug.Log("コルーチンフィニッシュ");
    }
}
