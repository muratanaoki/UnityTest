using UnityEngine;

public class InputController : MonoBehaviour
{
    public GameObject targetObject; // タッチを検出したいオブジェクト

    void Update()
    {
        if (Input.touchCount > 0 || Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Input.touchCount > 0 ? Input.GetTouch(0).position : (Vector2)Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(pos);
            RaycastHit hit;

            // VRoidレイヤーのみを対象とするレイヤーマスク
            int layerMask = 1 << LayerMask.NameToLayer("Vroid");

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                if (hit.transform.gameObject == targetObject)
                {
                    // ターゲットオブジェクトがタッチされたときの処理
                    Debug.Log("Target object touched at position: " + pos);
                }
            }
        }
    }
}
