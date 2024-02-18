using UnityEngine;
using UnityEngine.UI;
using System;
using Zenject;

public class TimerManager : MonoBehaviour
{
    public Slider timeSlider;
    public Text countdownText;
    public Text endTimeText;
    public Button startButton;
    public GameObject sliderHandle;
    public int maxTimeInMinutes;

    public HeaderManager headerManger;

    private float initialTime;
    private bool isCountingDown = false;
    private float initialSliderValue = 1;

    [Inject]
    private IDatabaseManager _databaseManager;

    private void HandleInitializationCompleted(string playFabId)
    {
        if (!string.IsNullOrEmpty(playFabId))
        {
            // ログインが成功し、PlayFabIdが返された場合の処理
            Debug.Log($"UIManager: Login succeeded. PlayFabId: {playFabId}");
            this.InitializeAndStart();
            // ここでUIを更新したり、ユーザーに成功を通知したりします
        }
        else
        {
            // ログインが失敗した場合の処理
            Debug.LogError("UIManager: Login failed.");
            // ここでエラーメッセージを表示したり、再試行を促したりします
        }
    }

    private void OnEnable()
    {
        // InitializationManagerのイベントに対するリスナーを登録
        InitializationManager.OnInitializationCompleted += HandleInitializationCompleted;
    }

    private void OnDisable()
    {
        // オブジェクトが破棄される時にイベントリスナーを解除
        InitializationManager.OnInitializationCompleted -= HandleInitializationCompleted;
    }

    public void InitializeAndStart()
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

    public void SliderChanged()
    {
        initialTime = timeSlider.value * 5 * 60;
        UpdateCountdownText();
        SetEndTime(initialTime);
    }

    public void ToggleCountdown()
    {
        if (isCountingDown)
        {
            headerManger.IsVisbleButtonMenu(true);
            headerManger.IsVisbleButtonBGM(false);
            StopCountdown(false); // ユーザーが 'やめる' を押したことを示すために false を渡す
        }
        else
        {
            headerManger.IsVisbleButtonMenu(false);
            headerManger.IsVisbleButtonBGM(true);
            StartCountdown();
        }
    }

    void StartCountdown()
    {
        UserSetting user = _databaseManager.GetUserSetting();
        MusicManager.instance.PlayWorkBGM(user.DefaultWorkBGM);
        isCountingDown = true;
        startButton.GetComponentInChildren<Text>().text = "やめる";
        timeSlider.interactable = false;
        _databaseManager.UpdateDefaultFocusTime(Mathf.RoundToInt(timeSlider.value * 5));
        sliderHandle.SetActive(false);
    }

    // StopCountdown に bool パラメータを追加して、カウントダウンの完了状態を示します
    void StopCountdown(bool completed)
    {
        MusicManager.instance.StopMusic();
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

        timeSlider.value = _databaseManager.GetUserSetting().DefaultFocusTime / 5f;
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
