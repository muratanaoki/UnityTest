using UnityEngine;
using Zenject;

public class RewordDialogManager : MonoBehaviour
{
    public GameObject canvasRewordDialog;
    public GameObject panelRewordBlackoutCurtain;
    public GameObject panelReword;

    void Start()
    {
        canvasRewordDialog.SetActive(false);
    }

    public void OpenCanvasRewordDialog()
    {
        canvasRewordDialog.SetActive(true);
        panelRewordBlackoutCurtain.SetActive(true);
        panelReword.SetActive(true);
    }

    public void CloseCanvasRewordDialog()
    {
        canvasRewordDialog.SetActive(false);
    }
}
