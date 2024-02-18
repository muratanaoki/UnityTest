using UnityEngine.UI;
using UnityEngine;


public class HeaderManager : MonoBehaviour
{
    public Slider experiencePoints;
    public Text intimacyLevel;

    public GameObject buttonMenu;
    public GameObject buttonBGM;

    public MenuDialogManager menuDialogManager;
    public BGMDialogManager bgmDialogManager;


    void Start()
    {
        buttonMenu.SetActive(true);
        buttonBGM.SetActive(false);
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

    public void IsVisbleButtonMenu(bool isVisble)
    {
        buttonMenu.SetActive(isVisble);
    }

    public void IsVisbleButtonBGM(bool isVisble)
    {
        buttonBGM.SetActive(isVisble);
    }
}
