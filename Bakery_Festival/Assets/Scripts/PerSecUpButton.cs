using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PerSecUpButton : Singleton<PerSecUpButton>
{
    [SerializeField] Text itemText;
    


    public string itemName;
    public int level;

    [HideInInspector]
    public int currentCost;
    public int startCurrentCost = 1;

    [HideInInspector]
    public int goldPerCec;
    public int startGoldPerSec = 1;

    public float CostPow = 3.14f;
    public float upgradePow = 1.14f;

    [HideInInspector]
    public bool isBuy = false;        // ������ ���ſ���

    private void Start()
    {
        DataController.Instance.LoadWorkButton(this);        // ���� ������ ���� �ҷ�����

        StartCoroutine(AddGoldLoop());
        UpdataUI();
    }
    private void Update()
    {
        UpdataUI();
    }

    // ������ ���Ž�
    public void BuyItem()
    {
        if (DataController.Instance.Gold >= currentCost)
        {
            isBuy = true;
            DataController.Instance.Gold -= (currentCost);
            level++;

            UpdateItem();
            UpdataUI();

            // ������ ������ ����
            DataController.Instance.SaveWorkButton(this);
        }
    }

    // 1�ʸ��� �ݺ��ؼ� ��带 ����

 
    IEnumerator AddGoldLoop()
    {
        while (true)
        {
            if (isBuy)
            {
                DataController.Instance.Gold += (goldPerCec);
                Debug.Log("1�ʴ� �ڷ�ƾ �����");
            }

            yield return new WaitForSeconds(1.0f);
        }
    }

    public void UpdateItem()
    {
        goldPerCec = goldPerCec + startGoldPerSec * (int)Mathf.Pow(upgradePow, level);
        currentCost = startCurrentCost * (int)Mathf.Pow(CostPow, level);
    }

    public void UpdataUI()
    {
        itemText.text = itemName + "\nLv : " + string.Format("{0:#,###0}", level) +
            "\nPrice : " + string.Format("{0:#,###0}", currentCost) +
            "\nWagePerSec :" + string.Format("{0:#,###0}", goldPerCec);
    }
}
