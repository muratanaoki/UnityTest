using UnityEngine;

public class PlayMusicHandler : MonoBehaviour
{
    public BGMDialogManager manager;
    public string musicName;

    public void OnButtonClick()
    {
        manager.PlayWorkBGM(musicName);
    }
}