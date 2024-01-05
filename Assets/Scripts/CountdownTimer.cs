using UnityEngine;
using UnityEngine.UI;
using System;

public class CountdownTimer : MonoBehaviour
{
    public Slider timeSlider;
    public Text countdownText; // カウントダウンの時間を表示するテキスト
    public Text endTimeText; // 終了時刻を表示するテキスト
    public Button startButton;
    public GameObject sliderHandle; // スライダーのハンドルへの参照
    public int maxTimeInMinutes = 120;

    private float initialTime;
    private bool isCountingDown = false;

    void Start()
    {
        timeSlider.maxValue = maxTimeInMinutes / 5;
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
        initialTime = timeSlider.value * 5 * 60;
        UpdateCountdownText();
        SetEndTime(initialTime); // スライダーの値が変更されるたびに終了時刻を更新
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
            timeSlider.interactable = false; // スライダーを動かせなくする
            sliderHandle.SetActive(false); // スライダーのハンドルを非表示にする
        }
    }

    void StopCountdown()
    {
        isCountingDown = false;
        startButton.GetComponentInChildren<Text>().text = "開始";
        timeSlider.interactable = true; // スライダーを再び動かせるようにする
        sliderHandle.SetActive(true); // スライダーのハンドルを再表示する
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
