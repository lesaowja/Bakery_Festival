using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DropFoodsStartTImers : MonoBehaviour
{
    //���� �����ϱ� ���� 3�� ī��Ʈ�� �����ֱ� ���� �гΰ� �ؽ�Ʈ �׸��� ���ڿ��� �� String �� �ð��� ������ Int
    public GameObject panel;
    public Text TimerText;
    string TimerString;
    int StartTimer;
    //������ �Ǿ����� �Ǵ��� ����
    public bool IsStart = false;
    //1�� ����
    float sec1 = 1f;
    //������ �� �ð� 
    int GameTimer = 30;
    //������ ������ �� ����� �гΰ� ��Ʈ�� �� �ؽ�Ʈ 
    public GameObject EndPanel;
    public Text EndText;
    public string EndString;
    private void Start()
    {

        sec1 = 1f;
        GameTimer = 10;
        StartTimer = 3;
        StartCoroutine("StartTimerCourtine");
    }

    IEnumerator StartTimerCourtine()
    {
        if(StartTimer>0)
        {
            if(sec1 >0)
            {
                yield return new WaitForSeconds(0.1f); 
                sec1 -= 0.1f;
            }
            else
            {
                sec1 = 1;
                StartTimer -= 1;

            }

            TimerString = StartTimer.ToString(); 
            TimerText.text = TimerString;
            StartCoroutine("StartTimerCourtine");
        }
        else
        {
            sec1 = 1f;
            IsStart = true;
            panel.SetActive(false);
            StartCoroutine("StartGameTimerCourtine");
        }

        yield return 0;
    }
    IEnumerator StartGameTimerCourtine()
    {
        if (GameTimer > 0)
        {
            if (sec1 > 0)
            {
                yield return new WaitForSeconds(0.1f);
                sec1 -= 0.1f;
            }
            else
            {
                sec1 = 1;
                GameTimer -= 1;

            }

            TimerString = StartTimer.ToString();
            TimerText.text = TimerString;
            StartCoroutine("StartGameTimerCourtine");
        }
        else
        {
         
            IsStart = false;

            yield return new WaitForSeconds(0.1f);
            int ResultSum = GameObject.Find("GameMng").GetComponent<DropFoodsPointMng>().PointsNum;
            EndPanel.SetActive(true);
            EndString = "�̹��� ȹ���� ������ :" + ResultSum.ToString();
            EndText.text = EndString;

        }

        yield return 0;
    }

}
