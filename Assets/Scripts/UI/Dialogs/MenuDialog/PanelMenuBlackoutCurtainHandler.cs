using UnityEngine;

public class PanelMenuBlackoutCurtainHandler : MonoBehaviour
{
    public MenuDialogManager manager;

    public void OnButtonClick()
    {
        manager.OnPanelMenuBlackoutCurtain();
    }
}