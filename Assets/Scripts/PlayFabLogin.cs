using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using Zenject;


public class PlayFabLogin : MonoBehaviour
{
    [Inject]
    private IDatabaseManager _databaseManager;


    // PlayerProfileの定義は前の例と同じ
    public static void GetPlayerData()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), OnDataReceived, OnError);
    }

    // プレイヤーデータ受信時の処理
    private static void OnDataReceived(GetUserDataResult result)
    {
        Debug.Log("Player Data received successfully!");

    }


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

        _databaseManager.InitializeUserSettings(result.PlayFabId);
        PlayerSession.Instance.SetPlayFabId(result.PlayFabId);
        PlayFabDataManager.Instance.GetPlayerProfile();
        PlayFabDataManager.Instance.GetButlerData();
    }

    // ログイン失敗時のコールバック
    private void OnLoginFailure(PlayFabError error)
    {
        Debug.LogWarning("Failed to log in");
        Debug.LogError(error.GenerateErrorReport());
    }
}
