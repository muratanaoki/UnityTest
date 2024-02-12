using UnityEngine;

public class BGMDialogManager : MonoBehaviour
{
    public GameObject canvasBGMDialog;
    public GameObject panelBGMBlackoutCurtain;
    public GameObject panelBGM;

    void Start()
    {
        canvasBGMDialog.SetActive(false);
    }

    public void OpenCanvasBGMDialog()
    {
        canvasBGMDialog.SetActive(true);
        panelBGMBlackoutCurtain.SetActive(true);
        panelBGM.SetActive(true);
    }

    public void CloseCanvasBGMDialog()
    {
        canvasBGMDialog.SetActive(false);
    }
}
