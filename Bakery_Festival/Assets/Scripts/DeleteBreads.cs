using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteBreads : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Food1")
        {
            Destroy(collision.gameObject); 
        }
        //2�� ũ�ξƻ�
        if (collision.gameObject.tag == "Food2")
        {
            Destroy(collision.gameObject); 
        }
        //��Ÿ�� 3�� ���ٿ��� 3�� ���� ��
        if (collision.gameObject.tag == "Food")
        {
            Destroy(collision.gameObject); 
        }
    }
}
