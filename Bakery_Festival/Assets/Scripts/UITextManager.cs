using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITextManager : MonoBehaviour
{
    [SerializeField] Text userName;
    [SerializeField] Text goldText;
    [SerializeField] Text rubyText;
    [SerializeField] Text goldPerSecText;
    [SerializeField] CanvasRenderer panel;

    int persecGold;

    private void Start()
    {
        //OnPanel();   
    }

    private void Update()
    {
        persecGold = DataController.Instance.GetGoldPerSec();
        goldText.text = string.Format("{0:#,###0}", DataController.Instance.Gold) + "$";
        userName.text = PlayerPrefs.GetString("Name").ToString();
        rubyText.text = string.Format("{0:#,###0}", DataController.Instance.Ruby);

        
        
        if(panel.gameObject.activeSelf == true)
        {
            goldPerSecText.text = string.Format("{0:#,###0}", persecGold) + "/s";  
        }
    }

    void OnPanel()
    {
        panel.gameObject.SetActive(true);
        panel.SetAlpha(0f);
        Invoke("OffPanel", 0.5f);
    }


    void OffPanel()
    {
        panel.gameObject.SetActive(false);
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
