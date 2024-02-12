using UnityEngine;

public class PanelMenuBlackoutCurtainHandler : MonoBehaviour
{
    // UIマネージャーの参照
    public MenuDialogManager manager;

    // ボタンがクリックされたときに呼び出されるメソッド
    public void OnButtonClick()
    {
        manager.OnPanelMenuBlackoutCurtainClicked(); // UIマネージャーを通じてダイアログを開く
    }
}