using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    public GameObject dialog; // ダイアログとして表示するGameObject

    void Start()
    {
        // ダイアログを非表示に設定
        dialog.SetActive(false);
    }
    // メニューボタンが押された時に呼ばれるメソッド
    public void OnMenuButtonClicked()
    {
        // ダイアログの表示状態を切り替える
        dialog.SetActive(!dialog.activeSelf);
    }
}
