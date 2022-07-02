using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using System.Threading;

public class testUnitask : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
        Test();
         
    }

    // Update is called once per frame
    async UniTask Test()
    {
        //1秒待つ
        Debug.Log("スレッド："+Thread.CurrentThread.ManagedThreadId+"  1");
        await UniTask.Delay(1000);
        Debug.Log("スレッド："+Thread.CurrentThread.ManagedThreadId+"  2");
    }
}
