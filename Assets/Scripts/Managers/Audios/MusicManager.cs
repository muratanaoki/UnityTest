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

        if (!selectClip)
        {
            StopMusic();
            return;
        }
        musicSource.clip = selectClip;
        _databaseManager.UpdateDefaultWorkBGM(musicName);
        musicSource.Play();
    }

    public void StopMusic()
    {
        _databaseManager.UpdateDefaultWorkBGM("mute");
        musicSource.Stop();
    }
}