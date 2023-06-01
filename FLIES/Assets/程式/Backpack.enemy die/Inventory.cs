using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>(); // 存儲物品的列表
    public GameObject itemPrefab; // 物品預製體
    public Transform inventoryPanel; // 背包面板的Transform

    private void Start()
    {
        // 在背包中生成一些示例物品
        for (int i = 0; i < 10; i++)
        {
            AddItem(new Item("Item " + i, "This is item " + i));
        }
    }

    public void AddItem(Item item)
    {
        items.Add(item); // 將物品添加到背包列表中
        // 在背包面板中生成新物品的圖像
        GameObject newItem = Instantiate(itemPrefab, inventoryPanel);
        // 在新物品上設定顯示的文字
        newItem.GetComponentInChildren<UnityEngine.UI.Text>().text = item.name;
    }

    public void CraftItem(Item item)
    {
        // 檢查合成所需的材料是否存在於背包中
        bool hasMaterials = true;
        foreach (Item material in item.materials)
        {
            if (!items.Contains(material))
            {
                hasMaterials = false;
                break;
            }
        }

        if (hasMaterials)
        {
            // 從背包中移除合成所需的材料
            foreach (Item material in item.materials)
            {
                items.Remove(material);
            }

            // 添加合成物品到背包中
            AddItem(item);
        }
    }
}

public class Item
{
    public string name; // 物品名稱
    public string description; // 物品描述
    public List<Item> materials; // 合成所需的材料列表

    public Item(string name, string description)
    {
        this.name = name;
        this.description = description;
        materials = new List<Item>(); // 初始化材料列表
    }

    public void AddMaterial(Item material)
    {
        materials.Add(material); // 添加材料到材料列表中
    }
}
