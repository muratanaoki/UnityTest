using UnityEngine;
using UnityEngine.UI;
using System;
using Zenject;

public class CountdownTimer : MonoBehaviour
{
    public Slider timeSlider;
    public Text countdownText; // カウントダウンの時間を表示するテキスト
    public Text endTimeText; // 終了時刻を表示するテキスト
    public Button startButton;
    public GameObject sliderHandle; // スライダーのハンドルへの参照
    public int maxTimeInMinutes; 

    private float initialTime;
    private bool isCountingDown = false;
    private float initialSliderValue = 1; // スライダーの初期位置を保持する変数（1 = 5分）

    [Inject]
    private IDatabaseManager _databaseManager;

    void Start()
    {
        // データベースからユーザー設定を取得します。
        UserSetting userSettings = _databaseManager.GetUserSetting();
        if (userSettings != null)
        {
            // データベースから取得した設定を使用してスライダーの値を設定します。
            maxTimeInMinutes = userSettings.DefaultMaxTime;
            initialSliderValue = userSettings.DefaultFocusTime / 5f; // 仮定：DefaultFocusTime は分単位です
        }

        timeSlider.maxValue = maxTimeInMinutes / 5;
        timeSlider.minValue = 1;
        timeSlider.value = initialSliderValue;
        timeSlider.wholeNumbers = true;
        timeSlider.onValueChanged.AddListener(delegate { SliderChanged(); });
        startButton.onClick.AddListener(ToggleCountdown);
        SliderChanged(); // スライダーの初期値に基づいてテキストを更新します。
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
        SetEndTime(initialTime);
    }

    void ToggleCountdown()
    {
        if (isCountingDown)
        {
            StopCountdown();
        }
        else
        {
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

    void StopCountdown()
    {
        isCountingDown = false;
        startButton.GetComponentInChildren<Text>().text = "スタート";
        timeSlider.interactable = true;
        sliderHandle.SetActive(true);
        timeSlider.value = initialSliderValue; // "やめる"が押されたら、スライダーを初期位置に戻す
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
}
