using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;

namespace Saito.UI
{
    public class PressButtonAwait : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private Text _text;

        private void Start()
        {
            Test();
            _text.text = "ボタンは一度も押されていません！";
        }

        private async UniTask Test()
        {
            for (int i = 0; i < 10; i++)
            {
                _text.text = $"{i}回ボタンが押されました！";
                //ボタン待ち処理
                await _button.OnClickAsync();
            }

            _text.text = "上限回数押されました";
        }
    }
}