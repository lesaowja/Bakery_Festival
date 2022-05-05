using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteScript : MonoBehaviour
{
    public bool IsSpin = false;
    public float SpinSpeed = 0f;

    void Update()
    { 
        if(IsSpin)
        {
            this.SpinSpeed = 20;
        }
        else
        {
            if(SpinSpeed > 0.0001)
            this.SpinSpeed *= 0.997f;
            else
            {
                this.SpinSpeed = 0;
            }
        }
        transform.Rotate(0, 0, this.SpinSpeed);
        
    }

    public void RouletteBut()
    { 
         IsSpin = !IsSpin; 
    }
}
