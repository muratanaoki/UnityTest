using UnityEngine;
using Zenject;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;
    public AudioSource musicSource;

    private const string path = "Audio/";

    [Inject]
    private IDatabaseManager _databaseManager;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Test(string musicName)
    {
        AudioClip selectClip = Resources.Load<AudioClip>(path + musicName);
        // If different music is played than the one currently playing, change the music.
        musicSource.clip = selectClip;
        _databaseManager.UpdateDefaultWorkBGM(musicName);
        musicSource.Play();
    }


    public void PlayWorkBGM(string musicName)
    {
        AudioClip selectClip = Resources.Load<AudioClip>(path + musicName);
        // If different music is played than the one currently playing, change the music.
        if (!selectClip)
        {
            _databaseManager.UpdateDefaultWorkBGM("mute");
            StopMusic();
            return;
        }

        if (musicSource.clip != selectClip)
        {
            musicSource.clip = selectClip;
            _databaseManager.UpdateDefaultWorkBGM(musicName);
            musicSource.Play();
        }
        else
        {
            _databaseManager.UpdateDefaultWorkBGM("mute");
            StopMusic();
        }
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }
}
