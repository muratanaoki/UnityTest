using UnityEngine;

public class TogglePanelSupportHandler : MonoBehaviour
{
    public MenuDialogManager manager;

    public void OnButtonClick()
    {
        manager.TogglePanelSupport();
    }
}