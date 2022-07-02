using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Courtine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //コールチンを呼び出す
        //StartCoroutine(CoroutineTest(0));

        StartCoroutine(CoroutineTest(5.0f));
    }

    //コールチンを定義する
    IEnumerator CoroutineTest(float time=0.0f)
    {
        Debug.Log("コルーチンスタート");
        
        //コールチンを途中で停止できる
        if(time>=5.0f) StopCoroutine(CoroutineTest());
        
        //特殊なreturn 
        yield return new WaitForSeconds(time) ;
        //1フレーム待つ
        //yield return null;
        
        //処理終了
        Debug.Log("コルーチンフィニッシュ");
        yield break;
    }
}
