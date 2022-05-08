using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInfo :MonoBehaviour 
{
    public bool IsActive = false;
    public bool IsWorking = false;
    float Timer =0f;
    GameObject NpcObject;

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
                IsWorking = false;
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
