using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int damage;
    public float time;

    private Animator anim;
    private PolygonCollider2D collider2D;
    // Start is called before the first frame update
    void Start()
    {
        
        collider2D = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Attack()
    {
        if (Input.GetButtonDown("Attack"))
        {
            collider2D.enabled = true;
            anim.SetTrigger("Attack");
            StartCoroutine(disableHitBox());
        }
    }

    IEnumerator disableHitBox()
    {
        yield return new WaitForSeconds(time);
        collider2D.enabled = false;
    }
}
