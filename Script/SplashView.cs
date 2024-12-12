using UnityEngine;
using Cysharp.Threading.Tasks; //「UniTask」を使用するため。

public class SplashView : ViewBase
{
    void Start()
    {
    }

    // -------------------------------------------------------
    // ビューオープン時コール.
    // -------------------------------------------------------
    public override async void OnViewOpened()
    {
        base.OnViewOpened();

        await ChangeViewWaitForSeconds();
    }

    // -------------------------------------------------------
    // ビュークローズ時コール.
    // -------------------------------------------------------
    public override void OnViewClosed()
    {
        base.OnViewClosed();
    }

    // ------------------------------------------------
    /// 2秒待ってタイトルViewに移動.
    // ------------------------------------------------
    async UniTask ChangeViewWaitForSeconds(float waitTime = 2f)
    {
        try
        {
            await UniTask.Delay((int)(waitTime * 1000f), false, PlayerLoopTiming.Update, this.GetCancellationTokenOnDestroy());
            Scene.ChangeView(1).Forget();
            //(非同期処理).Forget() : 非同期処理を待機せずに実行.
        }
        catch (System.OperationCanceledException e)
        {
            Debug.Log("ChangeViewWaitForSecondsがキャンセルされました。" + e);
        }
    }
}
