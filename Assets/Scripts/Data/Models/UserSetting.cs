using SQLite4Unity3d;

public class UserSetting
{
    [PrimaryKey]
    public string UserID { get; set; }
    public int DefaultFocusTime { get; set; }
    public int DefaultMaxTime { get; set; }
    public string DefaultMainBGM { get; set; }
    public string DefaultVoice { get; set; }
    public string DefaultWorkBGM { get; set; }
}