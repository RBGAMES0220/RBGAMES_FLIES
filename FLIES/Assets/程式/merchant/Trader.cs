using UnityEngine;

namespace YourNamespace
{
    // 定義物品類別
    public class Item
    {
        public string itemName; // 物品名稱
        public int price; // 物品價格
    }
}

public class Trader : MonoBehaviour
{
    public YourNamespace.Item[] itemsForSale; // 商人販售的物品清單

    // 販售物品
    public void SellItem(YourNamespace.Item itemToSell)
    {
        // 在這裡撰寫處理販售物品的邏輯
        Debug.Log("Sold item: " + itemToSell.itemName);
    }

    // 購買物品
    public void BuyItem(YourNamespace.Item itemToBuy)
    {
        // 在這裡撰寫處理購買物品的邏輯
        Debug.Log("Bought item: " + itemToBuy.itemName);
    }
}
