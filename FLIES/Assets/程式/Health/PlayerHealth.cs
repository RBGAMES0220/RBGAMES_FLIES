using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // 玩家的最大生命值
    public int currentHealth; // 玩家的當前生命值

    private void Start()
    {
        currentHealth = maxHealth; // 將當前生命值初始化為最大生命值
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount; // 扣除傷害值

        if (currentHealth <= 0)
        {
            Die(); // 如果生命值小於等於0，則觸發死亡事件
        }
    }

    private void Die()
    {
        // 玩家死亡的處理邏輯
        Debug.Log("Player died!"); // 在控制台輸出死亡消息
        // 可以在這裡添加更多的邏輯，例如顯示死亡畫面、重新開始遊戲等等
    }
}
