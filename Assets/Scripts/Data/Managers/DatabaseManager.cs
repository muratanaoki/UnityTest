using SQLite4Unity3d;
using System.Linq;
using System.Collections.Generic;

public class DatabaseManager : IDatabaseManager
{
    private SQLiteConnection _connection;

    private string userId;

    public DatabaseManager(string databasePath)
    {
        _connection = new SQLiteConnection(databasePath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
        _connection.CreateTable<UserSetting>();
        _connection.CreateTable<WorkLog>();
    }

    public void InitializeUserSettings(string userId)
    {
        this.userId = userId;
        var userSettings = GetUserSetting();
        if (userSettings == null)
        {
            InsertUserSetting(new UserSetting
            {
                UserID = userId,
                DefaultFocusTime = 5,
                DefaultMaxTime = 120,
                DefaultMainBGM = "mute",
                DefaultVoice = "初期ボイス",
                DefaultWorkBGM = "初期作業BGM"
            });
        }
    }

    public void InsertUserSetting(UserSetting userSetting)
    {
        _connection.Insert(userSetting);
    }

    public void UpdateDefaultFocusTime(int newDefaultFocusTime)
    {
        var userSetting = GetUserSetting();
        if (userSetting != null)
        {
            userSetting.DefaultFocusTime = newDefaultFocusTime;
            _connection.Update(userSetting);
        }
    }

    public void UpdateDefaultMaxTime(int newDefaultMaxTime)
    {
        var userSetting = GetUserSetting();
        if (userSetting != null)
        {
            userSetting.DefaultMaxTime = newDefaultMaxTime;
            _connection.Update(userSetting);
        }
    }

    public void UpdateDefaultMainBGM(string newDefaultMainBGM)
    {
        var userSetting = GetUserSetting();
        if (userSetting != null)
        {
            userSetting.DefaultMainBGM = newDefaultMainBGM;
            _connection.Update(userSetting);
        }
    }

    public void UpdateDefaultVoice(string newDefaultVoice)
    {
        var userSetting = GetUserSetting();
        if (userSetting != null)
        {
            userSetting.DefaultVoice = newDefaultVoice;
            _connection.Update(userSetting);
        }
    }

    public void UpdateDefaultWorkBGM(string newDefaultWorkBGM)
    {
        var userSetting = GetUserSetting();
        if (userSetting != null)
        {
            userSetting.DefaultWorkBGM = newDefaultWorkBGM;
            _connection.Update(userSetting);
        }
    }


    public UserSetting GetUserSetting()
    {
        return _connection.Table<UserSetting>().FirstOrDefault(u => u.UserID == userId);
    }

    public void DeleteUserSetting()
    {
        var userSetting = GetUserSetting();
        if (userSetting != null)
        {
            _connection.Delete(userSetting);
        }
    }

    public void InsertWorkLog(WorkLog workLog)
    {
        _connection.Insert(workLog);
    }

    public void UpdateWorkLog(WorkLog workLog)
    {
        _connection.Update(workLog);
    }

    public List<WorkLog> GetWorkLogs()
    {
        return _connection.Table<WorkLog>().Where(w => w.UserID == userId).ToList();
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

