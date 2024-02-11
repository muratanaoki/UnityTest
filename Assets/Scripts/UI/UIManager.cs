using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject canvasMenuDialog;
    public GameObject panelMenuBlackoutCurtain;
    public GameObject panelMenu;
    public GameObject panelSupport;
    public CountdownTimer countdownTimer;
    public GameObject canvasBGMDialog;
    public GameObject panelBGMBlackoutCurtain;
    public GameObject panelBGM;

    private void HandleInitializationCompleted(string playFabId)
    {
        if (!string.IsNullOrEmpty(playFabId))
        {
            // ログインが成功し、PlayFabIdが返された場合の処理
            Debug.Log($"UIManager: Login succeeded. PlayFabId: {playFabId}");
            countdownTimer.InitializeAndStart();
            // ここでUIを更新したり、ユーザーに成功を通知したりします
        }
        else
        {
            // ログインが失敗した場合の処理
            Debug.LogError("UIManager: Login failed.");
            // ここでエラーメッセージを表示したり、再試行を促したりします
        }
    }

    private void OnEnable()
    {
        // InitializationManagerのイベントに対するリスナーを登録
        InitializationManager.OnInitializationCompleted += HandleInitializationCompleted;
    }

    private void OnDisable()
    {
        // オブジェクトが破棄される時にイベントリスナーを解除
        InitializationManager.OnInitializationCompleted -= HandleInitializationCompleted;
    }

    void Start()
    {
        canvasMenuDialog.SetActive(false);
        canvasBGMDialog.SetActive(false);
    }

    public void OnPanelMenuBlackoutCurtainClicked()
    {
        if (panelSupport.activeSelf)
        {
            panelSupport.SetActive(false);
        }
        else
        {
            canvasMenuDialog.SetActive(false);
        }
    }

    public void TogglePanelSupport()
    {
        panelSupport.SetActive(!panelSupport.activeSelf);
    }

    public void ToggleCanvasMenuDialog()
    {
        canvasMenuDialog.SetActive(!canvasMenuDialog.activeSelf);
    }

    public void OpenCanvasMenuDialog()
    {
        canvasMenuDialog.SetActive(true);
        panelMenuBlackoutCurtain.SetActive(true);
        panelMenu.SetActive(true);
        panelSupport.SetActive(false);
    }

    public void OpenCanvasBGMDialog()
    {
        canvasBGMDialog.SetActive(true);
        panelBGMBlackoutCurtain.SetActive(true);
        panelBGM.SetActive(true);
    }

    public void ToggleCanvasBGMDialog()
    {
        canvasBGMDialog.SetActive(!canvasBGMDialog.activeSelf);
    }
}
