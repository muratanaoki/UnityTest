using UnityEngine;

public class OpenCanvasBGMDialogHandler : MonoBehaviour
{
    public BGMDialogManager manager;

    public void OnButtonClick()
    {
        manager.OpenCanvasBGMDialog();
    }
}