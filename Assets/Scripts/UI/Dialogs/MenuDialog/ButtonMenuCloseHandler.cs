using UnityEngine;

public class ButtonMenuCloseHandler : MonoBehaviour
{
    public MenuDialogManager manager;

    public void OnButtonClick()
    {
        manager.CloseCanvasMenuDialog();
    }
}