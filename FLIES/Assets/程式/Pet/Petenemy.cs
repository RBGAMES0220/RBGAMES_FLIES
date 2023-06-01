using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHealth = 100f; // 最大生命值
    private float currentHealth; // 當前生命值

    private void Start()
    {
        currentHealth = maxHealth; // 初始化當前生命值為最大生命值
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage; // 扣除傷害值

        if (currentHealth <= 0)
        {
            Die(); // 生命值小於等於0時，敵人死亡
        }
    }

    private void Die()
    {
        Destroy(gameObject); // 銷毀敵人物件
    }
}
