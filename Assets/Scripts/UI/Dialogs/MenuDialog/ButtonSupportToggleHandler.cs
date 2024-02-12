using UnityEngine;

public class ButtonSupportToggleHandler : MonoBehaviour
{
    public MenuDialogManager manager;

    public void OnButtonClick()
    {
        manager.TogglePanelSupport();
    }
}