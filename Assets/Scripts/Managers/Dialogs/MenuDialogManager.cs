using UnityEngine;

public class MenuDialogManager : MonoBehaviour
{
    public GameObject canvasMenuDialog;
    public GameObject panelMenuBlackoutCurtain;
    public GameObject panelMenu;
    public GameObject panelSupport;
    public GameObject panelReword;

    void Start()
    {
        canvasMenuDialog.SetActive(false);
    }

    public void OnPanelMenuBlackoutCurtain()
    {
        if (panelSupport.activeSelf)
        {
            panelSupport.SetActive(false);
        }
        else if (panelReword.activeSelf)
        {
            panelReword.SetActive(false);
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

    public void TogglePanelReword()
    {
        panelReword.SetActive(!panelReword.activeSelf);
    }

    public void CloseCanvasMenuDialog()
    {
        canvasMenuDialog.SetActive(false);
    }

    public void OpenCanvasMenuDialog()
    {
        canvasMenuDialog.SetActive(true);
        panelMenuBlackoutCurtain.SetActive(true);
        panelMenu.SetActive(true);
        panelSupport.SetActive(false);
        panelReword.SetActive(false);
    }
}
