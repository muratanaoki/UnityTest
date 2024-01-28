using System.Collections.Generic;

public interface IDatabaseManager
{
    void InitializeUserSettings(string playFabUserId);
    void InsertUserSetting(UserSetting userSetting);
    void UpdateUserSetting(UserSetting userSetting);
    UserSetting GetUserSetting(string userId);
    void DeleteUserSetting(string userId);
    void InsertWorkLog(WorkLog workLog);
    List<WorkLog> GetWorkLogs(string userId);
    void UpdateWorkLog(WorkLog workLog);
    void DeleteWorkLog(int logId);
}
