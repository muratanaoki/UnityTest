using UnityEngine;

public class ButtonMenuHandler : MonoBehaviour
{
    public HeaderManager manager;

    public void OnButtonClick()
    {
        manager.OpenCanvasMenuDialog();
    }
}