using UnityEngine;
using Zenject;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;
    public AudioSource musicSource;

    private const string pathWorkBGM = "WorkBGM/";

    private const string pathDefaultBGM = "DefaultBGM/bgm";

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

    public void PlayDefaultBGM()
    {
        AudioClip selectClip = Resources.Load<AudioClip>(pathDefaultBGM);
        musicSource.clip = selectClip;
        musicSource.Play();
    }

    public void PlayWorkBGM(string musicName)
    {
        AudioClip selectClip = Resources.Load<AudioClip>(pathWorkBGM + musicName);

        if (!selectClip)
        {
            StopMusic();
            return;
        }
        musicSource.clip = selectClip;
        _databaseManager.UpdateDefaultWorkBGM(musicName);
        musicSource.Play();
    }

    public void PlayMute()
    {
        _databaseManager.UpdateDefaultWorkBGM("mute");
        musicSource.Stop();
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }


}
