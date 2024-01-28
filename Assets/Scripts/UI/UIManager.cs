using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject canvasMenuDialog;
    public GameObject panelBlackoutCurtain;
    public GameObject panelMenu;
    public GameObject panelSupport;

    void Start()
    {
        canvasMenuDialog.SetActive(false);
        panelBlackoutCurtain.SetActive(false);
        panelMenu.SetActive(false);
        panelSupport.SetActive(false);
    }

    // Panel Blackout Curtainがクリックされた時の処理
    public void OnBlackoutCurtainClicked()
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

    // Panel Menu内のButton Supportがクリックされた時の処理
    public void TogglePanelSupport()
    {
        panelSupport.SetActive(!panelSupport.activeSelf);
    }

    public void CloseCanvasMenuDialog()
    {
        canvasMenuDialog.SetActive(!canvasMenuDialog.activeSelf);
    }

    public void OpenCanvasMenuDialog()
    {
        canvasMenuDialog.SetActive(true);
        panelBlackoutCurtain.SetActive(true);
        panelMenu.SetActive(true);
        panelSupport.SetActive(false);
    }

}
