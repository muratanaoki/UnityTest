using UnityEngine;

public class ButtonSupportHandler : MonoBehaviour
{
    public MenuDialogManager manager;

    public void OnButtonClick()
    {
        manager.TogglePanelSupport();
    }
}