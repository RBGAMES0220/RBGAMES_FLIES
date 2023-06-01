using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; } // GameController 的單例實例

    public int money; // 玩家的金錢

    private void Awake()
    {
        if (Instance == null) // 檢查單例實例是否為空
        {
            Instance = this; // 如果是空，將當前實例設置為單例實例
        }
        else
        {
            Destroy(gameObject); // 如果單例實例已存在，銷毀當前物件，以確保只有一個 GameController 實例存在
        }
    }
}
