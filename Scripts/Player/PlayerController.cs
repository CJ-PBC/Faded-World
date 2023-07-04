using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//先作一首小诗来安抚一下C#之神和Unity之神
/*啊！伟大的C#之神！你统领着游戏的所有脚本！
 * 赞美的言语只能通过运行来表达你对我的信任！
 * 啊！伟大的Unity之神！你管理着游戏的运行！
 * 那卑微的虫子和黄色小三角不足以成为您的敌人！
 * 就让我对您的敬仰化作那精美绝伦的游戏吧！
 */

public class PlayerController : MonoBehaviour
{
    [Header("物理")]
    public Rigidbody2D rb;
    public float speed;
    public float jumpForce,jumpDur,jumpDurLeft;
    public bool isJump;

    [Header("碰撞")]
    public Collider2D collBottom, collMain;
    public LayerMask ground;

    //这是一段中文注释
    //THIS IS A PIECE OF FUCKING TEXT
    /*
     * 我是王玉才的狗
     * I LOVE BUG
     * 我爱漏洞
     */



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //以既定频率执行的
    void FixedUpdate()
    {
        Move();
        Jump();
    }

    //以实际帧率执行的
    void Update()
    {
        
    }

    public void Move()
    {
        float hori=Input.GetAxis("Horizontal"),
              face= Input.GetAxisRaw("Horizontal");

        //速度
        if (hori != 0)
        {
            rb.velocity = new Vector2(speed * hori, rb.velocity.y);
        }
        //朝向
        if (face != 0)
        {
            transform.localScale = new Vector3(face, transform.localScale.y, transform.localScale.z);
        }

    }

    public void Jump()
    {
        isJump = Input.GetButton("Jump");

        if (isJump && jumpDurLeft>0)
        {
            rb.velocity = new Vector2(rb.velocity.x,jumpForce);
            jumpDurLeft -= 0.1f;
        }
        else if (collBottom.IsTouchingLayers(ground))
        {
            jumpDurLeft = jumpDur;
        }
        else
        {
            jumpDurLeft = 0f;
        }
    }

}
