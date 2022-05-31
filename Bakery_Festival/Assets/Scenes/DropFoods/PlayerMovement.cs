using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool LookRight = true;
     
    public float Speed ;
    Rigidbody2D rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LookRight = !LookRight;
        }
        if (Input.GetButtonUp("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
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
            rigid.velocity = new Vector2((-1)*Speed*Time.deltaTime, rigid.velocity.y);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Food1")
        {
            Destroy(collision.gameObject);
        }
    }

}
