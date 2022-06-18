using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool LookRight = true;

    public float Speed;
    Rigidbody2D rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();

        if (LookRight)
        {
            this.transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            this.transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    private void FixedUpdate()
    {
        if (LookRight)
        {
            rigid.velocity = new Vector2(Speed * Time.deltaTime, rigid.velocity.y);
        }
        else if (!LookRight)
        {
            rigid.velocity = new Vector2((-1) * Speed * Time.deltaTime, rigid.velocity.y);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Food1")
        {
            Destroy(collision.gameObject);
        }
    }
    public void FlipBut()
    {
        LookRight = !LookRight;
        if (LookRight)
        {
            this.transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            this.transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
}