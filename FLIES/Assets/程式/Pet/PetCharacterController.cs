using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public Character character; // 角色物件
    private Camera mainCamera; // 主攝影機

    private void Start()
    {
        mainCamera = Camera.main; // 取得主攝影機的引用
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 當滑鼠左鍵按下時
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition); // 從滑鼠位置發射一條射線
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction); // 執行射線檢測碰撞
            if (hit.collider != null)
            {
                character.Attack(hit.collider.gameObject); // 如果有碰撞到物件，呼叫角色的攻擊方法，並傳遞碰撞到的物件
            }
        }
    }
}
