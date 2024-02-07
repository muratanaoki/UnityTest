public class PlayerProgressManager
{
    public int Level { get; private set; } = 1;
    public int ExperiencePoints { get; private set; } = 0;
    public int ExperienceToNextLevel { get; private set; }
    public const int MaxLevel = 30;

    public PlayerProgressManager()
    {
        UpdateExperienceToNextLevel();
    }

    // 経験値を追加し、レベルアップ処理を行う
    public void AddExperience(int hours)
    {
        if (Level >= MaxLevel)
        {
            return; // 既に最大レベルに達している場合は処理を行わない
        }

        ExperiencePoints += hours; // 経験値を追加

        while (ExperiencePoints >= ExperienceToNextLevel)
        {
            ExperiencePoints -= ExperienceToNextLevel; // 次レベルに必要な経験値を引く
            Level++; // レベルアップ
            UpdateExperienceToNextLevel(); // 次のレベルに必要な経験値を更新

            if (Level == MaxLevel)
            {
                break; // 最大レベルに達したらループを終了
            }
        }
    }

    private void UpdateExperienceToNextLevel()
    {
        // レベルアップに必要な経験値（時間）を計算
        if (Level <= 5)
        {
            ExperienceToNextLevel = 5; // レベル1から5まで: 各レベルアップに5時間
        }
        else if (Level <= 10)
        {
            ExperienceToNextLevel = 10; // レベル6から10まで: 各レベルアップに10時間
        }
        else if (Level <= 20)
        {
            ExperienceToNextLevel = 20; // レベル11から20まで: 各レベルアップに20時間
        }
        else
        {
            ExperienceToNextLevel = 30; // レベル21から30まで: 各レベルアップに30時間
        }
    }
}
