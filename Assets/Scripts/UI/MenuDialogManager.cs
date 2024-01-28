using UnityEngine;
using UnityEngine.UI;

public class MenuDialogManager : MonoBehaviour
{
    public GameObject dialogPanel;

    void Start()
    {
        dialogPanel.SetActive(false); // 初期状態ではダイアログを非表示にする
    }

    public void ShowDialog()
    {
        dialogPanel.SetActive(true); // ダイアログを表示
    }

    public void HideDialog()
    {
        dialogPanel.SetActive(false); // ダイアログを非表示
    }
}
