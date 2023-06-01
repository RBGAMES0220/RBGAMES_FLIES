using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100; // 最大生命值
    public int currentHealth; // 當前生命值

    public Slider healthSlider; // 生命條Slider

    private void Start()
    {
        currentHealth = maxHealth; // 初始化當前生命值為最大生命值

        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth; // 設定生命條的最大值
            healthSlider.value = currentHealth; // 設定生命條的當前值
        }
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount; // 扣除傷害值

        if (healthSlider != null)
        {
            healthSlider.value = currentHealth; // 更新生命條的當前值
        }

        if (currentHealth <= 0)
        {
            Die(); // 生命值小於等於0時，敵人死亡
        }
    }

    private void Die()
    {
        // 敵人死亡的處理邏輯
        Debug.Log("Enemy died!");
        // 可以在這裡添加更多的邏輯，例如刪除敵人、顯示掉落物品等等
    }
}
