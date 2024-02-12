using UnityEngine;

public class CloseCanvasMenuDialogHandler : MonoBehaviour
{
    public MenuDialogManager manager;

    public void OnButtonClick()
    {
        manager.CloseCanvasMenuDialog();
    }
}