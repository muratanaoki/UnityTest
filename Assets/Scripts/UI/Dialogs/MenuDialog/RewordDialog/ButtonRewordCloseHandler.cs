using UnityEngine;

public class ButtonRewordCloseHandler : MonoBehaviour
{
    public MenuDialogManager manager;

    public void OnButtonClick()
    {
        manager.TogglePanelReword();
    }
}