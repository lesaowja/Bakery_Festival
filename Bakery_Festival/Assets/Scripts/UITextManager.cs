using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITextManager : MonoBehaviour
{
    [SerializeField] Text goldText;
    [SerializeField] Text rubyText;
    [SerializeField] Text goldPerSecText;


    private void Update()
    {
        goldText.text = string.Format("{0:#,###0}", DataController.Instance.Gold + "$");
        // rubyText.text = "Ruby :" + string.Format("{0:#,###0}");
        goldPerSecText.text = string.Format("{0:#,###0}", DataController.Instance.GetGoldPerSec()) + "/s";
    }

    /*
    private string[] goldunit = new string[] { "", "��", "��", "��", "��", "��", "��", "��", "��", "��" };
    private string GetGoldUnit()
    {
        // �ڸ� ����
        int GoldcutUnit = 4;

        long gold = DataController.Instance.Gold;
        // �������� �ڸ� ��� ����
        List<int> numList = new List<int>();

        // �� �������� �ڸ���
        int CutGold = (int)Mathf.Pow(10, GoldcutUnit);

        do
        {
            // ������ �ڸ� ��带 ����Ʈ�� ����
            //numList.Add((int)gold % CutGold);
            // ������ ���̱�.
            //gold /= CutGold;
        }
        while (gold >= 1);  // 1���� ũ�� �ݺ�.

        //������ ���յ� ���ڿ�
        string UnitGold = "";

        ������ �߷��� ��ŭ �ݺ�
        for (int i = 0; i < numList.Count; i++)
        {
            UnitGold = numList[i] + goldunit[i] + UnitGold;
        }

        return UnitGold;
    }

    
    private string GetClickGoldUnit()
    {
        // �ڸ� ����
        int GoldcutUnit = 4;

        long gold = DataController.Instance.ClickGold;
        // �������� �ڸ� ��� ����
        List<int> numList = new List<int>();

        // �� �������� �ڸ���
        int CutGold = (int)Mathf.Pow(10, GoldcutUnit);

        do
        {
            // ������ �ڸ� ��带 ����Ʈ�� ����
            numList.Add((int)gold % CutGold);
            // ������ ���̱�.
            gold /= CutGold;
        }
        while (gold >= 1);  // 1���� ũ�� �ݺ�.

        // ������ ���յ� ���ڿ�
        string UnitGold = "";

        // ������ �߷��� ��ŭ �ݺ�
        for (int i = 0; i < numList.Count; i++)
        {
            UnitGold = numList[i] + goldunit[i] + UnitGold;
        }

        return UnitGold;
    }
    */
}
