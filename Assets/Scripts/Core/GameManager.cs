using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour
{
    [Inject]
    private IDatabaseManager _databaseManager;

    private void Start()
    {
        // プレイヤーのIDを取得するロジックが必要です。
        // 例えば、ログインプロセスから取得したり、プレイヤープリファレンスから読み込んだりします。
        string playFabUserId = GetPlayFabUserId();

        // データベースマネージャーを使ってユーザー設定を初期化します。
        _databaseManager.InitializeUserSettings(playFabUserId);
    }

    private string GetPlayFabUserId()
    {
        // ユーザーIDを取得する実際のコード
        // この例では固定値を返しますが、実際にはプレイヤーのログイン情報から取得する必要があります。
        return "some_user_id";
    }
}
