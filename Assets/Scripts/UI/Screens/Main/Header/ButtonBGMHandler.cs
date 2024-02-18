using UnityEngine;

public class ButtonBGMHandler : MonoBehaviour
{
    public HeaderManager manager;

    public void OnButtonClick()
    {
        manager.OpenCanvasBGMDialog();
    }
}