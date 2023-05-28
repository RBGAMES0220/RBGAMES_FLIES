using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    public int score = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            // 碰撞到的物件是「Item」標籤
            Destroy(collision.gameObject); // 銷毀物件
            score++; // 增加分數
        }
    }
}

