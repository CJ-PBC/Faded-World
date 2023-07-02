using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("物理")]
    public Rigidbody2D rb;
    public float speed=4f;

    //这是一段中文注释
    //THIS IS A PIECE OF FUCKING TEXT
    /*
     * I LOVE BUG
     * 我爱漏洞
     */



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
    }

    public void Move()
    {
        float hori=Input.GetAxis("Horizontal"),
              face= Input.GetAxisRaw("Horizontal");

        if (hori != 0)
        {
            rb.velocity = new Vector2(speed * hori, rb.velocity.y);
        }
         
        if (face != 0)
        {
            transform.localScale = new Vector3(face, transform.localScale.y, transform.localScale.z);
        }

    }

}
