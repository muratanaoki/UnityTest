using UnityEngine;
public class ButtonOpenURLHandler : MonoBehaviour
{
    public string url;
    public void OnButtonClick()
    {
        Application.OpenURL(url);
    }
}
