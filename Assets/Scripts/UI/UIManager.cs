using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject canvasMenuDialog;
    public GameObject panelMenuBlackoutCurtain;
    public GameObject panelMenu;
    public GameObject panelSupport;

    void Start()
    {
        canvasMenuDialog.SetActive(false);
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
}
