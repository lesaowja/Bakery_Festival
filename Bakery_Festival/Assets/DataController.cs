using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;              
using System.Text;

public class DataController : MonoBehaviour
{ 
    int sumValue;
     

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

    // ���� ����� �ڵ����� �Ҹ��� �Լ�
    private void OnApplicationQuit()
    {
        UpdateLastPlayDate();       // ���� ����� �÷��� Ÿ�� ����.
        SetGoldPerSec();
    }

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
            // �����ص� ���� ""Ű���� ���� �ҷ�����
            return PlayerPrefs.GetInt("GoldClick", 1);
        }
        set
        {
            // value ���� �����Ѵ�.
            PlayerPrefs.SetInt("GoldClick", value);
        }
    }

    private void Start()
    {
        Debug.Log("Start ���� �ð� : " + PlayerPrefs.GetString("Time"));
        Debug.Log("Start ���� ���� ���ִ� �ð� : " + AfterTime() + " ��");
        Debug.Log("Start ���۽� �ʴ� ���� : " + PlayerPrefs.GetInt("_isGoldPerSecSum") + " ��"); ;

        Gold += PlayerPrefs.GetInt("_isGoldPerSecSum") * Mathf.Clamp(AfterTime(), 0, 260000);       // ���ӿ� �������� �ʾƵ� �ð��� �帥��ŭ ��带 �����ش�. (�ִ� 3�� ����)
      
        InvokeRepeating("UpdateLastPlayDate", 0f, 10f);     // ���� ���� ���۽� 10�ʸ��� �ڵ����� �÷��� �ð� ����.
        InvokeRepeating("SetGoldPerSec", 0f, 1f); // ���۽� 1�ʸ��� �ݾ� ���� �� ����
    }
    private void Update()
    {
       
        Debug.Log("Update ���� �ʴ� ���� : " + GetGoldPerSec() + " ��"); ;
        Debug.Log("���� ������ �Ѿ� : " + ClickGold);
    }

    // �󸶵��� ������ ���� �־����� Ȯ���ϴ� �Լ�
    public int AfterTime()
    {
        DateTime curretTime = DateTime.Now;             // ����ð�
        DateTime lastPlayDate = GetLastPlayDate();      // ������ ���� ����ð�
        Debug.Log("AfterTime �Ҹ�");

        TimeSpan span = curretTime - lastPlayDate;      // ����ð� - ������ ���ӽð� = �� �ð� ���� 

        return (int)span.TotalSeconds;                  // �ð����̸� �� ������ �����Ѵ�.      
    }
     

    public int GetGoldPerSec()
    {
        // �ʴ� ���� ��
        int sum = 0;
        sum += 5;
        Debug.Log("GetGoldPerSec �Ҹ�");
        return sum;
    }
    public void SetGoldPerSec()
    {
        PlayerPrefs.SetInt("_isGoldPerSecSum", GetGoldPerSec());

        Debug.Log(" �ʴ���� ����");

    }
}
