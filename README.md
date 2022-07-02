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
・yeild returnがかならず1回必要   
```

```
#### UniTaskを入れたコールチン
```

```

・コールチンも非同期処理を簡単に実装できますが、戻り値を持ってくるようにするには難しかったりする..  
・  

## UniTaskで色々実装してみる
### 1.入力待ちするUI
![スクリーンショット 2022-03-29 234534](https://user-images.githubusercontent.com/96648305/160638905-26179942-d07f-43f0-8322-e16eb6a49b4d.png)

### 2. Dotweenで使ってみる


### 3.



## 参考資料
https://www.youtube.com/playlist?list=PLX8FlYCKkO9hbFywFytAFgY4ooGzT6ttv  
https://tatsu-zine.com/books/unirx-unitask  
https://github.com/Cysharp/UniTask  
http://softmedia.sakura.ne.jp/advent-calendar/2020/12-12.html  
https://zenn.dev/torisoup/articles/coroutine_01
