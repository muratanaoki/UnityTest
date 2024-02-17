using UnityEngine;

public class ToggleCountdownHandler : MonoBehaviour
{
    public TimerManager manager;

    public void OnButtonClick()
    {
        manager.ToggleCountdown();
    }
}