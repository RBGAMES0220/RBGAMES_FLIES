using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet : MonoBehaviour
{
    public string petName; // 寵物名稱
    public int level; // 寵物等級
    public int maxHealth; // 最大生命值
    public int currentHealth; // 當前生命值

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // 減少生命值
        if (currentHealth <= 0)
        {
            Die(); // 當生命值小於等於 0 時，寵物死亡
        }
    }

    private void Die()
    {
        // 在這裡撰寫寵物死亡的處理邏輯
        Debug.Log(petName + " has died.");
        // 其他死亡相關的處理...
    }
}
