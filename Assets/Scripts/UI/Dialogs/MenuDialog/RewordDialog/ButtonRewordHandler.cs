using UnityEngine;

public class ButtonRewordHandler : MonoBehaviour
{
    public MenuDialogManager manager;

    public void OnButtonClick()
    {
        manager.TogglePanelReword();
    }
}