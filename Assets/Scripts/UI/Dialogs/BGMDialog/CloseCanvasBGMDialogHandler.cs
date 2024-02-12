using UnityEngine;

public class CloseCanvasBGMDialogHandler : MonoBehaviour
{
    public BGMDialogManager manager;

    public void OnButtonClick()
    {
        manager.CloseCanvasBGMDialog();
    }
}