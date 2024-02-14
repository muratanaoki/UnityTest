using UnityEngine;
using Zenject;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;
    public AudioSource musicSource;

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

    public void PlayMusic(string musicName)
    {
        AudioClip clip = Resources.Load<AudioClip>("Audio/" + musicName);
        if (musicSource.clip != clip)
        {
            musicSource.clip = clip;
            _databaseManager.UpdateDefaultMainBGM(musicName);
            musicSource.Play();
        }
        else if (!musicSource.isPlaying)
        {
            musicSource.Play();
        }
        else
        {
            musicSource.Stop();
        }
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }
}
