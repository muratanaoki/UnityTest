using UnityEngine;

public class CentralUIManager : MonoBehaviour
{
    public static CentralUIManager Instance { get; private set; }

    // UI要素への参照
    public GameObject buttonBGM;

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

    // UI要素の表示状態を切り替えるメソッド
    public void ToggleUIElement(GameObject element, bool isVisible)
    {
        if (element != null)
        {
            element.SetActive(isVisible);
        }
    }
}
