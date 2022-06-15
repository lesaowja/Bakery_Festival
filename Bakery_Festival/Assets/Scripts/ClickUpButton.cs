using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickUpButton : MonoBehaviour
{
    [SerializeField] Text upgradText;
 
    public string upgradeName;          // ���׷��̵� �̸�

    public int upgradeGold;             // ���׷��̵� �Ǵ� ��差
    public int startupgradeGold = 1;    // ó�� ���׷��̵� ���

    public int currentCost = 1;         // ���� ���׷��̵� ���
    public int startcurrentCost = 1;    // ó�� ���׷��̵� ���

    public int level = 1;               // ���׷��̵� Ƚ��

    public float upgradePow = 1.14f;  // ���׷��̵� ���� �þ�� ��� ���� ��
    public float costPow = 3.14f;     // ���׷��̵� ���� �߰��Ǵ� ��� ���� ��

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
            Debug.Log("BuyUpgreade");
        }
    }
    public void UpdateUpgrad()
    {
        upgradeGold = startupgradeGold * (int)Mathf.Pow(upgradePow, level);
        currentCost = startcurrentCost * (int)Mathf.Pow(costPow, level);
    }

    public void UpdateUI()
    {

        upgradText.text = upgradeName +
            string.Format("\nPrice :{0:#,###0}", currentCost) +
            "\nLv : " + string.Format("{0:#,###0}", level) +
            "\nGoldClick : " + string.Format("{0:#,###0}", DataController.Instance.ClickGold);

        Debug.Log("Lv : " + level);
    }
    
}
