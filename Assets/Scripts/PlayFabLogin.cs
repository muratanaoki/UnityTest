using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using PlayFab.Json;
using UnityEngine;


public class PlayFabLogin : MonoBehaviour
{
    // PlayerProfileの定義は前の例と同じ

    public static void GetPlayerData()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), OnDataReceived, OnError);
    }

    // プレイヤーデータ受信時の処理
    private static void OnDataReceived(GetUserDataResult result)
    {
        Debug.Log("Player Data received successfully!");

        PlayerProfile profile = null;
        ButlerDataContainer butlerContainer = new ButlerDataContainer();

        if (result.Data.ContainsKey("PlayerProfile"))
        {
            profile = PlayFabSimpleJson.DeserializeObject<PlayerProfile>(result.Data["PlayerProfile"].Value);
            Debug.Log("Player Profile: " + profile.Username + ", " + profile.Email + ", " + profile.DateOfBirth + ", " + profile.Gender);
        }

        if (result.Data.ContainsKey("ButlerData"))
        {
            butlerContainer.butlers = PlayFabSimpleJson.DeserializeObject<Dictionary<string, ButlerData>>(result.Data["ButlerData"].Value);
        }

        // セッションデータの初期化
        PlayerSession.Instance.Initialize(profile, butlerContainer, PlayerSession.Instance.PlayFabId);
    }

    // OnErrorメソッドとStartメソッドは前の例と同じ


    // エラー発生時のコールバック
    private static void OnError(PlayFabError error)
    {
        Debug.LogError("Something went wrong with your API call.");
        Debug.LogError(error.GenerateErrorReport());
    }

    // ゲーム開始時に呼び出される
    void Start()
    {
        if (string.IsNullOrEmpty(PlayFabSettings.staticSettings.TitleId))
        {
            // あなたのTitleIdに設定してください。
            PlayFabSettings.staticSettings.TitleId = "42";
        }
        var request = new LoginWithCustomIDRequest { CustomId = "GettingStartedGuide", CreateAccount = true };
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginFailure);
    }

    // ログイン成功時のコールバック
    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("Logged in successfully!");
        Debug.Log("PlayFabID: " + result.PlayFabId);
        // プレイヤーデータの取得を試みる
        GetPlayerData();
        PlayerSession.Instance.Initialize(null, null, result.PlayFabId);
    }

    // ログイン失敗時のコールバック
    private void OnLoginFailure(PlayFabError error)
    {
        Debug.LogWarning("Failed to log in");
        Debug.LogError(error.GenerateErrorReport());
    }
}
