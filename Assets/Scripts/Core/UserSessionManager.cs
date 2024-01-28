public class UserSessionManager
{
    private static readonly UserSessionManager _instance = new UserSessionManager();
    public static UserSessionManager Instance => _instance;

    public string UserId { get; private set; }

    // コンストラクタは private で外部からのインスタンス化を防ぎます
    private UserSessionManager() { }

    public void Initialize(string userId)
    {
        UserId = userId;
    }
}
