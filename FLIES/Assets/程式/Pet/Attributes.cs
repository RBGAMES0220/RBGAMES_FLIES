using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attributes : MonoBehaviour
{
    public class Pet
    {
        public string Name { get; set; } // 寵物名稱
        public int Level { get; set; } // 寵物等級
        public int MaxHealth { get; set; } // 寵物最大血量
        public int CurrentHealth { get; set; } // 寵物當前血量
        public int Attack { get; set; } // 寵物攻擊力
        public int Defense { get; set; } // 寵物防禦力
        public int Speed { get; set; } // 寵物速度
        public int Experience { get; set; } // 寵物經驗值
        public int SkillPoints { get; set; } // 寵物技能點

        public void TrainSkill(string skill)
        {
            // 寵物進行技能訓練，消耗技能點等等
        }

    }

}
