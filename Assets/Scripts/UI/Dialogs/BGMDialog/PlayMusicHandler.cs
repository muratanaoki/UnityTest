using UnityEngine;

public class PlayMusicHandler : MonoBehaviour
{
    public AudioClip musicClip;

    public void OnButtonClick()
    {
        MusicManager.instance.PlayMusic(musicClip);
    }
}