using System.Collections.Generic;

public interface IDatabaseManager
{
    void InitializeUserSettings(string userId);
    void InsertUserSetting(UserSetting userSetting);
    void UpdateDefaultFocusTime(int newDefaultFocusTime);
    void UpdateDefaultMaxTime(int newDefaultMaxTime);
    void UpdateDefaultVoice(string newDefaultVoice);
    void UpdateDefaultWorkBGM(string newDefaultWorkBGM);
    void DeleteUserSetting();
    UserSetting GetUserSetting();
    void InsertWorkLog(WorkLog workLog);
    void UpdateWorkLog(WorkLog workLog);
    void DeleteWorkLog(int logId);
    List<WorkLog> GetWorkLogs();
}