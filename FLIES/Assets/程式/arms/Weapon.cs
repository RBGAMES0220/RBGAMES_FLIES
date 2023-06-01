using UnityEngine;

public class Weapon : MonoBehaviour
{
    public string weaponName; // 武器名稱
    public int damage; // 武器傷害值
    public float attackSpeed; // 武器攻擊速度

    public void Attack()
    {
        // 武器的攻擊邏輯
        // 可以在這裡添加攻擊的動畫、聲音效果等等
    }

    public void SpecialAbility()
    {
        // 武器的特殊能力邏輯
        // 可以在這裡添加特殊能力的效果、特效等等
    }
}

public class WeaponController : MonoBehaviour
{
    public Weapon[] weapons; // 玩家擁有的武器陣列
    private int currentWeaponIndex; // 當前武器的索引

    private void Start()
    {
        currentWeaponIndex = 0; // 初始化當前武器索引為0
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            weapons[currentWeaponIndex].Attack(); // 當按下Fire1按鍵時，使用當前武器進行攻擊
        }

        if (Input.GetButtonDown("Fire2"))
        {
            weapons[currentWeaponIndex].SpecialAbility(); // 當按下Fire2按鍵時，使用當前武器的特殊能力
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SwitchWeapon(); // 當按下Tab鍵時，切換武器
        }
    }

    private void SwitchWeapon()
    {
        currentWeaponIndex++; // 切換到下一個武器索引
        if (currentWeaponIndex >= weapons.Length)
        {
            currentWeaponIndex = 0; // 如果索引超出陣列範圍，則回到第一個武器
        }

        // 在這裡可以顯示切換武器的提示或動畫效果等等
    }
}
