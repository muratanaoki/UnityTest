using System;
using System.Collections;
using UnityEngine;
using Zenject;

public class InitializationManager : MonoBehaviour
{
    // イベントのシグネチャを変更して、stringを引数に取る
    public static event Action<string> OnInitializationCompleted;

    [Inject]
    private PlayFabLogin _playFabLogin;

    [Inject]
    private IDatabaseManager _databaseManager;

    private void Start()
    {
        StartCoroutine(Initialize());
    }

    private IEnumerator Initialize()
    {
        yield return _playFabLogin.LoginCoroutine(playFabId =>
        {
            if (playFabId != null)
            {
                Debug.Log($"Initialization succeeded. PlayFabId: {playFabId}");
                _databaseManager.InitializeUserSettings(playFabId);
                PlayerSession.Instance.SetPlayFabId(playFabId);
                PlayFabDataManager.Instance.GetPlayerProfile();
                PlayFabDataManager.Instance.GetButlerData();
                // 初期化が完了したことを通知（PlayFabIdを含む）
                OnInitializationCompleted?.Invoke(playFabId);
            }
            else
            {
                Debug.LogError("Initialization failed.");
                // 失敗を示すためにnullを通知
                OnInitializationCompleted?.Invoke(null);
            }
        });
    }
}
