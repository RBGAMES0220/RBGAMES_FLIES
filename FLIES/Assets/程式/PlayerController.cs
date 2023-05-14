using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 5f; // 玩家移動速度
    public float jumpForce = 10f; // 跳躍力度
    public int maxJumps = 2; // 最大跳躍次數

    private Rigidbody2D rb; // Rigidbody2D組件
    private int jumpCount = 0; // 當前跳躍次數
    private bool isGrounded = false; // 玩家是否在地面上

    // 初始化
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // 取得Rigidbody2D組件
    }

    // 獲取左右移動輸入和跳躍輸入
    void Update()
    {
        // 讀取左右移動輸入
        float movement = Input.GetAxisRaw("Horizontal");

        // 判斷玩家是否在地面上
        isGrounded = Physics2D.OverlapCircle(transform.position, 0.2f, LayerMask.GetMask("Ground"));

        // 判斷是否按下跳躍按鈕並且在地面上或可以二段跳
        if (Input.GetButtonDown("Jump") && (isGrounded || jumpCount < maxJumps))
        {
            // 增加跳躍次數
            jumpCount++;
            // 設置y軸上的速度
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        // 設置玩家的velocity，使其左右移動
        rb.velocity = new Vector2(movement * moveSpeed * Time.deltaTime, rb.velocity.y);

        // 設置玩家的方向，使其朝向左或右
        if (movement > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f); // 面向右
        }
        else if (movement < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f); // 面向左
        }
    }

    // 重置跳躍次數
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            jumpCount = 0;
        }
    }
}







