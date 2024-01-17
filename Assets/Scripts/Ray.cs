using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIRaycastDebugger : MonoBehaviour
{
    void Update()
    {
        // ユーザーがマウスボタンを押したかチェック（0は左ボタン）
        if (Input.GetMouseButtonDown(0))
        {
            PointerEventData pointerData = new PointerEventData(EventSystem.current)
            {
                pointerId = -1,
            };

            pointerData.position = Input.mousePosition;

            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerData, results);

            foreach (RaycastResult result in results)
            {
                Debug.Log("Hit " + result.gameObject.name);
            }
        }
    }
}
