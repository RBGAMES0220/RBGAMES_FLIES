using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetTraining : MonoBehaviour
{
    public Pet pet; // 參考寵物類別的實例
    public int levelUpCost; // 升級所需的花費
    public int healthUpCost; // 增加生命值所需的花費

    public void LevelUp()
    {
        if (pet.level >= 10)
        {
            Debug.Log("已達最高等級");
            return;
        }

        if (GameController.Instance.money < levelUpCost)
        {
            Debug.Log("金幣不足");
            return;
        }

        pet.level++; // 提升寵物等級
        GameController.Instance.money -= levelUpCost; // 扣除升級花費的金幣
    }

    public void HealthUp()
    {
        if (pet.currentHealth == pet.maxHealth)
        {
            Debug.Log("生命值已滿");
            return;
        }

        if (GameController.Instance.money < healthUpCost)
        {
            Debug.Log("金幣不足");
            return;
        }

        pet.currentHealth = pet.maxHealth; // 將寵物的當前生命值設置為最大生命值
        GameController.Instance.money -= healthUpCost; // 扣除增加生命值花費的金幣
    }
}
