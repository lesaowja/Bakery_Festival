using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;              
using System.Text;

public class DataController : MonoBehaviour
{ 
    int sumValue;
     

    // 마지막 플레이 날짜
    DateTime GetLastPlayDate()
    {
        // 시간을 저장하지 않았다면
        if (!PlayerPrefs.HasKey("Time"))
        {
            return DateTime.Now;    // 현재시간을 가져온다.
        }

        string timeInString = PlayerPrefs.GetString("Time");    // 저장해둔 종료 시간을 가져온다.
        DateTime time = Convert.ToDateTime(timeInString);       // String 값을 long의 형태로 변환시켜준다.

        return time;
    }

    // 마지막 플레이 한 시점(시간) 업데이트
    void UpdateLastPlayDate()
    {
        PlayerPrefs.SetString("Time", DateTime.Now.ToString());     // 현재 시간을 string으로 저장
    }

    // 게임 종료시 자동으로 불리는 함수
    private void OnApplicationQuit()
    {
        UpdateLastPlayDate();       // 게임 종료시 플레이 타임 저장.
        SetGoldPerSec();
    }

    public long Gold
    {
        get
        {
            // 골드가 저장되어 있는지 확인
            if (!PlayerPrefs.HasKey("Gold"))
            {
                return 0;
            }

            string gold = PlayerPrefs.GetString("Gold");
            // 스트링 골드를 인트로 전달
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
            // 저장해둔 값을 ""키값에 따라 불러오기
            return PlayerPrefs.GetInt("GoldClick", 1);
        }
        set
        {
            // value 값을 저장한다.
            PlayerPrefs.SetInt("GoldClick", value);
        }
    }

    private void Start()
    {
        Debug.Log("Start 종료 시간 : " + PlayerPrefs.GetString("Time"));
        Debug.Log("Start 게임 종료 되있던 시간 : " + AfterTime() + " 초");
        Debug.Log("Start 시작시 초당 수익 : " + PlayerPrefs.GetInt("_isGoldPerSecSum") + " 원"); ;

        Gold += PlayerPrefs.GetInt("_isGoldPerSecSum") * Mathf.Clamp(AfterTime(), 0, 260000);       // 게임에 접속하지 않아도 시간이 흐른만큼 골드를 더해준다. (최대 3일 까지)
      
        InvokeRepeating("UpdateLastPlayDate", 0f, 10f);     // 게임 실행 시작시 10초마다 자동으로 플레이 시간 저장.
        InvokeRepeating("SetGoldPerSec", 0f, 1f); // 시작시 1초마다 금액 증가 및 저장
    }
    private void Update()
    {
       
        Debug.Log("Update 현재 초당 수익 : " + GetGoldPerSec() + " 원"); ;
        Debug.Log("현재 까지의 총액 : " + ClickGold);
    }

    // 얼마동안 게임을 끄고 있었는지 확인하는 함수
    public int AfterTime()
    {
        DateTime curretTime = DateTime.Now;             // 현재시간
        DateTime lastPlayDate = GetLastPlayDate();      // 마지막 게임 종료시간
        Debug.Log("AfterTime 불림");

        TimeSpan span = curretTime - lastPlayDate;      // 현재시간 - 마지막 접속시간 = 두 시간 차이 

        return (int)span.TotalSeconds;                  // 시간차이를 초 단위로 변경한다.      
    }
     

    public int GetGoldPerSec()
    {
        // 초당 수익 합
        int sum = 0;
        sum += 5;
        Debug.Log("GetGoldPerSec 불림");
        return sum;
    }
    public void SetGoldPerSec()
    {
        PlayerPrefs.SetInt("_isGoldPerSecSum", GetGoldPerSec());

        Debug.Log(" 초당수익 저장");

    }
}
