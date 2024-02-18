using UnityEngine;

public class TextLabelHandler : MonoBehaviour
{
    public HeaderManager manager;

    public void OnButtonClick()
    {
        manager.OpenCanvasRewordDialog();
    }
}