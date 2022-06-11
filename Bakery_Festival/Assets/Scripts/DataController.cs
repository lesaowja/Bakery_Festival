using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;               // dataTime ����ϱ� ����
using System.Text;          // �ٸ� ��ü�� ��ȯ�ϱ�����

public class DataController : Singleton<DataController>
{
    // �ʴ� ���� ��ư ���� �迭
    public GoldPerSecButton[] goldPerSecButtons;
    int sumValue;

    void Start()
    {
        // ���ӿ� �������� �ʾƵ� �ð��� �帥��ŭ ��带 �����ش�. (�ִ� 3�� ����)
        Gold += PlayerPrefs.GetInt("_isGoldPerSecSum") * Mathf.Clamp(AfterTime(), 0, 260000);
    }

    // ������ �÷��� ��¥
    DateTime GetLastPlayDate()
    {
        // �ð��� �������� �ʾҴٸ�
        if (!PlayerPrefs.HasKey("Time"))
        {
            return DateTime.Now;    // ����ð��� �����´�.
        }

        string timeInString = PlayerPrefs.GetString("Time");    // �����ص� ���� �ð��� �����´�.
        DateTime time = Convert.ToDateTime(timeInString);       // String ���� long�� ���·� ��ȯ�����ش�.

        return time;
    }

    // ������ �÷��� �� ����(�ð�) ������Ʈ
    void UpdateLastPlayDate()
    {
        PlayerPrefs.SetString("Time", DateTime.Now.ToString());     // ���� �ð��� string���� ����
    }

    // �󸶵��� ������ ���� �־����� Ȯ���ϴ� �Լ�
    public int AfterTime()
    {
        DateTime currentTime = DateTime.Now;            // ����ð�
        DateTime lastPlayDate = GetLastPlayDate();      // ������ ���� ����ð�

        TimeSpan span = currentTime - lastPlayDate;     // ������ �����ϰ� �帥�ð�.

        return (int)span.TotalSeconds;                  // �ð� ���̸� �� ������ ����.
    }

    // ���� ����� �ڵ����� �Ҹ��� �Լ�
    private void OnApplicationQuit()
    {
        UpdateLastPlayDate();                           // ���� ����� �÷��� Ÿ�� ����.
    }

    // ���� ��差
    public long Gold
    {
        get
        {
            // ��尡 ����Ǿ� �ִ��� Ȯ��
            if (!PlayerPrefs.HasKey("Gold"))
            {
                return 0;
            }

            string gold = PlayerPrefs.GetString("Gold");
            // ��Ʈ�� ��带 ��Ʈ�� ����
            return long.Parse(gold);

        }
        set
        {
            PlayerPrefs.SetString("Gold", value.ToString());
        }
    }

    public int ClickGold
    {
        get
        {
            // �����ص� ���� Ű���� ���� �ҷ�����
            return PlayerPrefs.GetInt("ClickGold", 1);
        }
        set
        {
            // value ���� �����Ѵ�.
            PlayerPrefs.SetInt("ClickGold", value);
        }
    }

    // �ʴ� ���� ������ �ҷ�����
    public void LoadWorkButton(GoldPerSecButton itemButton)
    {
        string key = itemButton.itemName;

        // ������ִ� Ű���� �̿��ؼ� �����ͺҷ�����
        itemButton.level = PlayerPrefs.GetInt(key + "_level");
        itemButton.currentCost = PlayerPrefs.GetInt(key + "_cost", itemButton.startCurrentCost);
        itemButton.goldPerCec = PlayerPrefs.GetInt(key + "_goldPerSec", itemButton.startGoldPerSec);

        // isBuy : ���� ���� Ȯ��
        // �������� ���Ű� �Ǿ��ִٸ� 1, �ƴϸ� 0 ���� ���ſ��θ� Ȯ���� �� �ҷ��´�.
        if (PlayerPrefs.GetInt(key + "_isBuy") == 1)
        {
            itemButton.isBuy = true;
        }
        else
        {
            itemButton.isBuy = false;
        }
    }

    // �ʴ� ���� ������ ����
    public void SaveWorkButton(GoldPerSecButton itemButton)
    {
        string key = itemButton.itemName;

        PlayerPrefs.SetInt(key + "_level", itemButton.level);
        PlayerPrefs.SetInt(key + "_cost", itemButton.currentCost);
        PlayerPrefs.SetInt(key + "_goldPerSec", itemButton.goldPerCec);

        // isBuy : ���� ���� Ȯ��
        // �������� ���Ű� �Ǿ��ִٸ� 1, �ƴϸ� 0 ���� ���ſ��θ� Ȯ���� �� �����Ѵ�.
        if (itemButton.isBuy == true)
        {
            PlayerPrefs.SetInt(key + "_isBuy", 1);
        }
        else
        {
            PlayerPrefs.SetInt(key + "_isBuy", 0);
        }
    }






    public int GetGoldPerSec()
    {
        // �ʴ� ���� ��
        int sum = 0;

        for (int i = 0; i < goldPerSecButtons.Length; i++)
        {
            if (goldPerSecButtons[i].isBuy == true)                    // workButtons ��ư�� ���� ���� ��쿡�� goldPerCec �� �����ش�.
                sum += goldPerSecButtons[i].goldPerCec;
        } 
        return sum;
    }
    public void SetGoldPerSec()
    {
        PlayerPrefs.SetInt("_isGoldPerSecSum", GetGoldPerSec());        
    }

}
