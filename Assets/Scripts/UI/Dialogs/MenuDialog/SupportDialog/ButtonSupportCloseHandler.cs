using UnityEngine;

public class ButtonSupportCloseHandler : MonoBehaviour
{
    public MenuDialogManager manager;

    public void OnButtonClick()
    {
        manager.TogglePanelSupport();
    }
}