using UnityEngine;

public class ButtonMenuHandler : MonoBehaviour
{
    public MenuDialogManager manager;

    public void OnButtonClick()
    {
        manager.OpenCanvasMenuDialog();
    }
}