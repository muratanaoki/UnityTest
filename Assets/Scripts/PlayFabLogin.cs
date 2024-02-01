using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;


[System.Serializable]
public class GachaMaster
{
    public int ID;
    public string Name;
    public int Rank;
    public int Rate;
}

[System.Serializable]
public class GachaMasterArray
{
    public GachaMaster[] items;
}


public class PlayFabLogin : MonoBehaviour
{
    public static void GetTitleData()
    {
        var request = new GetTitleDataRequest();
        PlayFabClientAPI.GetTitleData(request, OnSuccess, OnError);

        void OnSuccess(GetTitleDataResult result)
        {
            Debug.Log("GetTitleData: Success!");
            GachaMasterArray gachaMasterArray = JsonUtility.FromJson<GachaMasterArray>("{\"items\":" + result.Data["GachaMaster"] + "}");
            foreach (var master in gachaMasterArray.items)
            {
                Debug.Log(master.Name);
            }

            //Debug.Log(result.Data["GachaMaster"]);
        }

        void OnError(PlayFabError error)
        {
            Debug.Log("GetTitleData: Fail...");
            Debug.Log(error.GenerateErrorReport());
        }
    }

    public void Start()
    {
        if (string.IsNullOrEmpty(PlayFabSettings.staticSettings.TitleId))
        {
            /*
            Please change the titleId below to your own titleId from PlayFab Game Manager.
            If you have already set the value in the Editor Extensions, this can be skipped.
            */
            PlayFabSettings.staticSettings.TitleId = "42";
        }
        var request = new LoginWithCustomIDRequest { CustomId = "GettingStartedGuide", CreateAccount = true };
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginFailure);
    }

    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("Congratulations, you made your first successful API call!");
        GetTitleData();
    }

    private void OnLoginFailure(PlayFabError error)
    {
        Debug.LogWarning("Something went wrong with your first API call.  :(");
        Debug.LogError("Here's some debug information:");
        Debug.LogError(error.GenerateErrorReport());
    }
}