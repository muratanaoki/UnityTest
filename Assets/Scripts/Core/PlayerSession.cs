using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSession : MonoBehaviour
{
    private static PlayerSession instance;
    public static PlayerSession Instance
    {
        get { return instance; }
    }

    public event Action OnDataUpdated; // データ更新の通知用イベント

    public string PlayFabId { get; private set; }
    public PlayerProfile Profile { get; private set; }
    public List<ButlerData> ButlerContainer { get; private set; }
    public ButlerData CurrentButlerData { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // シーン遷移しても破棄されないようにする
            ButlerContainer = new List<ButlerData>();
        }
        else if (instance != this)
        {
            Destroy(gameObject); // 重複インスタンスの破棄
        }
    }

    // PlayFabIdをセットするメソッド
    public void SetPlayFabId(string id)
    {
        PlayFabId = id;
    }

    public void SetProfile(PlayerProfile profile)
    {
        Profile = profile;
    }

    public void SetButlerContainer(List<ButlerData> container)
    {
        ButlerContainer = container;
    }

    public void SetCurrentButlerData(ButlerData butlerData)
    {
        CurrentButlerData = butlerData;
    }

    public void NotifyDataUpdated()
    {
        OnDataUpdated?.Invoke();
    }
}
