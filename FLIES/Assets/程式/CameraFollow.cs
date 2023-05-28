using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target; // 目標跟隨的物體
    public float smoothing = 20f; // 攝影機跟隨的平滑度

    private Vector3 offset; // 攝影機與目標的位置偏移

    // 初始化
    void Start()
    {
        offset = transform.position - target.position; // 計算偏移量
    }

    // 每幀更新攝影機位置
    void LateUpdate()
    {
        Vector3 targetPosition = target.position + offset; // 計算目標位置
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime); // 平滑地移動攝影機到目標位置
    }
}



