using SQLite4Unity3d;
using System.Linq;
using System.Collections.Generic;

public class DatabaseManager : IDatabaseManager
{
    private SQLiteConnection _connection;

    public DatabaseManager(string databasePath)
    {
        _connection = new SQLiteConnection(databasePath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
        _connection.CreateTable<UserSetting>();
        _connection.CreateTable<WorkLog>();
    }

    public void InitializeUserSettings(string playFabUserId)
    {
        var userSettings = GetUserSetting(playFabUserId);
        if (userSettings == null)
        {
            InsertUserSetting(new UserSetting
            {
                UserID = playFabUserId,
                DefaultFocusTime = 25,
                DefaultMaxTime = 120,
                DefaultMainBGM = "初期BGM",
                DefaultVoice = "初期ボイス",
                DefaultWorkBGM = "初期作業BGM"
            });
        }
    }

    public void InsertUserSetting(UserSetting userSetting)
    {
        _connection.Insert(userSetting);
    }

    public void UpdateUserSetting(UserSetting userSetting)
    {
        _connection.Update(userSetting);
    }

    public UserSetting GetUserSetting(string userId)
    {
        return _connection.Table<UserSetting>().FirstOrDefault(u => u.UserID == userId);
    }

    public void DeleteUserSetting(string userId)
    {
        var userSetting = GetUserSetting(userId);
        if (userSetting != null)
        {
            _connection.Delete(userSetting);
        }
    }

    public void InsertWorkLog(WorkLog workLog)
    {
        _connection.Insert(workLog);
    }

    public List<WorkLog> GetWorkLogs(string userId)
    {
        return _connection.Table<WorkLog>().Where(w => w.UserID == userId).ToList();
    }

    public void UpdateWorkLog(WorkLog workLog)
    {
        _connection.Update(workLog);
    }

    public void DeleteWorkLog(int logId)
    {
        var workLog = _connection.Table<WorkLog>().FirstOrDefault(w => w.LogID == logId);
        if (workLog != null)
        {
            _connection.Delete(workLog);
        }
    }
}