using UnityEngine;

public class PlayMusicHandler : MonoBehaviour
{
    public string musicName;

    public void OnButtonClick()
    {
        MusicManager.instance.PlayWorkBGM(musicName);
    }
}