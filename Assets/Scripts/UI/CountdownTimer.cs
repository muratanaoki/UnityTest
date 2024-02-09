using UnityEngine;
using UnityEngine.UI;
using System;
using Zenject;

public class CountdownTimer : MonoBehaviour
{
    public Slider timeSlider;
    public Text countdownText;
    public Text endTimeText;
    public Button startButton;
    public GameObject sliderHandle;
    public int maxTimeInMinutes;

    private float initialTime;
    private bool isCountingDown = false;
    private float initialSliderValue = 1;

    [Inject]
    private IDatabaseManager _databaseManager;

    void Start()
    {
        UserSetting userSettings = _databaseManager.GetUserSetting();
        if (userSettings != null)
        {
            maxTimeInMinutes = userSettings.DefaultMaxTime;
            initialSliderValue = userSettings.DefaultFocusTime / 5f;
        }

        timeSlider.maxValue = maxTimeInMinutes / 5;
        timeSlider.minValue = 1;
        timeSlider.value = initialSliderValue;
        timeSlider.wholeNumbers = true;
        timeSlider.onValueChanged.AddListener(delegate { SliderChanged(); });
        startButton.onClick.AddListener(ToggleCountdown);
        SliderChanged();
    }

    void Update()
    {
        if (isCountingDown)
        {
            if (initialTime > 0)
            {
                initialTime -= Time.deltaTime;
                timeSlider.value = Mathf.RoundToInt(initialTime / 60 / 5);
                UpdateCountdownText();
            }
            else
            {
                StopCountdown(true); // カウントダウンが自然に終了したことを示すために true を渡す
            }
        }
    }

    void SliderChanged()
    {
        initialTime = timeSlider.value * 5 * 60;
        UpdateCountdownText();
        SetEndTime(initialTime);
    }

    void ToggleCountdown()
    {
        if (isCountingDown)
        {
            timeSlider.value = _databaseManager.GetUserSetting().DefaultFocusTime / 5f;
            StopCountdown(false); // ユーザーが 'やめる' を押したことを示すために false を渡す
        }
        else
        {
            _databaseManager.UpdateDefaultFocusTime(Mathf.RoundToInt(timeSlider.value * 5));
            StartCountdown();
        }
    }

    void StartCountdown()
    {

        isCountingDown = true;
        startButton.GetComponentInChildren<Text>().text = "やめる";
        timeSlider.interactable = false;
        sliderHandle.SetActive(false);
    }

    // StopCountdown に bool パラメータを追加して、カウントダウンの完了状態を示します
    void StopCountdown(bool completed)
    {

        isCountingDown = false;
        startButton.GetComponentInChildren<Text>().text = "スタート";
        timeSlider.interactable = true;
        sliderHandle.SetActive(true);

        if (completed)
        {
            int gainedExperience = CalculateExperienceFromTime(initialTime);
            var (newLevel, newExperiencePoints) = PlayerProgressManager.CalculateNewPlayerState(PlayerSession.Instance.CurrentButlerData.IntimacyLevel, PlayerSession.Instance.CurrentButlerData.ExperiencePoints, gainedExperience);
            PlayFabDataManager.Instance.UpdateButlerExperienceAndIntimacy(newExperiencePoints, newLevel);
        }

        timeSlider.value = initialSliderValue;
        ResetTimer();
    }

    void ResetTimer()
    {
        initialTime = timeSlider.value * 5 * 60;
        UpdateCountdownText();
    }

    void UpdateCountdownText()
    {
        int totalSeconds = Mathf.RoundToInt(initialTime);
        int hours = totalSeconds / 3600;
        int minutes = (totalSeconds % 3600) / 60;
        int seconds = totalSeconds % 60;

        countdownText.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
    }

    void SetEndTime(float duration)
    {
        DateTime endTime = DateTime.Now.AddSeconds(duration);
        endTimeText.text = "終了時刻: " + endTime.ToString("HH:mm");
    }

    int CalculateExperienceFromTime(float time)
    {
        return Mathf.FloorToInt(time / 60);
    }
}
