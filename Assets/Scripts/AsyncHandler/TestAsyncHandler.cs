using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class TestAsyncHandler : MonoBehaviour
{
    [SerializeField] private Button _button;

    private void Start()
    {
        OnClickAsync();
    }

    // Start is called before the first frame update
    async UniTask OnClickAsync()
    {
        await _button.OnClickAsync();
        await UniTask.Delay(TimeSpan.FromSeconds(5));
        Debug.Log("押されました！");
    }


}
