using UnityEngine;

public class SliderChangedHandler : MonoBehaviour
{
    public TimerManager manager;

    public void onValueChanged()
    {
        manager.SliderChanged();
    }
}