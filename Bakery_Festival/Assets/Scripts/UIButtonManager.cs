using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonManager : MonoBehaviour
{
    public GameObject[] Panels = new GameObject[6];
    private int Key = 0;
    private bool IsActive = false;

    
    //2���� �������� ������ ���� Ű�� ���� �����ִ����� Ȯ���ϱ� ���� �Լ�
    bool SecondPanelHasActives = false;
    MainSecondPanel secondPanelControll;

    public void FirstButPress()
    {
        GameObject.Find("SecondPanel").GetComponent<MainSecondPanel>().SecondPanelOff();
        Key =1; 
        CheckActive(Key);
    }
    public void SecondButPress()
    {
        GameObject.Find("SecondPanel").GetComponent<MainSecondPanel>().SecondPanelOff();
        //��Ű�� �������� ��� ���� �����
        Key = 2;  
        CheckActive(Key);
    }
    public void ThirdPress()
    {
        GameObject.Find("SecondPanel").GetComponent<MainSecondPanel>().SecondPanelOff();
        Key = 3;  
        CheckActive(Key);
    }
    public void FourthPress()
    {
        GameObject.Find("SecondPanel").GetComponent<MainSecondPanel>().SecondPanelOff();
        Key =4;  
        CheckActive(Key);
    }

    public void CheckActive(int _Key)
    {
        if (_Key == 2)
        {
            
            PanelActivities(_Key);
           
        }
        else
        {
            if (Panels[_Key - 1].activeSelf == true)
            {

                Panels[_Key - 1].SetActive(false);

            }
            else
            {
                PanelActivities(_Key);
            }
        }

       
        
    }


    public void PanelActivities(int __Key)
    {
        if (__Key == 2)
        {
           
            for (int i = 0; i < 5; i++)
            { 
                if (i == 1) {
                     
                }
                else
                {
                    Panels[i].SetActive(false);
                }            
            }
        }
        else
        {
            for (int i = 0; i < 5; i++)
            {
                if (i == 1)
                {

                }
                else
                {
                    if (i == __Key - 1)
                    {
                        Panels[i].SetActive(true);
                        Debug.Log(i + "��° �г� �ѱ� �Ϸ�!");
                    }
                    
                }


            }
        }
        
    }

}
