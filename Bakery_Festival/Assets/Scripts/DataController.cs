using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;               // dataTime ����ϱ� ����
using System.Text;          // �ٸ� ��ü�� ��ȯ�ϱ�����
using System.Text.RegularExpressions;

public class DataController : Singleton<DataController>
{
    // �ʴ� ���� ��ư ���� �迭
    public PerSecUpButton[] goldPerSecButtons;
    int sumValue;

    void Start()
    {
        //StartCoroutine(AddGoldLoop());
        // ���ӿ� �������� �ʾƵ� �ð��� �帥��ŭ ��带 �����ش�. (�ִ� 3�� ����)
        Gold += PlayerPrefs.GetInt("_isGoldPerSecSum") * Mathf.Clamp(AfterTime(), 0, 260000);
        InvokeRepeating("UpdateLastPlayDate", 0f, 10f);         // 10�ʸ��� �÷��� �ð� ����.
    }

    private void Update()
    {
        Debug.Log("�ʴ� ���� : " + PlayerPrefs.GetInt("_isGoldPerSecSum") + " ��");

        goldPerSecButtons = FindObjectsOfType<PerSecUpButton>();
        Debug.Log("�ʴ� ���� �Լ� : " + GetGoldPerSec());
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
        SetGoldPerSec();
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

    // ���� ���
    public long Ruby
    {
        get
        {
            // ��� ����Ǿ� �ִ��� Ȯ��
            if (!PlayerPrefs.HasKey("Ruby"))
            {
                return 0;
            }

            string Luby = PlayerPrefs.GetString("Ruby");
            // ���� ����.
            return long.Parse(Luby);
        }
        set
        {
            PlayerPrefs.SetString("Luby", value.ToString());
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

    // ���׷��̵�(Ŭ���� ����) ��ư������ �ҷ�����
    public void LoadUpgradeButton(ClickUpButton clickUpButton)
    {
        string key = clickUpButton.upgradeName;

        // ������ִ� Ű���� �̿��ؼ� �����ͺҷ�����
        //clickUpButton.startcurrentCost = PlayerPrefs.GetInt(key + "_clickStartCost", clickUpButton.startcurrentCost);
        //clickUpButton.startupgradeGold = PlayerPrefs.GetInt(key + "_clickStartGold", clickUpButton.startupgradeGold);
        clickUpButton.level = PlayerPrefs.GetInt(key + "_Clicklevel", 1);
        clickUpButton.upgradeGold = PlayerPrefs.GetInt(key + "_upgradeGold", clickUpButton.upgradeGold);
        clickUpButton.currentCost = PlayerPrefs.GetInt(key + "_upgradecost", clickUpButton.currentCost);
        Debug.Log("Ŭ�������� �ҷ�����");

    }

    // ���׷��̵�(Ŭ���� ����) ��ư ������ ����
    public void SaveUpgradeButton(ClickUpButton clickUpButton)
    {
        string key = clickUpButton.upgradeName;

        //PlayerPrefs.SetInt(key + "_clickStartCost", clickUpButton.startcurrentCost);
        //PlayerPrefs.SetInt(key + "_clickStartGold", clickUpButton.startupgradeGold);
        PlayerPrefs.SetInt(key + "_Clicklevel", clickUpButton.level);                 // Ű��(_Clicklevel)���� ���� level �� ����.
        PlayerPrefs.SetInt(key + "_upgradeGold", clickUpButton.upgradeGold);     // Ű��(_upgradeGold)���� ���� upgradeGold �� ����. (���׷��̵�� Ŭ���� �������)
        PlayerPrefs.SetInt(key + "_upgradecost", clickUpButton.currentCost);            // Ű��(_cost)���� ���� currentCost �� ����. (���ź��)
        Debug.Log("Ŭ�������� ����"); 
        Debug.Log("Ŭ�������� ���� :" + PlayerPrefs.GetInt(key + "_Clicklevel", clickUpButton.level));

    }

    // �ʴ� ���� ������ �ҷ�����
    public void LoadWorkButton(PerSecUpButton perSecUpButton)
    {
        string key = perSecUpButton.itemName;

        // ������ִ� Ű���� �̿��ؼ� �����ͺҷ�����
        perSecUpButton.level = PlayerPrefs.GetInt(key + "_PerSeclevel");
        perSecUpButton.currentCost = PlayerPrefs.GetInt(key + "_PerSecUpCost", perSecUpButton.currentCost);
        perSecUpButton.goldPerCec = PlayerPrefs.GetInt(key + "_goldPerSec", perSecUpButton.goldPerCec);


        // isBuy : ���� ���� Ȯ��
        // �������� ���Ű� �Ǿ��ִٸ� 1, �ƴϸ� 0 ���� ���ſ��θ� Ȯ���� �� �ҷ��´�.
        if (PlayerPrefs.GetInt(key + "_isBuy") == 1)
        {
            perSecUpButton.isBuy = true;
        }
        else
        {
            perSecUpButton.isBuy = false;
        }
    }

    // �ʴ� ���� ������ ����
    public void SaveWorkButton(PerSecUpButton perSecUpButton)
    {
        string key = perSecUpButton.itemName;

        PlayerPrefs.SetInt(key + "_PerSeclevel", perSecUpButton.level);
        PlayerPrefs.SetInt(key + "_PerSecUpCost", perSecUpButton.currentCost);
        PlayerPrefs.SetInt(key + "_goldPerSec", perSecUpButton.goldPerCec);

        // isBuy : ���� ���� Ȯ��
        // �������� ���Ű� �Ǿ��ִٸ� 1, �ƴϸ� 0 ���� ���ſ��θ� Ȯ���� �� �����Ѵ�.
        if (perSecUpButton.isBuy == true)
        {
            PlayerPrefs.SetInt(key + "_isBuy", 1);
        }
        else
        {
            PlayerPrefs.SetInt(key + "_isBuy", 0);
        }
    }

    // �ʴ� ���� �� ��
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


    // ����ȭ�� Ư�� ���ڷθ� �г����� ���� �� �ְ� �Ѵ�.
    public bool CheckName()
    {
        return Regex.IsMatch(MakeNewName.Instance.playerNameInput.text, "^[0-9a-zA-Z��-�R]*$");
    }

    // �̸� ����
    public void SaveName()
    {

        MakeNewName.Instance.isFirstLogin = false;
        PlayerPrefs.SetString("Name", MakeNewName.Instance.playerNameInput.text);
        if(PlayerPrefs.GetString("Name").Length > 0)
        {
            PlayerPrefs.SetInt("Panel", 1);
            MakeNewName.Instance.FirstPanel();
        }
        else
        {
            Debug.Log("�г����� �Է��ϼ���");
            return;
        }
    }

    // �̸� �ҷ�����
    public void LoadName()
    {
        MakeNewName.Instance.playerNameInput.text = PlayerPrefs.GetString("Name");
    }
}
