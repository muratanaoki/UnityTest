using UnityEngine;
using Zenject;

public class BGMDialogManager : MonoBehaviour
{
    public GameObject canvasBGMDialog;
    public GameObject panelBGMBlackoutCurtain;
    public GameObject panelBGM;

    [Inject]
    private IDatabaseManager _databaseManager;

    void Start()
    {
        canvasBGMDialog.SetActive(false);
    }

    public void OpenCanvasBGMDialog()
    {
        canvasBGMDialog.SetActive(true);
        panelBGMBlackoutCurtain.SetActive(true);
        panelBGM.SetActive(true);
    }

    public void CloseCanvasBGMDialog()
    {
        canvasBGMDialog.SetActive(false);
    }

    public void PlayWorkBGM(string musicName)
    {
        UserSetting user = _databaseManager.GetUserSetting();
        if (user.DefaultWorkBGM == musicName)
        {
            MusicManager.instance.PlayMute();
        }
        else
        {
            MusicManager.instance.PlayWorkBGM(musicName);
        }
    }


}
