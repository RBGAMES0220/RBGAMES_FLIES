using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 5f; // 玩家移動速度
    public float jumpForce = 10f; // 跳躍力度
    public int maxJumps = 2; // 最大跳躍次數
    public Collider2D coll;
    public Animator anim;
    public LayerMask ground;

    private Rigidbody2D rb; // Rigidbody2D組件
    private int jumpCount = 0; // 當前跳躍次數
    private bool isGrounded = false; // 玩家是否在地面上
    private float movement = 0f; // 左右移動輸入

    // 初始化
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // 取得Rigidbody2D組件
    }

    // 獲取左右移動輸入和跳躍輸入
    void Update()
    {
        movement = Input.GetAxisRaw("Horizontal"); // 讀取左右移動輸入

        if (Input.GetButtonDown("Jump") && (isGrounded || jumpCount < maxJumps))
        {
            jumpCount++;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            anim.SetBool("jumping", true);
        }
    }

    // 玩家移動
    void FixedUpdate()
    {
        rb.velocity = new Vector2(movement * moveSpeed * Time.deltaTime, rb.velocity.y);

        if (movement > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f); // 面向右
        }
        else if (movement < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f); // 面向左
        }

        anim.SetFloat("running", Mathf.Abs(movement));
        SwitchAnim();
    }

    // 重置跳躍次數
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            jumpCount = 0;
            
        }
    }

    void SwitchAnim()
    {
        anim.SetBool("idle", false);

        if (anim.GetBool("jumping"))
        {
            if(rb.velocity.y < 0)
            {
                anim.SetBool("jumping", false);
                anim.SetBool("falling", true);
            }

            else if (rb.velocity.y > 0)
            {
                anim.SetBool("jumping", true);
                anim.SetBool("falling", false);
            }
        }
        else if (coll.IsTouchingLayers(ground))
        {
            anim.SetBool("falling", false);
            anim.SetBool("idle", true);
        }         

    }
}







