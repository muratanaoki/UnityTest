using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using PlayFab.Json;
using UnityEngine;

public class PlayFabDataManager : MonoBehaviour
{
    public static PlayFabDataManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void GetPlayerProfile()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), result =>
        {
            if (result.Data != null && result.Data.ContainsKey("PlayerProfile"))
            {
                var profileJson = result.Data["PlayerProfile"].Value;
                var profile = PlayFabSimpleJson.DeserializeObject<PlayerProfile>(profileJson);
                PlayerSession.Instance.SetProfile(profile);
            }
        }, error => Debug.LogError(error.GenerateErrorReport()));
    }

    public void GetButlerData()
    {
        // ここでButlerDataContainerとCurrentButlerDataを取得するロジックを実装
        // 以下は、これらを取得するためのプレースホルダーメソッドです

        // 例: ButlerDataContainerの取得
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), result =>
        {
            if (result.Data != null && result.Data.ContainsKey("ButlerData"))
            {
                var butlersJson = result.Data["ButlerData"].Value;
                // JSONデータをButlerDataの配列にデシリアライズ
                var butlersArray = PlayFabSimpleJson.DeserializeObject<ButlerData[]>(butlersJson);
                // List<ButlerData>に変換してPlayerSessionに設定する
                PlayerSession.Instance.SetButlerContainer(new List<ButlerData>(butlersArray));
            }

            if (result.Data != null && result.Data.ContainsKey("CurrentButler"))
            {
                var currentButlerId = result.Data["CurrentButler"].Value;
                // List<ButlerData>をループしてCurrentButlerを探す
                foreach (var butler in PlayerSession.Instance.ButlerContainer)
                {
                    if (butler.ButlerID == currentButlerId)
                    {
                        PlayerSession.Instance.SetCurrentButlerData(butler);
                        break; // マッチするバトラーが見つかったらループを終了
                    }
                }
            }

            PlayerSession.Instance.NotifyDataUpdated();
        }, error => Debug.LogError(error.GenerateErrorReport()));
    }

    public void UpdateButlerExperienceAndIntimacy(int newExperiencePoints, int newIntimacyLevel)
    {
        ButlerData butlerData = PlayerSession.Instance.CurrentButlerData;
        if (butlerData != null)
        {
            // 更新データのコピーを作成
            ButlerData updatedButlerData = new ButlerData(butlerData)
            {
                ExperiencePoints = newExperiencePoints,
                IntimacyLevel = newIntimacyLevel
            };

            // JSONデータを更新
            var butlers = new List<ButlerData>(PlayerSession.Instance.ButlerContainer);
            int index = butlers.FindIndex(b => b.ButlerID == butlerData.ButlerID);
            if (index != -1)
            {
                butlers[index] = updatedButlerData; // コピーをリストにセット
            }
            var updatedButlersJson = PlayFabSimpleJson.SerializeObject(butlers);

            var updateRequest = new UpdateUserDataRequest
            {
                Data = new Dictionary<string, string> { { "ButlerData", updatedButlersJson } }
            };

            PlayFabClientAPI.UpdateUserData(updateRequest, result =>
            {
                // PlayFab更新成功後にローカルセッションデータを更新
                PlayerSession.Instance.SetButlerContainer(butlers); // コンテナ全体を更新
                PlayerSession.Instance.SetCurrentButlerData(updatedButlerData); // 現在の執事データを更新
                PlayerSession.Instance.NotifyDataUpdated();
                Debug.Log("Butler data updated successfully in PlayFab.");
            }, error =>
            {
                Debug.LogError("Failed to update butler data in PlayFab: " + error.GenerateErrorReport());
            });
        }
        else
        {
            Debug.LogError("ButlerID not found in session data.");
        }
    }
}

