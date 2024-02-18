using UnityEngine;

public class CloseCanvasRewordDialogHandler : MonoBehaviour
{
    public RewordDialogManager manager;
    public void OnButtonClick()
    {
        manager.CloseCanvasRewordDialog();
    }
}