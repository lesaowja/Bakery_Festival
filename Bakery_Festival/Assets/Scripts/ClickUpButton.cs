using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickUpButton : Singleton<ClickUpButton>
{
    [SerializeField] Text upgradText;
 
    public string upgradeName;          // ���׷��̵� �̸�

    public int upgradeGold;             // ���׷��̵� �Ǵ� ��差
    //[SerializeField] public int startupgradeGold;    // ó�� ���׷��̵� ���

    public int currentCost;         // ���� ���׷��̵� ���
    [SerializeField] public int startcurrentCost;    // ó�� ���׷��̵� ���

    public int level = 1;               // ���׷��̵� Ƚ��

    [SerializeField] public float upgradePowf;  // ���׷��̵� ���� �þ�� ��� ���� ��
    [SerializeField] public float costPow ;     // ���׷��̵� ���� �߰��Ǵ� ��� ���� ��

    public void Start()
    {   
        DataController.Instance.LoadUpgradeButton(this);
        

        UpdateUI();
    }

    public void Update()
    {
        UpdateUI();
    }

    // ���Ź�ư Ŭ���� �Ҹ��� �Լ�
    public void BuyUpgreade()
    {
        if (DataController.Instance.Gold >= currentCost)
        {
            DataController.Instance.Gold -= currentCost;
            level++;
            DataController.Instance.ClickGold += upgradeGold;

            UpdateUpgrad();
            UpdateUI();
            DataController.Instance.SaveUpgradeButton(this);
            Debug.Log("BuyUpgreade111111111111111111111111111111");
        }
    }
    public void UpdateUpgrad()
    {
        upgradeGold =  1;
        currentCost = Mathf.FloorToInt(currentCost * costPow);
        //upgradeGold = startupgradeGold * (int)Mathf.Pow(upgradePow, level);
    }

    public void UpdateUI()
    {

        upgradText.text = upgradeName +
            string.Format("\nPrice :{0:#,###0}", currentCost) +
            "\nLv : " + string.Format("{0:#,###0}", level) +
            "\nGoldClick : " + string.Format("{0:#,###0}", DataController.Instance.ClickGold);


        //Debug.Log("Ŭ���� ��� : " + DataController.Instance.ClickGold);
        //Debug.Log("�Ǹűݾ� : " + currentCost);
        //Debug.Log("Lv : " + level);
    }
    
}
