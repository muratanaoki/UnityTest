using UnityEngine.UI;
using UnityEngine;


public class HeaderManager : MonoBehaviour
{
    public Slider experiencePoints;
    public Text intimacyLevel;
    public MenuDialogManager menuDialogManager;
    public BGMDialogManager bgmDialogManager;

    void Start()
    {
        UpdateUIFromSession();
    }

    private void OnEnable()
    {
        PlayerSession.Instance.OnDataUpdated += UpdateUIFromSession;
    }

    private void OnDisable()
    {
        PlayerSession.Instance.OnDataUpdated -= UpdateUIFromSession;
    }

    private void UpdateUIFromSession()
    {
        // PlayerSessionから現在のButlerDataを取得
        var butlerData = PlayerSession.Instance.CurrentButlerData;
        if (butlerData != null)
        {
            // UIコンポーネントにデータを設定
            experiencePoints.value = butlerData.ExperiencePoints;
            intimacyLevel.text = butlerData.IntimacyLevel.ToString();
        }
    }

    public void OpenCanvasMenuDialog()
    {
        menuDialogManager.OpenCanvasMenuDialog();
    }

    public void OpenCanvasBGMDialog()
    {
        bgmDialogManager.OpenCanvasBGMDialog();
    }
}
