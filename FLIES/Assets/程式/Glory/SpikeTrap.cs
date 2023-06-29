using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    public int damageAmount = 10; // 地刺造成的傷害值
    public float damageInterval = 1f; // 傷害間隔時間

    private float damageTimer; // 傷害計時器

    private void OnTriggerStay2D(Collider2D other)
    {
        // 檢查觸發地刺陷阱的對象是否是玩家
        PlayerHealth player = other.GetComponent<PlayerHealth>();
        if (player != null)
        {
            // 更新傷害計時器
            damageTimer += Time.deltaTime;

            // 檢查是否達到傷害間隔時間
            if (damageTimer >= damageInterval)
            {
                // 對玩家造成傷害
                player.TakeDamage(damageAmount);

                // 重置傷害計時器
                damageTimer = 0f;
            }
        }
    }
}

