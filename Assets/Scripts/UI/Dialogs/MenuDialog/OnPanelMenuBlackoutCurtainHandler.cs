using UnityEngine;

public class OnPanelMenuBlackoutCurtainHandler : MonoBehaviour
{
    public MenuDialogManager manager;

    public void OnButtonClick()
    {
        manager.OnPanelMenuBlackoutCurtain();
    }
}