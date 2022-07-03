# unity-tutorial-unitask-sample
This is a sample created during the UniTask learning process. for the five free time  
UniTask学習中に作成したサンプルプロジェクトです。ご自由にお使いください。  
## UniTaskとは
・非同期処理を強化する仕組み  
・Taskの強化版(パフォーマンが高い、Unity用に用意されたメソッドもあったりする)  
・非同期処理は同期処理の逆（結果を待たないで次の処理に移ることが出来る処理）  

### 使い方 
・async awaitを使う感じで使います。TaskをUniTaskにすることで、Unitaskの機能が使えます。  
・awaitするところからスレッドが変わるはずだが、Unity側がメインスレッドに納めてくれるため、ManagedThreadIdの値はすべて1  

```
   void Start()
    {
        Debug.Log("スレッド："+Thread.CurrentThread.ManagedThreadId+"  1");
        Test();
         
    }

    // Update is called once per frame
    async UniTask Test()
    {
        //1秒待つ
        await UniTask.Delay(1000);
        Debug.Log("スレッド："+Thread.CurrentThread.ManagedThreadId+"  2");
    }
```

### コールチンとの違いは？
#### 通常のコールチン
・IEnumeratorで定義されている  
・StartCoroutineで呼び出す  
・yeild returnまたは break がかならず1回必要   
・yeild breakで処理終了   
```
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
```
#### UniTaskを入れたコールチン
・コールチンと違いオブジェクトが破壊されても実行し続けるので注意が必要  
・同期処理の様にかけて便利  

```
    // Start is called before the first frame update
    void Start()
    {
        CoroutineTest(5);
    }

    //コールチンを定義する
    async UniTask CoroutineTest(int time = 0)
    {
        Debug.Log("コルーチンスタート");

        
        await Task.Delay(time*1000);

        //処理終了
        Debug.Log("コルーチンフィニッシュ");
    }
```

## キャンセルの処理
・**UniTaskは自動的にキャンセルされないのでIDposeの様に意図的に破棄させる機能を追加させる必要がある**  
・UniTaskにはUniTaskTrackerというTaskを管理できるものがあります。是非利用しましょう。  
![タイトルなし](https://user-images.githubusercontent.com/96648305/177011341-0468f3f4-fa22-4e32-bf9d-c67f5902c356.png)

・基本的にCancellationTokenを用いることでキャンセル可能  
・GetCancellationTokenOnDestroy()でオブジェクト破壊時にキャンセルされる  

## UI周りでUniTaskで色々実装してみる

### AsyncHandlerについて（UI関係）
| 命令語 | 説明 |
|:---:|:---:|
|OnClickAsync |クリックを待つ |
|OnValueChangedAsync |値が変化するのを待つ |
|OnEditAsync |入力が終わるのを待つ |
・イベント周りはUniRxの方が使いやすいですね..  

### 1.入力待ちするUI
![スクリーンショット 2022-03-29 234534](https://user-images.githubusercontent.com/96648305/160638905-26179942-d07f-43f0-8322-e16eb6a49b4d.png)

### 2. Dotweenで使ってみる
・Dotweenもasync awaitに対応しているので、UniTaskも利用できます。

![gg](https://user-images.githubusercontent.com/96648305/177011336-a2472f67-598f-4d5e-a71a-709ae69aaec6.png)


## 参考資料
https://www.youtube.com/playlist?list=PLX8FlYCKkO9hbFywFytAFgY4ooGzT6ttv  
https://tatsu-zine.com/books/unirx-unitask  
https://github.com/Cysharp/UniTask  
http://softmedia.sakura.ne.jp/advent-calendar/2020/12-12.html  
https://zenn.dev/torisoup/articles/coroutine_01  
https://game-ui.net/?p=1040  
https://zenn.dev/ohbashunsuke/books/20200924-dotween-complete  


