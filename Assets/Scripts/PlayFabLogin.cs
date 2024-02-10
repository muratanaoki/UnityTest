using System;
using System.Collections;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using Zenject;

public class PlayFabLogin : MonoBehaviour
{
    [Inject]
    private IDatabaseManager _databaseManager;

    // Actionのシグネチャを変更して、成功時にはPlayFabIdを、失敗時にはnullを返す
    public IEnumerator LoginCoroutine(Action<string> onCompleted)
    {
        if (string.IsNullOrEmpty(PlayFabSettings.staticSettings.TitleId))
        {
            PlayFabSettings.staticSettings.TitleId = "42";
        }

        var request = new LoginWithCustomIDRequest { CustomId = "GettingStartedGuide", CreateAccount = true };
        bool isRequestCompleted = false;

        PlayFabClientAPI.LoginWithCustomID(request, result =>
        {
            Debug.Log("Logged in successfully!");
            isRequestCompleted = true;
            // 成功時にPlayFabIdを返す
            onCompleted?.Invoke(result.PlayFabId);
        },
        error =>
        {
            Debug.LogError("Failed to log in: " + error.GenerateErrorReport());
            isRequestCompleted = true;
            // 失敗時にはnullを返す
            onCompleted?.Invoke(null);
        });

        // リクエストが完了するまで待機
        yield return new WaitUntil(() => isRequestCompleted);
    }
}
