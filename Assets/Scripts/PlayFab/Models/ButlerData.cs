[System.Serializable]
public class ButlerData
{
    public string ButlerID { get; set; }
    public int ExperiencePoints { get; set; }
    public int IntimacyLevel { get; set; }

    // コピーコンストラクタ
    public ButlerData(ButlerData source)
    {
        ButlerID = source.ButlerID;
        ExperiencePoints = source.ExperiencePoints;
        IntimacyLevel = source.IntimacyLevel;
    }

    // デフォルトコンストラクタ
    public ButlerData() { }
}