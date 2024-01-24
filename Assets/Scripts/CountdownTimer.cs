using UnityEngine;
using UnityEngine.UI;
using System;

public class CountdownTimer : MonoBehaviour
{
    public Slider timeSlider;
    public Text countdownText;
    public Text endTimeText;
    public Button startButton;
    public GameObject sliderHandle;
    public int maxTimeInMinutes = 120;

    private float initialTime;
    private bool isCountingDown = false;

    void Start()
    {
        timeSlider.maxValue = maxTimeInMinutes / 5;
        timeSlider.minValue = 1; // スライダーの最小値を1に設定（5分に相当）
        timeSlider.value = 1; // 初期値を5分に設定
        timeSlider.wholeNumbers = true;
        timeSlider.onValueChanged.AddListener(delegate { SliderChanged(); });
        startButton.onClick.AddListener(StartCountdown);
        SliderChanged(); // スライダーの初期値に基づいてテキストを更新
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
                StopCountdown();
            }
        }
    }

    void SliderChanged()
    {
        initialTime = Mathf.Max(5 * 60, timeSlider.value * 5 * 60); // 5分未満には設定できないようにする
        UpdateCountdownText();
        SetEndTime(initialTime);
    }

    void StartCountdown()
    {
        if (isCountingDown)
        {
            StopCountdown();
        }
        else
        {
            isCountingDown = true;
            startButton.GetComponentInChildren<Text>().text = "やめる";
            timeSlider.interactable = false;
            sliderHandle.SetActive(false);
        }
    }

    void StopCountdown()
    {
        isCountingDown = false;
        startButton.GetComponentInChildren<Text>().text = "スタート";
        timeSlider.interactable = true;
        sliderHandle.SetActive(true);
        ResetTimer();
    }

    void ResetTimer()
    {
        timeSlider.value = Mathf.RoundToInt(initialTime / 60 / 5);
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
}
