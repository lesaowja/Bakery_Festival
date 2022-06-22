using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool LookRight = true;

    public float Speed;
    Rigidbody2D rigid;
    DropFoodsPointMng dropfoodMng;

    DropFoodsStartTImers FoodTimer;
    public bool IsMove = false;
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
    private void Start()
    {
        FoodTimer = GameObject.Find("GameMng").GetComponent<DropFoodsStartTImers>();
        dropfoodMng = GameObject.Find("GameMng").GetComponent<DropFoodsPointMng>();

        StartCoroutine("StartGame");
    }
    IEnumerator StartGame()
    {
        if (FoodTimer.IsStart)
        {
            IsMove = true;
        }
        else
        {

            yield return new WaitForSeconds(0.1f);
            StartCoroutine("StartGame");
        }
    }
    private void FixedUpdate()
    {
        if(!FoodTimer.IsStart)
        {

        }
        else
        {
            if (IsMove)
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
        }
       
       
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Food1")
        {
            Destroy(collision.gameObject);
            dropfoodMng.GetFirstBread();
        }
        //2�� ũ�ξƻ�
        if (collision.gameObject.tag == "Food2")
        {
            Destroy(collision.gameObject);
            dropfoodMng.GetSecondBread();
        }
        //��Ÿ�� 3�� ���ٿ��� 3�� ���� ��
        if (collision.gameObject.tag == "Food")
        {
            Destroy(collision.gameObject);
            dropfoodMng.GetThirdBread();
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
