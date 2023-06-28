using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    public int damageAmount = 10; // 地刺造成的傷害值

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 檢查觸發地刺陷阱的對象是否是玩家
        PlayerHealth Player = other.GetComponent<PlayerHealth>();
        if (Player != null)
        {
            // 對玩家造成傷害
            Player.TakeDamage(damageAmount);
        }
    }
}
