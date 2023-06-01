using UnityEngine;

public class WeaponSelection : MonoBehaviour
{
    public GameObject[] weapons; // 儲存可供選擇的武器

    private int currentWeaponIndex = 0; // 目前選擇的武器的索引值

    private void Start()
    {
        // 開始時將第一把武器設為起始武器
        SetWeapon(currentWeaponIndex);
    }

    private void Update()
    {
        // 滾輪向上滾動，切換到下一把武器
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            currentWeaponIndex++;
            if (currentWeaponIndex >= weapons.Length)
            {
                currentWeaponIndex = 0;
            }
            SetWeapon(currentWeaponIndex);
        }

        // 滾輪向下滾動，切換到上一把武器
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            currentWeaponIndex--;
            if (currentWeaponIndex < 0)
            {
                currentWeaponIndex = weapons.Length - 1;
            }
            SetWeapon(currentWeaponIndex);
        }
    }

    // 切換武器的方法
    private void SetWeapon(int index)
    {
        // 關閉所有武器
        foreach (GameObject weapon in weapons)
        {
            weapon.SetActive(false);
        }

        // 開啟目前選擇的武器
        weapons[index].SetActive(true);
    }
}
