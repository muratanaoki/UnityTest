using System.Collections.Generic;

[System.Serializable]
public class ButlerDataContainer
{
    public Dictionary<string, ButlerData> butlers;

    // コンストラクタでDictionaryを初期化する
    public ButlerDataContainer()
    {
        butlers = new Dictionary<string, ButlerData>();
    }
}
