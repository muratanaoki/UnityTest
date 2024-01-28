using System.Collections.Generic;

public interface IDatabaseManager
{
    void InitializeUserSettings();
    void InsertUserSetting(UserSetting userSetting);
    void UpdateUserSetting(UserSetting userSetting);
    void DeleteUserSetting();
    UserSetting GetUserSetting();
    void InsertWorkLog(WorkLog workLog);
    void UpdateWorkLog(WorkLog workLog);
    void DeleteWorkLog(int logId);
    List<WorkLog> GetWorkLogs();
}