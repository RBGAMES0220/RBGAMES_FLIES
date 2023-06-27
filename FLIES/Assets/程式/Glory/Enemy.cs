using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float patrolSpeed = 5f; // 巡邏時的移動速度
    public float chaseSpeed = 8f; // 追逐時的移動速度
    public Transform[] waypoints; // 巡邏路徑節點的陣列
    private int currentWaypointIndex = 0; // 當前巡邏路徑節點的索引
    private Rigidbody2D rb;
    private bool isFacingRight = true; // 是否面向右邊
    private Transform target; // 玩家的參考點或物件
    public float threshold = 0.1f; // 到達目標點的距離閾值
    public float detectionRadius = 5f; // 偵測半徑
    public float detectionInterval = 0.2f; // 偵測間隔
    public float attackDistance = 2f; // 攻擊距離
    private Animator animator;

    private enum EnemyState
    {
        Patrol, // 巡邏狀態
        Chase, // 追逐狀態
        Attack // 攻擊狀態
    }

    private EnemyState currentState;
    private float detectionTimer = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform; // 獲取玩家的參考點或物件
        currentState = EnemyState.Patrol;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        detectionTimer += Time.deltaTime;

        switch (currentState)
        {
            case EnemyState.Patrol:
                Patrol(); // 巡邏行為
                break;
            case EnemyState.Chase:
                Chase(); // 追逐行為
                break;
            case EnemyState.Attack:
                Attack(); // 攻擊行為
                break;
        }
    }

    private void Patrol()
    {
        // 獲取當前巡邏路徑節點
        Transform currentWaypoint = waypoints[currentWaypointIndex];

        // 判斷敵人與目標點的相對位置，決定移動方向
        Vector3 direction = (currentWaypoint.position - transform.position).normalized;

        // 移動到目標點
        rb.velocity = new Vector2(direction.x * patrolSpeed, direction.y * patrolSpeed);

        // 根據移動方向來更新面朝方向
        if (direction.x > 0 && !isFacingRight)
        {
            Flip(); // 翻轉面朝方向
        }
        else if (direction.x < 0 && isFacingRight)
        {
            Flip(); // 翻轉面朝方向
        }

        // 判斷是否到達目標點附近
        if (Vector3.Distance(transform.position, currentWaypoint.position) < threshold)
        {
            // 選擇下一個目標點
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;

            // 檢查是否需要切換到追逐狀態
            if (ShouldChase())
            {
                currentState = EnemyState.Chase;
                animator.SetBool("isChasing", true); // 開始追逐動畫
            }
        }
    }

    private void Chase()
    {
        // 判斷是否超出偵測範圍
        if (Vector3.Distance(transform.position, target.position) > detectionRadius)
        {
            currentState = EnemyState.Patrol; // 超出範圍則切換回巡邏狀態
            animator.SetBool("isChasing", false); // 停止追逐動畫
            return;
        }

        // 判斷敵人與玩家的相對位置，決定移動方向
        Vector3 direction = (target.position - transform.position).normalized;

        // 移動向玩家位置
        rb.velocity = new Vector2(direction.x * chaseSpeed, direction.y * chaseSpeed);

        // 根據移動方向來更新面朝方向
        if (direction.x > 0 && !isFacingRight)
        {
            Flip(); // 翻轉面朝方向
        }
        else if (direction.x < 0 && isFacingRight)
        {
            Flip(); // 翻轉面朝方向
        }

        // 檢查是否進入攻擊距離
        if (Vector3.Distance(transform.position, target.position) < attackDistance)
        {
            currentState = EnemyState.Attack;
            animator.SetBool("isChasing", false); // 停止追逐動畫
            animator.SetBool("isAttacking", true); // 開始攻擊動畫
        }
    }

    private void Attack()
    {
        // 攻擊行為，可以根據需求自行實現

        // 檢查是否超出偵測範圍
        if (Vector3.Distance(transform.position, target.position) > detectionRadius)
        {
            currentState = EnemyState.Patrol; // 超出範圍則切換回巡邏狀態
            animator.SetBool("isAttacking", false); // 停止攻擊動畫
            return;
        }

        // 判斷敵人與玩家的相對位置，決定移動方向
        Vector3 direction = (target.position - transform.position).normalized;

        // 移動向玩家位置（可以根據需求自行實現攻擊行為）

        // 根據移動方向來更新面朝方向
        if (direction.x > 0 && !isFacingRight)
        {
            Flip(); // 翻轉面朝方向
        }
        else if (direction.x < 0 && isFacingRight)
        {
            Flip(); // 翻轉面朝方向
        }

        // 檢查是否超出攻擊距離
        if (Vector3.Distance(transform.position, target.position) > attackDistance)
        {
            currentState = EnemyState.Chase; // 超出攻擊距離則切換回追逐狀態
            animator.SetBool("isAttacking", false); // 停止攻擊動畫
            animator.SetBool("isChasing", true); // 開始追逐動畫
        }
        else 
        {
            animator.SetBool("isAttacking", true);
            animator.SetBool("isChasing", false);
        }
    }

    private bool ShouldChase()
    {
        // 檢查敵人與玩家之間的距離是否小於某個閾值，如果是則切換到追逐狀態
        float distanceToTarget = Vector3.Distance(transform.position, target.position);
        return distanceToTarget < detectionRadius;
    }

    private void Flip()
    {
        // 更新面朝方向
        isFacingRight = !isFacingRight;

        // 反轉敵人的X軸尺度，使其面向相對方向
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}





































