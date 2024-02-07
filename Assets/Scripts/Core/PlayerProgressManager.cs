public static class PlayerProgressManager
{
    private const int MaxLevel = 30;

    // 現在のレベル、経験値、追加経験値を引数に取り、更新されたレベルと経験値をタプルで返します
    public static (int NewLevel, int NewExperiencePoints) CalculateNewPlayerState(int currentLevel, int currentExperiencePoints, int experienceToAdd)
    {
        var newExperiencePoints = currentExperiencePoints + experienceToAdd;
        var newLevel = currentLevel;

        while (newExperiencePoints >= GetExperienceToNextLevel(newLevel) && newLevel < MaxLevel)
        {
            newExperiencePoints -= GetExperienceToNextLevel(newLevel);
            newLevel++;
            if (newLevel >= MaxLevel)
            {
                // 最大レベルに達したらループを抜け、経験値の加算を止める
                newExperiencePoints = System.Math.Min(newExperiencePoints, GetExperienceToNextLevel(MaxLevel) - 1);
                break;
            }
        }

        return (newLevel, newExperiencePoints);
    }

    // レベルアップに必要な経験値を計算するメソッド
    private static int GetExperienceToNextLevel(int level)
    {
        if (level <= 5)
        {
            return 100 * level; // レベル1~5までは、レベルごとに100ポイントずつ必要
        }
        else if (level <= 10)
        {
            return 500 + 200 * (level - 5); // レベル6~10では、追加で200ポイントずつ
        }
        // さらに高いレベルの計算ロジックを追加
        else
        {
            return 1500 + 300 * (level - 10); // レベル11以上では、追加で300ポイントずつ
        }
    }
}
