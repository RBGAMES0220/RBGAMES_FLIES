using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public GameObject inventoryPanel; // 引用背包介面面板的遊戲對象

    private void Update()
    {
        // 按下指定按鍵時打開或關閉背包
        if (Input.GetKeyDown(KeyCode.B))
        {
            ToggleInventory();
        }
    }

    public void ToggleInventory()
    {
        inventoryPanel.SetActive(!inventoryPanel.activeSelf);
    }
}
