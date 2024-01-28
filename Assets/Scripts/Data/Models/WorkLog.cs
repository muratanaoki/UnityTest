using SQLite4Unity3d;

public class WorkLog
{
    [PrimaryKey, AutoIncrement]
    public int LogID { get; set; }
    public string UserID { get; set; }
    public string WorkType { get; set; }
    public int Duration { get; set; }
    public string Timestamp { get; set; }
}