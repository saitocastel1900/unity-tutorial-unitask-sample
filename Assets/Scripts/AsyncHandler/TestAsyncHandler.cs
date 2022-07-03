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
    [SerializeField] private Slider _slider;
    [SerializeField] private InputField _inputField;
    private void Start()
    {
        OnClickAsync();
        OnValueChangedAsync();
        OnEditAsync();
    }

    // Start is called before the first frame update
    private async UniTask OnClickAsync()
    {
        await _button.OnClickAsync();
        Debug.Log("押されました！");
    }

    private async UniTask OnValueChangedAsync()
    {
        await _slider.OnValueChangedAsync();
        Debug.Log("値が変わりました！");
    }
    
    private async UniTask OnEditAsync()
    {
        await _inputField.OnEndEditAsync();
        Debug.Log("入力が終わりました！");
    }

}
