using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPerSecButton : Singleton<GoldPerSecButton>
{
    public string itemName;                 // ������ �̸�
    public int level;                       // ���� ����

    [HideInInspector]
    public int currentCost;                 // �ʱ� ���ź��
    public int startCurrentCost = 1;        // ���� ���ۺ��

    [HideInInspector]
    public int goldPerCec;                  // �ʱ� �ʴ�ö󰡴� �ݾ�
    public int startGoldPerSec = 1;         // ���� �ʴ�ö󰡴� �ݾ�

    public float CostPow = 3.14f;           // ���ź�� ��������
    public float upgradePow = 1.14f;        // ���׷��̵�� �ö󰡴� �ʴ� ��� ��������

    [HideInInspector]
    public bool isBuy = false;              // ������ ���ſ���

    // ������ ���Ž�
    public void BuyItem()
    {
        if (DataController.Instance.Gold >= currentCost)
        {
            isBuy = true;
            DataController.Instance.Gold -= (currentCost);
            level++;

            UpdateItem();

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
            }

            yield return new WaitForSeconds(1.0f);
        }
    }

    public void UpdateItem()
    {
        goldPerCec = goldPerCec + startGoldPerSec * (int)Mathf.Pow(upgradePow, level);      // ������ ���� �������.
        currentCost = startCurrentCost * (int)Mathf.Pow(CostPow, level);                    // ������ ���� ���ź�� ����.
    }
}
