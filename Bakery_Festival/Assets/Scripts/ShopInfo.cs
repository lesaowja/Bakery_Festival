using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInfo :MonoBehaviour 
{
    public bool IsActive = false;
    public bool IsWorking = false;
    [SerializeField] int ShopNum;
    float Timer =0f;


    ShopManager ShopMng;
    GameObject NpcObject;


    private void Start()
    { 
    }
    private void Update()
    {
        if(IsWorking == true)
        {
            if (Timer > 0)
            {
                Debug.Log(Timer);
                Timer -= Time.deltaTime;
            }
            else
            {
                switch (ShopNum)
                {
                    case 0:

                        break;
                    default:
                        break;
                }
                Destroy(NpcObject);
                
            } 
        }
       
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Timer = 4f;
        NpcObject = collision.gameObject;
    }
    
}
