using UnityEngine;

public class CentralUIManager : MonoBehaviour
{
    public static CentralUIManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        MusicManager.instance.PlayDefaultBGM();
    }

    // UI要素の表示状態を切り替えるメソッド
    public void ToggleUIElement(GameObject element, bool isVisible)
    {
        if (element != null)
        {
            element.SetActive(isVisible);
        }
    }
}
