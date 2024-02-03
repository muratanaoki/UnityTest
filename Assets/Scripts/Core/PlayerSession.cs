public class PlayerSession
{
    public PlayerProfile Profile { get; private set; }
    public ButlerDataContainer ButlerContainer { get; private set; }
    public string PlayFabId { get; private set; }

    // シングルトンパターンの実装
    private static PlayerSession instance;
    public static PlayerSession Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new PlayerSession();
            }
            return instance;
        }
    }   

    private PlayerSession() { }

    public void Initialize(PlayerProfile profile, ButlerDataContainer butlerContainer, string playFabId)
    {
        Profile = profile;
        ButlerContainer = butlerContainer;
        PlayFabId = playFabId; // PlayFabIDを初期化
    }
}
