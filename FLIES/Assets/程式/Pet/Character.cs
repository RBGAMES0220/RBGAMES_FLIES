using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float attackDamage = 10f; // 攻擊傷害值

    public void Attack(GameObject target)
    {
        Enemy enemy = target.GetComponent<Enemy>(); // 從目標物件中獲取 Enemy 腳本
        if (enemy != null)
        {
            enemy.TakeDamage(attackDamage); // 如果目標物件具有 Enemy 腳本，調用其 TakeDamage 方法並傳遞攻擊傷害值
        }
    }
}
